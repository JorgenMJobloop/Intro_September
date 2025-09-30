using Spectre.Console;

public class AuthController
{
    private readonly AppData appData;

    public AuthController(AppData data)
    {
        appData = data;
    }

    // Expose a model to the controller
    public Users Login(string username, string password)
    {
        var user = appData.Users.FirstOrDefault(usr => usr.Username == username);
        if (user == null)
        {
            AnsiConsole.MarkupLine($"[red]ERROR:[/]Could not find user: {username}");
            return null!;
        }

        var inputHash = PasswordHasher.PasswordSaltAndHasher(password);
        // AnsiConsole.MarkupLine($"[green]DEBUG:[/]Username = {username}");
        // AnsiConsole.MarkupLine($"[green]DEBUG:[/]Input hash = {inputHash}");
        // AnsiConsole.MarkupLine($"[green]DEBUG:[/]Saved hash = {user.PasswordHash}");

        if (PasswordHasher.Verify(password, user.PasswordHash!))
        {
            return user;
        }
        AnsiConsole.MarkupLine($"[yellow]WARN:[/]The hashes does not match!");
        return null!;
    }

    public bool Register(string username, string password)
    {
        if (appData.Users.Any(usr => usr.Username == username))
        {
            return false;
        }

        // We "populate" the user-list
        var user = new Users
        {
            Username = username,
            PasswordHash = PasswordHasher.PasswordSaltAndHasher(password)
        };

        // Add the user to the user-list
        appData.Users.Add(user);
        return true;
    }
}