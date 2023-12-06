namespace Answers.Days._3;

[OutputOrder(3.1)]
internal class Day3Part1AnswerProvider : IAnswerProvider
{
    public const string INPUT_PATH = @"Days\3\Input3.txt";

    public string InputPath => INPUT_PATH;

    public string DayName => "Day 3 Part 1";

    public int GetAnswer(string[] inputLines)
    {
        List<int> partNumbers = new();
        for (var lineIndex = 0; lineIndex < inputLines.Length; lineIndex++)
        {
            var previousLine = lineIndex > 0 ? inputLines[lineIndex - 1] : null;
            var currentLine = inputLines[lineIndex];
            var nextLine = lineIndex + 1 < inputLines.Length ? inputLines[lineIndex + 1] : null;

            for (var charIndex = 0;  charIndex < currentLine.Length; charIndex++)
            {
                var currentChar = currentLine[charIndex];
                if (char.IsDigit(currentChar))
                {
                    var digitChars = currentLine[charIndex..].TakeWhile(char.IsDigit).ToArray();

                    var windowStartIndex = charIndex - 1;
                    var windowEndIndex = charIndex + digitChars.Length + 1;
                    var isPartNumber = 
                        HasSymbol(previousLine, windowStartIndex, windowEndIndex) || 
                        HasSymbol(currentLine, windowStartIndex, windowEndIndex) || 
                        HasSymbol(nextLine, windowStartIndex, windowEndIndex);

                    if (isPartNumber)
                    {
                        var digitString = new string(digitChars.ToArray());
                        var value = int.Parse(digitString);
                        partNumbers.Add(value);
                    }

                    charIndex += digitChars.Length;
                }
            }
        }

        return partNumbers.Sum();
    }

    private static bool HasSymbol(string? input, int startIndex, int endIndex)
    {
        if (input == null) 
            return false;

        var fixedStartIndex = Math.Max(startIndex, 0);
        var fixedEndIndex = Math.Min(endIndex, input.Length);

        if (fixedStartIndex >= fixedEndIndex) 
            return false;

        return input[fixedStartIndex..fixedEndIndex].Any(c => !char.IsDigit(c) && c != '.');
    }
}
