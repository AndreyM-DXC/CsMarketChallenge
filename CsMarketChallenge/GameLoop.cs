
namespace CsMarketChallenge
{
    public class GameLoop
    {
        public readonly IPlayer player1;
        public readonly IPlayer player2;

        public readonly List<bool> decisions1 = new List<bool>();
        public readonly List<bool> decisions2 = new List<bool>();

        public int score1;
        public int score2;

        public int turn;

        public GameLoop(IPlayer player1, IPlayer player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public bool Step(IRender? ui = null)
        {
            var decision1 = player1.NextDecision(new State(score1, score2, decisions1, decisions2));
            var decision2 = player2.NextDecision(new State(score2, score1, decisions2, decisions1));
            var score = State.Score(decision1, decision2);

            score1 += score.player1;
            score2 += score.player2;
            decisions1.Add(decision1);
            decisions2.Add(decision2);

            ui?.Render(this);
            return turn++ < 365;
        }
    }
}
