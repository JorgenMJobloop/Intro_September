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
            return null!;
        }

        if (user.PasswordHash == PasswordHasher.PasswordSaltAndHasher(password))
        {
            return user;
        }
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