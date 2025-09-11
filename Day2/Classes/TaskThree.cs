public class TaskThree
{
    /// <summary>
    /// Password field, we need to check it's length, to verify if it's a strong password or not.
    /// </summary>
    public string? Password;

    public int GetStringLength(string password)
    {
        return password.Length;
    }

    public bool IsPasswordStrong()
    {
        if (Password!.Length <= 25)
        {
            return false;
        }
        return true;
    }
}