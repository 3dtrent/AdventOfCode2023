using System.Reflection;

namespace Answers;

internal static class InputHelper
{
    public static string CurrentDirectory { get; } = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? string.Empty;

    public static string GetAbsolutePath(string path)
    {
        return Path.Combine(CurrentDirectory, path);
    }

    public static async Task<string> GetInput(string relativePath)
    {
        var absolutePath = GetAbsolutePath(relativePath);
        return await File.ReadAllTextAsync(absolutePath);
    }

    public static async Task<string[]> GetInputLines(string relativePath)
    {
        var absolutePath = GetAbsolutePath(relativePath);
        return await File.ReadAllLinesAsync(absolutePath);
    }
}
