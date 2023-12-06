namespace Answers.Days._1;

[OutputOrder(1.2)]
internal class Day1Part2AnswerProvider : IAnswerProvider
{
    public const string INPUT_PATH = @"Days\1\Input1.txt";

    public static readonly List<string> DigitWords = new() { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

    public string InputPath => INPUT_PATH;

    public string DayName => "Day 1 Part 2";

    public int GetAnswer(string[] inputLines)
    {
        var numbers = inputLines.Select(BuildNumber);
        var result = numbers.Sum();
        return result;
    }

    private static int BuildNumber(string word)
    {
        List<int> digits = new();
        for (var i = 0; i < word.Length; i++)
        {
            var charValue = char.GetNumericValue(word[i]);
            if (charValue >= 1)
            {
                digits.Add((int)charValue);
                continue;
            }

            var textValue = GetNumericValue(word[i..]);
            if (textValue >= 1)
            {
                digits.Add(textValue);
                continue;
            }
        }
        return (digits.First() * 10) + digits.Last();
    }

    private static int GetNumericValue(string word)
    {
        var currentValue = 1;
        foreach(var digitWord in DigitWords)
        {
            if (word.StartsWith(digitWord, StringComparison.OrdinalIgnoreCase))
                return currentValue;

            currentValue++;
        }

        return -1;
    }
}
