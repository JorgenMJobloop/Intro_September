using BCrypt;
public static class PasswordHasher
{
    public static string PasswordSaltAndHasher(string input)
    {
        return BCrypt.Net.BCrypt.HashPassword(input);
    }
}