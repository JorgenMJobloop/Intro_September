public class Datastructures
{
    public string[]? shoppingList;
    public List<string>? videoGames;
    public Dictionary<string, string[]>? gameConsoles;

    public void PrintListContent()
    {
        foreach (string games in videoGames!)
        {
            Console.WriteLine(games);
        }
    }

    public void PrintGameConsoles()
    {
        foreach (var consoles in gameConsoles!)
        {
            string console = consoles.Key;
            string[] generations = consoles.Value;
            Console.WriteLine($"Console: {console}");
            Console.WriteLine($"Generations: {string.Join(", ", generations)}");
        }
    }
}