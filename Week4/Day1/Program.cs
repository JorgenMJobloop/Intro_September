using Spectre.Console;

namespace Day1;

class Program
{
    static void Main(string[] args)
    {

        var data = DataStorage.Load();
        void InitalizeRooms(AppData data)
        {
            if (data.Rooms.Count == 0)
            {
                data.Rooms.Add(new Rooms { Id = 1, Name = "Room A", Capacity = 6 });
                data.Rooms.Add(new Rooms { Id = 2, Name = "Room B", Capacity = 10 });
                data.Rooms.Add(new Rooms { Id = 3, Name = "Room C", Capacity = 4 });
                data.Rooms.Add(new Rooms { Id = 4, Name = "Conference Room A", Capacity = 20 });
            }
        }
        InitalizeRooms(data);
        //AnsiConsole.Markup($"[green]DEBUG:[/]Number of rooms loaded from database: {data.Rooms.Count}");
        InitalizeAdminUser.InitalizeUserAsAdmin(data);

        // Implement the MVC pattern
        AuthController authController = new AuthController(data);
        BookingController bookingController = new BookingController(data);
        Users? currentUser = null;
        MenuView menuView = new MenuView();
        LoginView loginView = new LoginView();
        BookingView bookingView = new BookingView();
        while (true)
        {
            if (currentUser == null)
            {
                var choice = menuView.ShowMainMenu();

                switch (choice)
                {
                    case 1:
                        var (username, password) = loginView.PromptLogin();
                        var user = authController.Login(username, password);
                        if (user != null)
                        {
                            loginView.ShowLoginSuccess(username);
                            currentUser = user;
                        }
                        else
                        {
                            loginView.ShowFailedLogin();
                        }
                        break;

                    case 2:
                        var (_username, _password) = loginView.PromptLogin();
                        if (authController.Register(_username, _password))
                        {
                            AnsiConsole.MarkupLine("[green]New user registered successfully![/]");
                            DataStorage.Save(data);
                        }
                        else
                        {
                            AnsiConsole.MarkupLine("[red]Username already exists.[/]");
                        }
                        break;
                    case 0:
                        DataStorage.Save(data);
                        AnsiConsole.MarkupLine("[yellow]Exiting...[/]");
                        return;
                }
            }
            else
            {
                var action = menuView.ShowLoggedInMenu(currentUser.Username!, currentUser.IsAdmin);

                switch (action)
                {
                    // Add the case for admin user as action: 99
                    case 99:
                        // this case is ran, when an admin is logged in to the program, otherwise, it is ignored
                        foreach (Users user in data.Users)
                        {
                            AnsiConsole.MarkupLine($"\n[underline]{user.Username}[/]");
                            var bookings = bookingController.GetUserBookings(user);
                            if (bookings.Count == 0)
                            {
                                AnsiConsole.MarkupLine("[grey]No bookings found.[/]");
                            }
                            else
                            {
                                bookingView.ShowBookings(bookings, bookingController.GetRoomById);
                            }
                        }
                        break;
                    case 98:
                        var roomName = AnsiConsole.Ask<string>("Name of the new room:");
                        var capacity = AnsiConsole.Ask<int>("Room capacity:");

                        int nextId = data.Rooms.Any() ? data.Rooms.Max(room => room.Id) + 1 : 1;
                        data.Rooms.Add(new Rooms { Id = nextId, Name = roomName, Capacity = capacity });
                        AnsiConsole.MarkupLine($"[green]New room '{roomName}' has been added to the list of available rooms.[/]");
                        break;
                    case 97:
                        // pick a user to delete, and "prompt" out a menu, using Spectre CLI
                        var userToDelete = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("Pick a user to delete:")
                            .AddChoices<string>(data.Users
                            .Where(usr => !usr.IsAdmin && usr.Username != currentUser.Username)
                            .Select(usr => usr.Username)));

                        if (AnsiConsole.Confirm($"Are you sure you want to delete user: '{userToDelete}'?"))
                        {
                            data.Users.RemoveAll(u => u.Username == userToDelete);
                            AnsiConsole.MarkupLine($"[red]User: '{userToDelete}' has been deleted![/]");
                        }
                        break;
                    case 96:
                        var chooseUserBookingToDelete = AnsiConsole.Prompt(
                            new SelectionPrompt<Users>()
                            .Title("")
                            .UseConverter(u => u.Username!)
                            .AddChoices(data.Users.Where(usr => usr.ListedBookings!.Any() == true).ToList())
                        );

                        var chooseBookingToDelete = AnsiConsole.Prompt(
                            new SelectionPrompt<Bookings>()
                            .Title("")
                            .UseConverter(booking =>
                            {
                                var room = bookingController.GetRoomById(booking.RoomId)?.Name ?? "Unknown room";
                                return $"{booking._DateTime:g} in {room}";
                            })
                            .AddChoices(chooseUserBookingToDelete.ListedBookings!)
                        );
                        if (AnsiConsole.Confirm("Are you sure you want to delete this booking?"))
                        {
                            chooseUserBookingToDelete.ListedBookings!.Remove(chooseBookingToDelete);
                            AnsiConsole.MarkupLine("[red]Booking deleted.[/]");
                        }
                        break;
                    case 1:
                        var _dateTime = bookingView.PromptForDayTime();
                        var available = bookingController.GetAvailableRooms(_dateTime);
                        if (available.Count == 0)
                        {
                            bookingView.ShowError("No rooms available!");
                            break;
                        }
                        var roomId = bookingView.ChooseRoom(available);
                        if (bookingController.BookRoom(currentUser, roomId, _dateTime))
                        {
                            bookingView.ShowSuccess("New booking registered!");
                        }
                        else
                        {
                            bookingView.ShowError("Failed to create new booking!");
                        }
                        break;
                    case 2:
                        var _booking = bookingController.GetUserBookings(currentUser);
                        bookingView.ShowBookings(_booking, bookingController.GetRoomById);
                        break;
                    case 3:
                        var cancelDateTime = bookingView.PromptForDayTime();
                        if (bookingController.CancelBookings(currentUser, cancelDateTime))
                        {
                            bookingView.ShowSuccess("Booking canceled!");
                        }
                        else
                        {
                            bookingView.ShowError("Could not find booking!");
                        }
                        break;
                    case 0:
                        currentUser = null!;
                        return;
                }

                DataStorage.Save(data);
                AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
                Console.ReadKey();
                AnsiConsole.Clear();
            }
        }
    }
}