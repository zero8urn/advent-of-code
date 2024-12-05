using System.Reflection;
using System.Text;

namespace AdventOfCode.Core;

public static class Files
{
    private const string DefaultInput = "input.txt";

    public static string ReadAllText(string filename = DefaultInput)
    {
        var assembly = Assembly.GetCallingAssembly();
        string name = assembly.GetName().Name ?? "";
       
        using Stream stream = assembly.GetManifestResourceStream($"{name}.{filename}")
            ?? throw new InvalidOperationException($"{name}.{filename} was not found");
        using StreamReader reader = new(stream, Encoding.UTF8);
        return reader.ReadToEnd();
    }
}
