using Spectre.Console;

public static class InitalizeAdminUser
{
    public static void InitalizeUserAsAdmin(AppData data)
    {
        const string adminUsername = "admin"; // Default admin username

        if (!data.Users.Any(usr => usr.Username == adminUsername))
        {
            data.Users.Add(new Users
            {
                Username = adminUsername,
                PasswordHash = PasswordHasher.PasswordSaltAndHasher("admin123"), // For testing purposes, we use this insecure password
                IsAdmin = true
            });
        }

        AnsiConsole.MarkupLine("[green]Admin user has been created, with username: admin[/]");
    }
}