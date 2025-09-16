namespace Lesson3;

class Program
{
    static void Main(string[] args)
    {
        // Static class examples
        Console.WriteLine(Calculator.Add(5, 3));
        Console.WriteLine(Calculator.Divide(3, 3));
        double sum = Calculator.Multiply(25, 2);
        Console.WriteLine($"The sum is: {sum}");

        Console.WriteLine("@@@@@@@@@@@@\nEnd of static class examples.\n@@@@@@@@@@@@");

        Datastructures datastructures = new Datastructures();

        datastructures.shoppingList = ["Bread", "Milk", "Coffee"];
        Console.WriteLine(string.Join(", ", datastructures.shoppingList));

        datastructures.videoGames = ["Metal Gear Solid", "World Of Warcraft", "Tomb Raider", "Tony Hawk's Pro Skater 1"];
        datastructures.PrintListContent();

        datastructures.gameConsoles = new Dictionary<string, string[]>()
        {
           {"Playstation", ["One", "Two", "Three","Four", "Five"] },
            {"Xbox", ["Xbox", "360", "One", "One X", "One S"]}
        };
        datastructures.PrintGameConsoles();


        // Object-instanciation examples
        VideoGames videoGames = new VideoGames("Metal Gear Solid 1", 1998, 9, 18, false);
        Console.WriteLine($"Title: {videoGames.Title}\nRelease year: {videoGames.ReleaseYear}\nRating: {videoGames.Rating}\nParental Guidance: {videoGames.ParentalGuidance}\nSupports multiplayer online: {videoGames.IsMultiplayer}");


        // IO & strings in the Console
        ReadTextFile readTextFile = new ReadTextFile();
        readTextFile.ReadFileContent("mgs.txt");
        readTextFile.ReadFileContent("placeholder.txt");

        // DateTime example
        // Print the date today using System.Globalization
        DateTime date = DateTime.Today;
        Console.WriteLine(date.ToLongDateString());
    }
}
