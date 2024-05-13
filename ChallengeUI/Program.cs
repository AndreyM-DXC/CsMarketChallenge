using CsMarketChallenge;
using Timer = System.Windows.Forms.Timer;

namespace ChallengeUI
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            ApplicationConfiguration.Initialize();

            var player1 = new RandomPlayer();
            var player2 = new RandomPlayer();

            var ui = new GameUI();
            var game = new GameLoop(player1, player2);
            var intervals = Intervals();
            intervals.MoveNext();

            ui.Render(game);

            var timer = new Timer
            {
                Interval = 1000
            };
            timer.Tick += (s, e) =>
            {
                if (!game.Step(ui))
                {
                    timer.Stop();
                }
                intervals.MoveNext();
                timer.Interval = intervals.Current;
            };
            timer.Start();

            Application.Run(new Form
            {
                Text = "C# Market Competition",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                Controls = { ui }
            });
        }

        private static IEnumerator<int> Intervals()
        {
            var source = 1000;
            var target = 100;
            var count = 20;

            for (var i = 0; i < count; i++)
            {
                yield return source * (count - i) / count + target * i / count;
            }
            while (true)
            {
                yield return target;
            }
        }
    }
}