namespace Answers.Days._2.Models;

internal class Game
{
    public int Id { get; set; }
    public IEnumerable<CubeSample> Samples { get; set; } = Enumerable.Empty<CubeSample>();

    public static IEnumerable<Game> ParseGames(IEnumerable<string> inputs)
    {
        foreach (var input in inputs)
        {
            yield return ParseGame(input);
        }
    }

    public static Game ParseGame(string input)
    {
        Game result = new();

        var gameSplit = input.Split(':', 2);
        var gameIdSplit = gameSplit.First().Split(' ', 2);

        result.Id = int.Parse(gameIdSplit.Last());
        result.Samples = CubeSample.ParseCubeSamples(gameSplit.Last());

        return result;
    }
}
