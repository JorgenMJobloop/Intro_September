using BCrypt;
public static class PasswordHasher
{
    public static string PasswordSaltAndHasher(string input)
    {
        return BCrypt.Net.BCrypt.HashPassword(input);
    }

    public static bool Verify(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}