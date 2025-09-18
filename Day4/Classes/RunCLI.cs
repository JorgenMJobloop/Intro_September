using System.Text.Json;

public class RunCLI
{
    private List<User>? _users;

    /// <summary>
    /// The main Login method, used to log-in an existing user.
    /// </summary>
    public void Login()
    {
        // Get the username
        Console.WriteLine("Enter username:");
        string username = Console.ReadLine()!;

        // Get the password
        Console.WriteLine("Enter password:");
        string password = Console.ReadLine()!;

        // We can use the List.Find() method, to "append" the username & password to our .json file
        var user = _users!.Find(u => u.Username == username && u.Password == password);

        if (user == null)
        {
            Console.WriteLine("Wrong username or password entered..");
            return;
        }

        Console.WriteLine($"Welcome, {user.Username}");
    }

    private void CreateFile(string filePath)
    {
        File.Create(filePath);
    }

    /// <summary>
    /// Update the JSON file containing the usernames & passwords.
    /// </summary>
    /// <param name="filePath">The path to the .json file</param>
    public void LoadUsers(string filePath)
    {
        if (!File.Exists(filePath))
        {
            CreateFile(filePath);
            Console.WriteLine("No userfile was found.\nCreating new user file..");
            var user = CreateUser();
            _users = new List<User> { user };
            SaveUserToFile(filePath);
            Console.WriteLine("The userfile was successfully created\nNew user has been saved to the document.");
            return;
        }

        try
        {
            string readJSON = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(readJSON))
            {
                Console.WriteLine("The userfile is currently empty!\nCreated a new user..");
                var user = CreateUser();
                _users = new List<User> { user };

                SaveUserToFile(filePath);
                Console.WriteLine("A new user was added to the user document!");
            }
            else
            {
                _users = JsonSerializer.Deserialize<List<User>>(readJSON);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occured when attempting to read the credentials file: {e.Message}");
            return;
        }
    }

    /// <summary>
    /// Create a new user in the CLI
    /// </summary>
    /// <returns>A new user</returns>
    private User CreateUser()
    {
        Console.WriteLine("Create new user");
        Console.WriteLine("Username:");
        string username = Console.ReadLine()!;

        Console.WriteLine("Password:");
        string password = Console.ReadLine()!;

        var user = new User
        {
            Username = username,
            Password = password
        };

        return user;
    }
    /// <summary>
    /// Save a new user to the users.json file
    /// </summary>
    /// <param name="filePath">The filepath of our users.json file</param>
    private void SaveUserToFile(string filePath)
    {
        try
        {
            var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            string jsonContent = JsonSerializer.Serialize(_users, jsonOptions);
            File.WriteAllText(filePath, jsonContent);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Could not save these changes to the user file: {e.Message}");
        }
    }
}