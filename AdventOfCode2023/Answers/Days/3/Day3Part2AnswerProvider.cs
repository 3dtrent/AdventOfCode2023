namespace Answers.Days._3;

[OutputOrder(3.2)]
internal class Day3Part2AnswerProvider : IAnswerProvider
{
    public const string INPUT_PATH = @"Days\3\Input3.txt";

    public string InputPath => INPUT_PATH;

    public string DayName => "Day 3 Part 2";

    public int GetAnswer(string[] inputLines)
    {
        var lineWidth = inputLines.Max(l => l.Length);
        var parts = BuildPartDictionary(inputLines);

        List<List<int>> partNumberSets = new();
        for (var lineIndex = 0; lineIndex < inputLines.Length; lineIndex++)
        {
            var previousLine = lineIndex > 0 ? inputLines[lineIndex - 1] : null;
            var currentLine = inputLines[lineIndex];
            var nextLine = lineIndex + 1 < inputLines.Length ? inputLines[lineIndex + 1] : null;

            List<string> scanLines = new();

            if (previousLine != null) 
                scanLines.Add(previousLine);

            scanLines.Add(currentLine);

            if (nextLine != null) 
                scanLines.Add(nextLine);

            for (var charIndex = 0;  charIndex < currentLine.Length; charIndex++)
            {
                var currentChar = currentLine[charIndex];
                if (currentChar == '*')
                {
                    List<int> partNumberSet = new();

                    var scanCharStartIndex = charIndex - 1;
                    var scanCharEndIndex = charIndex + 1;

                    var scanLineStartIndex = Math.Max(lineIndex - 1, 0);
                    var scanLineEndIndex = Math.Min(lineIndex + 1, inputLines.Length);

                    for (var scanLineIndex = scanLineStartIndex; scanLineIndex <= scanLineEndIndex; scanLineIndex++)
                    {
                        for(var scanCharIndex = scanCharStartIndex; scanCharIndex <= scanCharEndIndex; scanCharIndex++)
                        {
                            var part = parts.FindPart(scanLineIndex, scanCharIndex);
                            if (part == null)
                                continue;

                            partNumberSet.Add(part.Number);
                            scanCharIndex = part.EndIndex + 1;
                        }
                    }

                    if (partNumberSet.Count == 2)
                        partNumberSets.Add(partNumberSet);
                    else if (partNumberSet.Count > 2)
                        throw new Exception("Found more than two part numbers by a gear");
                }
            }
        }

        return partNumberSets.Sum(s => s[0] * s[1]);
    }

    private static PartDictionary BuildPartDictionary(string[] inputLines)
    {
        var lineWidth = GetLineWidth(inputLines);

        PartDictionary result = new(lineWidth);

        for (var lineIndex = 0; lineIndex < inputLines.Length; lineIndex++)
        {
            var line = inputLines[lineIndex];
            for (var charIndex = 0; charIndex < line.Length; charIndex++)
            {
                var digitChars = line[charIndex..].TakeWhile(c => char.IsDigit(c));
                if (!digitChars.Any())
                    continue;

                var digitString = new string(digitChars.ToArray());
                var partNumber = int.Parse(digitString);
                var startIndex = charIndex;
                var endIndex = charIndex + digitString.Length - 1;

                Part part = new(partNumber, startIndex, endIndex);

                for(; charIndex <= endIndex; charIndex++)
                {
                    // add the same part number with each index it occupies in the input string
                    result.AddPart(lineIndex, charIndex, part);
                }
            }
        }

        return result;
    }

    private static int GetLineWidth(string[] inputLines) => inputLines.Max(l => l.Length);

    private record Part(int Number, int StartIndex, int EndIndex);

    private class PartDictionary : Dictionary<int, Part>
    {
        public PartDictionary(int lineWidth) : base()
        {
            LineWidth = lineWidth;
        }

        private int LineWidth { get; }

        public void AddPart(int lineIndex, int charIndex, Part part)
        {
            var resultIndex = BuildIndex(LineWidth, lineIndex, charIndex);
            Add(resultIndex, part);
        }

        public Part? FindPart(int lineIndex, int charIndex)
        {
            var index = BuildIndex(LineWidth, lineIndex, charIndex);
            if (TryGetValue(index, out var part))
                return part;

            return null;
        }

        private static int BuildIndex(int lineWidth, int lineIndex, int charIndex)
            => (lineWidth * lineIndex) + charIndex;
    }
}
