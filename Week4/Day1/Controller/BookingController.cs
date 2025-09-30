public class BookingController
{
    private readonly AppData appData;

    public BookingController(AppData data)
    {
        appData = data;
    }

    public List<Rooms> GetAvailableRooms(DateTime dateTime)
    {

        if (appData.Rooms == null)
        {
            throw new NullReferenceException("List of available rooms cannot be null");
        }

        if (appData.Users == null)
        {
            return appData.Rooms.ToList();
        }

        var bookedRoomsIds = appData.Users
            .Where(u => u.ListedBookings != null)
            .SelectMany(u => u.ListedBookings!)
            .Where(b => b._DateTime == dateTime)
            .Select(b => b.RoomId)
            .ToHashSet();

        return appData.Rooms
        .Where(room => !bookedRoomsIds.Contains(room.Id))
        .ToList();
    }

    public bool BookRoom(Users user, int roomId, DateTime dateTime)
    {
        if (user.ListedBookings!.Any(b => b._DateTime == dateTime))
        {
            return false; // this if-statement checks if a user has a room already booked, at this time.
        }

        if (appData.Users.SelectMany(usr => usr.ListedBookings!).Any(booking => booking.RoomId == roomId && booking._DateTime == dateTime))
        {
            return false; // this if-statement checks if a room is already booked.
        }

        // we can create a new booking on this line, if both of the if-statements above are true.
        user.ListedBookings!.Add(new Bookings { RoomId = roomId, _DateTime = dateTime });
        return true;
    }

    public bool CancelBookings(Users user, DateTime dateTime)
    {
        var booking = user.ListedBookings!.FirstOrDefault(b => b._DateTime == dateTime);
        if (booking == null)
        {
            return false;
        }

        user.ListedBookings!.Remove(booking);
        return true;
    }

    public List<Bookings> GetUserBookings(Users user)
    {
        return user.ListedBookings!.OrderBy(booking => booking._DateTime).ToList();
    }

    public Rooms? GetRoomById(int id)
    {
        return appData.Rooms.FirstOrDefault(room => room.Id == id);
    }
}