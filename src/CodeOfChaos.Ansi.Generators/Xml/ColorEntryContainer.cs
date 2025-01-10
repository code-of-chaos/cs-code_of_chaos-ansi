// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace CodeOfChaos.Ansi.Generators.Xml;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
[XmlRoot("ColorEntries")]
public class ColorEntryContainer {
    [XmlElement("ColorEntry")]
    public List<XmlColorEntry> Entries { get; set; } = [];// Default to an empty list
}

public class XmlColorEntry {
    [XmlAttribute("Name")]
    public string Name { get; set; } = string.Empty;// Name attribute for the color

    [XmlAttribute("Color")]
    public string Color { get; set; } = string.Empty;// RGB values as a comma-separated string
    
    private readonly Regex _regexCommaSeparated = new(@"^(\d+)[,.;:](\d+)[,.;:](\d+)$", RegexOptions.Compiled);
    private readonly Regex _regexHexFormat = new(@"^#?([A-Fa-f0-9]{6})$", RegexOptions.Compiled);

    public ColorEntry ToColorEntry() {
        if (_regexCommaSeparated.Match(Color) is {Success : true } match) return new ColorEntry {
            Name = Name,
            Codes = [
                int.Parse(match.Groups[1].Value),
                int.Parse(match.Groups[2].Value),
                int.Parse(match.Groups[3].Value)
            ]
        };

        if (_regexHexFormat.IsMatch(Color)) {
            string hex = Color.TrimStart('#');
            return new ColorEntry {
                Name = Name,
                Codes = Enumerable.Range(0, 3)
                    .Select(i => Convert.ToInt32(hex.Substring(i * 2, 2), 16))
                    .ToArray()
            };
        }

        throw new FormatException("Invalid Color format.");
    }
}

public class ColorEntry {
    public string Name { get; set; } = string.Empty;// Mapped Name

    public int[] Codes { get; set; } = [];// Mapped and split RGB values
    
    public string Colors => string.Join(",", Codes);
}
