using Answers.Days._2.Models;

namespace Answers.Days._2;

[OutputOrder(2.2)]
internal class Day2Part2AnswerProvider : IAnswerProvider
{
    public const string INPUT_PATH = @"Days\2\Input2.txt";

    public string InputPath => INPUT_PATH;

    public string DayName => "Day 2 Part 2";

    public int GetAnswer(string[] inputLines)
    {
        var games = Game.ParseGames(inputLines);
        var minimumPossibleSamples = games
            .Select(g => new CubeSample()
            {
                Red = g.Samples.Max(s => s.Red),
                Green = g.Samples.Max(s => s.Green),
                Blue = g.Samples.Max(s => s.Blue)
            });
        var result = minimumPossibleSamples.Sum(s => s.Power);

        return result;
    }
}
