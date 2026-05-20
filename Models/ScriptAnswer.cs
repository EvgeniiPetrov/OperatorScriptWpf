namespace OperatorScriptWpf.Models;

public sealed class ScriptAnswer
{
    public string Text { get; init; } = "";
    public string? NextStepId { get; init; }
}