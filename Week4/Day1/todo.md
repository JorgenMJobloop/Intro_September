# Structure

```sh
/MeetingRoomBooking/
│
├── Models/
│   ├── Users.cs
│   ├── Bookings.cs
│   └── Rooms.cs
│
├── Views/
│   ├── MenuView.cs
│   ├── LoginView.cs
│   └── BookingView.cs
│
├── Controllers/
│   ├── AuthController.cs
│   ├── BookingController.cs
│   └── RoomController.cs
│
├── Data/
│   ├── DataStorage.cs    
│
├── Program.cs
```

# Implement
    ## Models
        - Users
        - Bookings
        - Rooms
    ## Views
        - MenuView
        - LoginView
        - BookingView     
    ## Controllers
        - AuthController
        - BookingController
        - RoomController
    ## Data
        - DataStorage
    ### Services
        # Security    
            - HashPasswords
            -> Bcrypt (to automatically salt the passwords, rather than a one-way direct SHA256 hash(less secure))
            
## TODO
### Add support Admin mode
### Add all available choices in the CLI
### 


```sh
dotnet add package BCrypt.Net-Next --version 4.0.3

dotnet add package Spectre.Console

dotnet add package Spectre.Console.Cli
```