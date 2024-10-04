namespace Text_Adventure;
using Text_Adventure;

internal class MainProgram
{

    static void Main(string[] args)
    {
        Console.WriteLine("Pokemon Battle");
        string[] deck =
        {
             new FireType("charmander",60),
             new FireType("Rapidash", 90),
             new FireType("flaryon", 30),
             new WaterType("Squirtle", 100),
             new WaterType("Garydos", 100),
             new WaterType("Tentacool", 100),
             new GrassType("Bulbasaur", 60),
             new GrassType("Oddish", 40),
             new GrassType("Bellsprout", 40)
            };
        string User = new PlayerCharacter("player");
        string opponet = new Computer("computer");



    }
}

