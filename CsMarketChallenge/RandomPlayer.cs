
namespace CsMarketChallenge
{
    public class RandomPlayer : IPlayer
    {
        private readonly Random random = new Random();

        public override string Author => "John Smith";

        public override string Title => "Random Strategy";

        public override bool NextDecision(State state)
        {
            return random.NextDouble() < 0.5;
        }
    }
}
