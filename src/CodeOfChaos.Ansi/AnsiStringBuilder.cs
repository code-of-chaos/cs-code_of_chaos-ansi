// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Text;

namespace CodeOfChaos.Ansi;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public partial class AnsiStringBuilder {
    private StringBuilder _builder = new();

    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    private AnsiStringBuilder BuilderAction(Action action) {
        action();
        return this;
    }
    
    public void Append(string value) => _builder.Append(value);
    public void AppendLine(string value) => _builder.AppendLine(value);
    public string ToStringAndClear() {
        string result = _builder.ToString();
        _builder.Clear();
        return result;
    }
}
