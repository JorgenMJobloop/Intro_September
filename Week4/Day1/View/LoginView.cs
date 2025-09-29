using Spectre.Console;
public class LoginView
{
    // Tuple method, more than one type-signature
    /// <summary>
    /// Promp a login in the CLI
    /// </summary>
    /// <returns>string,string</returns>
    public (string Username, string Password) PromptLogin()
    {
        var username = AnsiConsole.Ask<string>("Enter [green]username[/]:");
        var password = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter [red]password[/]:")
                .PromptStyle("red")
                .Secret()
        );
        return (username, password);
    }
    /// <summary>
    /// Show a successful login screen in the CLI
    /// </summary>
    /// <param name="username">username</param>
    public void ShowLoginSuccess(string username)
    {
        AnsiConsole.MarkupLine($"[green]Logged in as:[/] {username}");
    }
    /// <summary>
    /// Show a unsuccessful login screen in the CLI
    /// </summary>
    public void ShowFailedLogin()
    {
        AnsiConsole.MarkupLine("[red]Wrong username or password![/]");
    }
}