using System.Collections.ObjectModel;

namespace CsMarketChallenge
{
    public readonly struct State
    {
        public readonly int MyScore;
        public readonly int OpponentScore;

        public readonly ReadOnlyCollection<bool> MyDecisions;
        public readonly ReadOnlyCollection<bool> OpponentDecisions;

        public int Turn => MyDecisions.Count;

        public State(int myScore, int opponentScore, IList<bool> myDecisions, IList<bool> opponentDecisions)
        {
            MyScore = myScore;
            OpponentScore = opponentScore;
            MyDecisions = myDecisions.AsReadOnly();
            OpponentDecisions = opponentDecisions.AsReadOnly();
        }

        public static (int player1, int player2) Score(bool player1, bool player2)
        {
            if (player1)
            {
                return player2 ? (1, 1) : (0, 5);
            }
            else
            {
                return player2 ? (5, 0) : (3, 3);
            }
        }
    }
}
