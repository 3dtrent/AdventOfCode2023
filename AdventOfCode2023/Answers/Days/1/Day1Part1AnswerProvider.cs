namespace Answers.Days._1;

[OutputOrder(1.1)]
internal class Day2Part1AnswerProvider : IAnswerProvider
{
    public const string INPUT_PATH = @"Days\1\Input1.txt";

    public string InputPath => INPUT_PATH;

    public string DayName => "Day 1 Part 1";

    public int GetAnswer(string[] inputLines)
    {
        var numbers = inputLines.Select(BuildNumber);
        var result = numbers.Sum();
        return result;
    }

    private static int BuildNumber(string word)
    {
        List<int> digits = new();
        foreach(var c in word)
        {
            var numericValue = char.GetNumericValue(c);
            if (numericValue > 0)
            {
                digits.Add((int)numericValue);
                continue;
            }
        }
        return (digits.First() * 10) + digits.Last();
    }
}
