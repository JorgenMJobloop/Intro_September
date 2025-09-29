using Spectre.Console;
public class BookingView
{
    /// <summary>
    /// Prompt the user for input on which date & when they want to schedule a booking.
    /// </summary>
    /// <returns>DateTime</returns>
    public DateTime PromptForDayTime()
    {
        var date = AnsiConsole.Ask<string>("Enter date ([green]2025-10-01[/]):");
        var time = AnsiConsole.Ask<string>("Enter time of day ([green]14:00[/]):");

        return DateTime.Parse($"{date} {time}");
    }
    /// <summary>
    /// Lets the user choose a room to book.
    /// </summary>
    /// <param name="availableRooms">Number of rooms available</param>
    /// <returns>int</returns>
    public int ChooseRoom(List<Rooms> availableRooms)
    {
        var room = AnsiConsole.Prompt(
            new SelectionPrompt<Rooms>()
            .Title("Pick a available room to book:")
            .UseConverter(r => $"{r.Name} (Capacity: {r.Capacity})")
            .AddChoices(availableRooms)
        );

        return room.Id;
    }

    public void ShowBookings(List<Bookings> bookings, Func<int, Rooms?> getRoom)
    {
        var table = new Table();
        table.AddColumn("Date & Time");
        table.AddColumn("Room");

        foreach (var booking in bookings)
        {
            var room = getRoom(booking.RoomId);
            table.AddRow(booking._DateTime.ToString("g"), room!.Name! ?? "Unknown");
        }

        AnsiConsole.Write(table);
    }

    public void ShowSuccess(string message)
    {
        AnsiConsole.MarkupLine($"[green]{message}[/]");
    }

    public void ShowError(string message)
    {
        AnsiConsole.MarkupLine($"[red]{message}[/]");
    }
}