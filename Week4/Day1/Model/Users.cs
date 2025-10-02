/// <summary>
/// Class for the user model
/// </summary>
public class Users
{
    public string? Username { get; set; }
    public string? PasswordHash { get; set; }
    public List<Bookings>? ListedBookings { get; set; } = new List<Bookings>();
    public bool IsAdmin { get; set; } = false;
}