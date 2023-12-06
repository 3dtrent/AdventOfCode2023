namespace Answers.Days._2.Models;

internal class CubeSample
{
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }

    public int Power => Red * Green * Blue;

    public static IEnumerable<CubeSample> ParseCubeSamples(string input)
    {
        var sampleSplit = input.Split(';');
        foreach (var sample in sampleSplit)
        {
            yield return ParseCubeSample(sample);
        }
    }

    public static CubeSample ParseCubeSample(string input)
    {
        CubeSample result = new();
        var colorSplit = input.Split(',');
        foreach (var colorInput in colorSplit)
        {
            var quantitySplit = colorInput.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            var quantity = int.Parse(quantitySplit.First());
            var color = quantitySplit.Last();
            if (color.Equals("red", StringComparison.OrdinalIgnoreCase))
                result.Red = quantity;
            else if (color.Equals("green", StringComparison.OrdinalIgnoreCase))
                result.Green = quantity;
            else if (color.Equals("blue", StringComparison.OrdinalIgnoreCase))
                result.Blue = quantity;
        }
        return result;
    }
}
