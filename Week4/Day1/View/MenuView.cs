using Spectre.Console;
public class MenuView
{
    public int ShowLoggedInMenu(string username, bool isAdmin)
    {

        var options = new List<string>()
        {
            "Book room", "View bookings", "Cancel booking", "Log out"
        };

        if (isAdmin.Equals(true))
        {
            options.InsertRange
            (0, new[]
            {
                "View all bookings",
                "Add new meeting room",
                "Delete a user",
                "Delete a booking"
            });
        }

        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Choose an action")
            .AddChoices(options));

        return choice switch
        {
            // Admin specific choices
            "View all bookings" => 99,
            "Add new meeting room" => 98,
            "Delete a user" => 97,
            "Delete a booking" => 96,
            // Choices that applies to all users.
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