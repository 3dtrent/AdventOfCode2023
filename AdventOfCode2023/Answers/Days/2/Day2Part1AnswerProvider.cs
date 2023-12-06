using Answers.Days._2.Models;

namespace Answers.Days._2;

[OutputOrder(2.1)]
internal class Day3Part1AnswerProvider : IAnswerProvider
{
    public const string INPUT_PATH = @"Days\2\Input2.txt";

    public const int MAX_RED = 12;
    public const int MAX_GREEN = 13;
    public const int MAX_BLUE = 14;

    public string InputPath => INPUT_PATH;

    public string DayName => "Day 2 Part 1";

    public int GetAnswer(string[] inputLines)
    {
        var games = Game.ParseGames(inputLines);
        var result = games
            .Where(g => g.Samples.All(s => s.Red <= MAX_RED && s.Green <= MAX_GREEN && s.Blue <= MAX_BLUE))
            .Sum(g => g.Id);

        return result;
    }
}
