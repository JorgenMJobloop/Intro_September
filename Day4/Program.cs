namespace CLI;

class Program
{
    static void Main(string[] args)
    {
        var cli = new RunCLI();
        cli.LoadUsers("users.json");
        cli.Login();
    }
}
