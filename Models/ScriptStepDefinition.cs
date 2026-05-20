namespace OperatorScriptWpf.Models;

public sealed class ScriptStepDefinition
{
    public string Id { get; init; } = "";
    public string Theme { get; init; } = "";
    public string TextTemplate { get; init; } = "";
    public IReadOnlyList<ScriptAnswer> Answers { get; init; } = Array.Empty<ScriptAnswer>();
}