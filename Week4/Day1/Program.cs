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
            }
        }
        InitalizeRooms(data);

        // Implement the MVC pattern
        AuthController authController = new AuthController(data);
        BookingController bookingController = new BookingController(data);
        Users? currentUser = null!;
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
                        }
                        else
                        {
                            AnsiConsole.MarkupLine("[red]Username already exists.[/]");
                        }
                        break;
                    case 0:
                        DataStorage.Save(data);
                        return;
                }

            }
            else
            {
                var action = menuView.ShowLoggedInMenu(currentUser.Username!);

                switch (action)
                {
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
