using System.CommandLine;

namespace Json2SharpApp.Parameters.Abstractions;

internal interface IParameter
{
    IReadOnlyList<string> Aliases { get; }
    string Description { get; }
    void AddParameter(Command cliCommand);
}