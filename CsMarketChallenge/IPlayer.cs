
namespace CsMarketChallenge
{
    public abstract class IPlayer
    {
        /// <summary>Your name as the author of the strategy to facilitate the formation of the results table</summary>
        public abstract string Author { get; }

        /// <summary>Short name of the strategy</summary>
        public abstract string Title { get; }

        /// <summary>Decides whether to give a discount or not</summary>
        public abstract bool NextDecision(State state);

        /// <summary>Override hash code for manual avatar selection</summary>
        public override int GetHashCode()
        {
            var result = 0;
            foreach (var ch in $"{Title} {Author}")
            {
                result = (result * 397) ^ ch;
            }
            return result;
        }
    }
}
