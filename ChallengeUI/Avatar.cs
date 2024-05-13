using CsMarketChallenge;
using SkiaSharp;
using Svg.Skia;

namespace ChallengeUI
{
    public class Avatar : IDisposable
    {
        private static readonly string Template = File.ReadAllText("Assets/avataaars.txt");
        private static readonly string[] Tops = File.ReadAllText("Assets/top.txt").Split("\n\n\n", StringSplitOptions.RemoveEmptyEntries);
        private static readonly string[] Clothes = File.ReadAllText("Assets/clothes.txt").Split("\n\n\n", StringSplitOptions.RemoveEmptyEntries);
        private static readonly string[] Eyebrows = File.ReadAllText("Assets/eyebrows.txt").Split("\n\n\n", StringSplitOptions.RemoveEmptyEntries);
        private static readonly string[] EyesHappy = File.ReadAllText("Assets/eyes-happy.txt").Split("\n\n\n", StringSplitOptions.RemoveEmptyEntries);
        private static readonly string[] EyesSad = File.ReadAllText("Assets/eyes-sad.txt").Split("\n\n\n", StringSplitOptions.RemoveEmptyEntries);
        private static readonly string[] MouthHappy = File.ReadAllText("Assets/mouth-happy.txt").Split("\n\n\n", StringSplitOptions.RemoveEmptyEntries);
        private static readonly string[] MouthSad = File.ReadAllText("Assets/mouth-sad.txt").Split("\n\n\n", StringSplitOptions.RemoveEmptyEntries);

        private const string ClothesColor = "#3C4F5C";
        private const string SkinColor = "#EDB98A";
        private const string HairColor = "#4A312C";

        private readonly Image happy;
        private readonly Image sad;

        public Avatar(IPlayer player)
        {
            var hash = player.GetHashCode();
            happy = CreateImage(hash, true);
            sad = CreateImage(hash, false);
        }

        public void Dispose()
        {
            happy.Dispose();
            sad.Dispose();
        }

        public Image GetImage(bool isHappy)
        {
            return isHappy ? happy : sad;
        }

        private static Image CreateImage(int seed, bool isHappy)
        {
            seed = seed < 0 ? -seed : seed;

            var Eyes = isHappy ? EyesHappy : EyesSad;
            var Mouth = isHappy ? MouthHappy : MouthSad;

            var t = Tops.Length;
            var c = Clothes.Length;
            var b = Eyebrows.Length;
            var e = Eyes.Length;
            var m = Mouth.Length;

            var top = Tops[seed % t];
            var clothes = Clothes[seed / t % c];
            var eyebrows = Eyebrows[seed / t / c % b];
            var eyes = Eyes[seed / t / c / b % e];
            var mouth = Mouth[seed / t / c / b / e % m];

            var data = Template
                .Replace("<!-- TOP -->", top)
                .Replace("<!-- CLOTHES -->", clothes)
                .Replace("<!-- EYEBROW -->", eyebrows)
                .Replace("<!-- EYES -->", eyes)
                .Replace("<!-- MOUTH -->", mouth)
                .Replace("var(--avataaar-skin-color)", SkinColor)
                .Replace("var(--avataaar-hair-color)", HairColor)
                .Replace("var(--avataaar-shirt-color)", ClothesColor);

            using var svg = SKSvg.CreateFromSvg(data);
            using var memory = new MemoryStream();

            svg.Save(memory, SKColors.Empty);
            memory.Position = 0;
            return Image.FromStream(memory);
        }
    }
}
