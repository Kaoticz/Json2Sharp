using Json2SharpApp.Parameters.Abstractions;
using System.CommandLine;
using System.Reflection;

namespace Json2SharpApp;

internal sealed class Program
{
    private async static Task<int> Main(string[] args)
    {
        var rootCommand = new RootCommand("Convert a JSON object to a valid language type declaration.");

        var cliParameters = Assembly.GetExecutingAssembly().DefinedTypes
            .Where(x => !x.IsAbstract && !x.IsInterface && x.IsAssignableTo(typeof(IParameter)))
            .Select(x => (IParameter)Activator.CreateInstance(x)!);

        foreach (var cliParameter in cliParameters)
            cliParameter.AddParameter(rootCommand);

        return await rootCommand.InvokeAsync(args);
    }
}