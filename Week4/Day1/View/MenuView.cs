using Spectre.Console;
public class MenuView
{

    public int ShowLoggedInMenu(string username)
    {
        AnsiConsole.MarkupLine($"[blue]Logged in as:[/] [bold]{username}[/]");
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Choose an action")
            .AddChoices(new[] {
                "Book room","View bookings","Cancel booking", "log out"
            }));

        return choice switch
        {
            "Book room" => 1,
            "View bookings" => 2,
            "Cancel booking" => 3,
            _ => 0
        };
    }

    public int ShowMainMenu()
    {
        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("[bold green]Welcome to the Meeting Booking CLI[/]");

        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("What would you like to do?")
                .AddChoices(new[]{
                    "Log in","Register new user","Exit"
                }));

        return choice switch
        {
            "Log in" => 1,
            "Register new user" => 2,
            _ => 0
        };
    }
}