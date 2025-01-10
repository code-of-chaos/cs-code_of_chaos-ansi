// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Text;

namespace CodeOfChaos.Ansi;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public partial class AnsiStringBuilder {
    internal StringBuilder Builder { get; init; } = new();
    public int Length => Builder.Length;
    
    public AnsiForegroundBuilder Foreground => new() { Builder = Builder };
    public AnsiForegroundBuilder Fore => Foreground;
    
    public AnsiBackgroundBuilder Background => new() { Builder = Builder };
    public AnsiBackgroundBuilder Back => Background;

    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    private AnsiStringBuilder BuilderAction(Action action) {
        action();
        return this;
    }
    
    public AnsiStringBuilder WithForeground(Action<AnsiForegroundBuilder> action) => BuilderAction(() => action(Foreground)); 
    public AnsiStringBuilder WithFore(Action<AnsiForegroundBuilder> action) => BuilderAction(() => action(Foreground)); 
    
    public AnsiStringBuilder WithBackground(Action<AnsiForegroundBuilder> action) => BuilderAction(() => action(Foreground)); 
    public AnsiStringBuilder WithBack(Action<AnsiForegroundBuilder> action) => BuilderAction(() => action(Foreground)); 
    
    public AnsiStringBuilder Append(string value) => BuilderAction(() => Builder.Append(value));
    public AnsiStringBuilder AppendLine(string value) =>  BuilderAction(() => Builder.AppendLine(value));
    
    public string ToStringAndClear() {
        string result = Builder.ToString();
        Builder.Clear();
        return result;
    }
    
    public override string ToString() => Builder.ToString();
    public void Clear() => Builder.Clear();
}
