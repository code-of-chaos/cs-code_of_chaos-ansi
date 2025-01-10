// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Text;

namespace CodeOfChaos.Ansi;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class AnsiStringBuilder {
    internal StringBuilder Builder { get; init; } = new();
    public int Length => Builder.Length;

    public AnsiForegroundBuilder Foreground => new() { Builder = Builder };
    public AnsiForegroundBuilder Fore => Foreground;
    public AnsiForegroundBuilder F => Foreground;

    public AnsiBackgroundBuilder Background => new() { Builder = Builder };
    public AnsiBackgroundBuilder Back => Background;
    public AnsiBackgroundBuilder B => Background;

    public AnsiUnderlineBuilder Underline => new() { Builder = Builder };
    public AnsiUnderlineBuilder Under => Underline;
    public AnsiUnderlineBuilder U => Underline;

    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    private AnsiStringBuilder BuilderAction(Action action) {
        action();
        return this;
    }

    public AnsiStringBuilder WithForeground(Action<AnsiForegroundBuilder> action) => BuilderAction(() => action(Foreground));
    public AnsiStringBuilder WithFore(Action<AnsiForegroundBuilder> action) => BuilderAction(() => action(Foreground));

    public AnsiStringBuilder WithBackground(Action<AnsiBackgroundBuilder> action) => BuilderAction(() => action(Background));
    public AnsiStringBuilder WithBack(Action<AnsiBackgroundBuilder> action) => BuilderAction(() => action(Background));

    public AnsiStringBuilder WithUnderline(Action<AnsiUnderlineBuilder> action) => BuilderAction(() => action(Underline));
    public AnsiStringBuilder WithUnder(Action<AnsiUnderlineBuilder> action) => BuilderAction(() => action(Underline));

    public AnsiStringBuilder Append(string value) => BuilderAction(() => Builder.Append(value));
    public AnsiStringBuilder AppendLine(string value) => BuilderAction(() => Builder.AppendLine(value));

    public string ToStringAndClear() {
        string result = Builder.ToString();
        Builder.Clear();
        return result;
    }

    public override string ToString() => Builder.ToString();
    public void Clear() => Builder.Clear();
}
