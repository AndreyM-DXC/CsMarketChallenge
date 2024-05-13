
namespace CsMarketChallenge
{
    public static class Program
    {
        public static void Main()
        {
            var random = new Random();
            var competitors = new IPlayer[]
            {
                // Here will be all the strategies of all participants
                new RandomPlayer(),
            }
            .OrderBy(x => random.NextDouble())
            .Select(x => new Competitor(x))
            .ToArray();

            for (var i = 0; i < competitors.Length; i++)
            {
                for (var j = i; j < competitors.Length; j++)
                {
                    var game = new GameLoop(competitors[i].Player, competitors[j].Player);

                    while (game.Step()) { }

                    competitors[i].Score += game.score1;
                    competitors[j].Score += game.score2;
                }
            }

            foreach (var competitor in competitors.OrderByDescending(x => x.Score))
            {
                Console.WriteLine($"{competitor.Score} - {competitor.Player.Title} - {competitor.Player.Author}");
            }
        }

        private class Competitor
        {
            public readonly IPlayer Player;
            public int Score;

            public Competitor(IPlayer player)
            {
                Player = player;
            }
        }
    }
}
