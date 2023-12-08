namespace Answers.Days._4;

[OutputOrder(4.1)]
internal class Day4Part1AnswerProvider : IAnswerProvider
{
    public const string INPUT_PATH = @"Days\4\Input4.txt";

    public string InputPath => INPUT_PATH;

    public string DayName => "Day 4 Part 1";

    public int GetAnswer(string[] inputLines)
    {
        var cards = Card.ParseCards(inputLines);
        var result = cards.Sum(c => c.Points);
        return result;
    }

    private record Card(int CardNumber, HashSet<int> WinningNumbers, HashSet<int> FoundNumbers)
    {
        private const int CardNumberStartIndex = 5;
        private const int CardNumberLength = 3;

        private const int WinningNumberStartIndex = 10;
        private const int WinningNumberLength = 2;
        private const int WinningNumberQuantity = 10;

        private const int FoundNumberStartIndex = 42;
        private const int FoundNumberLength = 2;
        private const int FoundNumberQuantity = 25;

        public IEnumerable<int> MatchingNumbers => WinningNumbers.Where(w => FoundNumbers.Contains(w));
        public int Points
        {
            get
            {
                var matchingNumberCount = MatchingNumbers.Count();
                return matchingNumberCount > 0 ? (int)Math.Pow(2, matchingNumberCount - 1) : 0;
            }
        }

        public static IEnumerable<Card> ParseCards(string[] inputLines)
        {
            return inputLines.Select(ParseCard);
        }

        public static Card ParseCard(string input)
        {
            var cardNumberString = input.Substring(CardNumberStartIndex, CardNumberLength);
            var cardNumber = int.Parse(cardNumberString.TrimStart());

            HashSet<int> winningNumbers = new();
            for (var i = 0; i < WinningNumberQuantity; i++)
            {
                var startIndex = WinningNumberStartIndex + (i * (WinningNumberLength + 1));
                var winningNumberString = input.Substring(startIndex, WinningNumberLength);
                var winningNumber = int.Parse(winningNumberString.TrimStart());

                winningNumbers.Add(winningNumber);
            }

            HashSet<int> foundNumbers = new();
            for (var i = 0; i < FoundNumberQuantity; i++)
            {
                var startIndex = FoundNumberStartIndex + (i * (FoundNumberLength + 1));
                var foundNumberString = input.Substring(startIndex, FoundNumberLength);
                var foundNumber = int.Parse(foundNumberString.TrimStart());

                foundNumbers.Add(foundNumber);
            }

            return new Card(cardNumber, winningNumbers, foundNumbers);
        }
    }
}
