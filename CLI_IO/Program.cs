using Spectre.Console.Cli;

namespace Day3;

class Program
{
    static void Main(string[] args)
    {
        LsCommand lsCommand = new LsCommand(args[0]);
        lsCommand.Ls();

        ImageGlitchEffect imageGlitchEffect = new ImageGlitchEffect("kyoto.jpeg", "output2_kyoto.jpeg", 8);
        imageGlitchEffect.ApplyEffect();
    }
}
