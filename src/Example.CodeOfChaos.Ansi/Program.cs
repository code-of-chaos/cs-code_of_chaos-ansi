// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using CodeOfChaos.Ansi;

namespace Example.CodeOfChaos.Ansi;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public static class Program {
    public static void Main() {
        var builder = new AnsiStringBuilder();
        
        builder.AppendLine("Hello World");

        builder.Foreground.AppendRedLine("something here");
        builder.Foreground.AppendGreenLine("something green here");


        builder.WithForeground(b => b
            .AppendRedLine("something red here")
            .AppendLine($"something {b.Fore.Green(b.Back.Yellow("green on yellow"))} here")
        );

        Console.WriteLine(builder.ToString());
    }
}
