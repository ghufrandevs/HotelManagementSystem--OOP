using System.Runtime.CompilerServices;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelManagementSystem__OOP
{
    
    
    internal class Program
    {
        public static void ShowMenue()
        {
            Console.WriteLine("Hello to Hotel Management System ");
            Console.WriteLine("Select the option :");
            Console.WriteLine("1.Add Guest");
            Console.WriteLine("2.Add Room");
            Console.WriteLine("3.Book a Room");
            Console.WriteLine("4.Cancel a Booking");
            Console.WriteLine("5.Display All Available Rooms");
            Console.WriteLine("6.Display All Booked Rooms");
            Console.WriteLine("7.Search Guest by National ID");
            Console.WriteLine("8.Show Hotel Statistics");
            Console.WriteLine("9.Display Available Rooms By Type");
            Console.WriteLine("10.Display All Guests");
            Console.WriteLine("11.Most Expensive Active Booking");
            Console.WriteLine("12.Guest Booking Counter");
            Console.WriteLine("0.Exit");

        }
        public static void DisplayAvailableRoomsByType(Hotel hotel)
        {
            Console.WriteLine("Enter the Room Type: (Standard, Deluxe, Suite): ");
            string type = (Console.ReadLine() ?? string.Empty).Trim();
            while (string.IsNullOrWhiteSpace(type))
            {
                Console.WriteLine("Type cannot be empty. Please re-enter:");
                type = (Console.ReadLine() ?? string.Empty).Trim();
            }
            hotel.DisplayAvailableRoomsByType(type);
        }
        public static void AddGuest(Hotel hotel)
        {
            Console.WriteLine("Enter the Name: ");
            string name = (Console.ReadLine() ?? string.Empty).Trim();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty. Please re-enter:");
                name = (Console.ReadLine() ?? string.Empty).Trim();
            }

            Console.WriteLine("Enter national ID: ");
            string ID = (Console.ReadLine() ?? string.Empty).Trim();
            while (string.IsNullOrWhiteSpace(ID))
            {
                Console.WriteLine("ID cannot be empty. Please re-enter:");
                ID = (Console.ReadLine() ?? string.Empty).Trim();
            }
            hotel.AddGuest(name, ID);

        }
        public static void AddRoom(Hotel hotel)
        {
            Console.WriteLine("Enter Room number :");
            int roomNumber;
            while (!int.TryParse(Console.ReadLine(), out roomNumber))
            {
                Console.WriteLine("Invalid input. Please enter a valid number:");
            }
            Console.WriteLine("Enter room type:");
            string type = (Console.ReadLine() ?? string.Empty).Trim();

            while (string.IsNullOrWhiteSpace(type))
            {
                Console.WriteLine("Room type cannot be empty. Please re-enter:");
                type = (Console.ReadLine() ?? string.Empty).Trim();
            }

            Console.WriteLine("Enter nightly rate:");
            decimal rate;
            while (!decimal.TryParse(Console.ReadLine(), out rate) || rate <= 0)
            {
                Console.WriteLine("Invalid rate. Try again");
            }
            hotel.AddRoom(roomNumber, type,rate );
        }
        public static void BookRoom(Hotel hotel)
        {
            Console.WriteLine("Enter national Id :");
            string nationalID = (Console.ReadLine() ?? string.Empty).Trim();

            while (string.IsNullOrWhiteSpace(nationalID))
            {
                Console.WriteLine("ID cannot be empty. Please re-enter:");
                nationalID = (Console.ReadLine() ?? string.Empty).Trim();
            }

            Console.WriteLine("Enter Room number :");
            int RoomNumber;
            while (!int.TryParse(Console.ReadLine(), out RoomNumber))
            {
                Console.WriteLine("Invalid number. Please enter a valid room number:");
            }

            Console.WriteLine("Enter number of nights: ");
            int nights;
            while(!int.TryParse(Console.ReadLine(), out nights) || nights <= 0)
{
                Console.WriteLine("Invalid nights. Enter a positive number:");
            }

            hotel.BookRoom(nationalID, RoomNumber,nights);
        }
        public static void CancelBooking(Hotel hotel)
        {
            Console.WriteLine("Enter Booking Id ");
            int bookingId;
            while (!int.TryParse(Console.ReadLine(), out bookingId))
            {
                Console.WriteLine("Invalid number. Please enter a valid booking id :");
            }
            hotel.CancelBooking(bookingId) ;
        }
        public static void DisplayAvailableRooms(Hotel hotel)
        {
            hotel.DisplayAvailableRooms() ;
        }
        public static void DisplayBookedRooms(Hotel hotel)
        {
            hotel.DisplayBookedRooms() ;
        }
        public static void SearchGuestID(Hotel hotel)
        {
            Console.WriteLine("Enter national ID:");

            string id = (Console.ReadLine() ?? string.Empty).Trim();

            while (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("ID cannot be empty. Please re-enter:");
                id = (Console.ReadLine() ?? string.Empty).Trim();
            }

            hotel.SearchGuestBookings(id);
        }
        public static void ShowHotelStatistics(Hotel hotel)
        {
            hotel.DisplayStatistics() ;
        }
        public static void DisplayAllGuests(Hotel hotel)
        {
            hotel.DisplayAllGuests();
        }

        public static void FindMostExpensiveBooking(Hotel hotel)
        {
            hotel.FindMostExpensiveBooking();
        }

        public static void ShowGuestBookingCount(Hotel hotel)
        {
            Console.WriteLine("Enter National ID: ");
            string id = (Console.ReadLine() ?? "").Trim();

            while (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("ID cannot be empty. Try again:");
                id = (Console.ReadLine() ?? "").Trim();
            }
            Guest guest=hotel.FindGuest(id);
            if (guest == null)
            {
                Console.WriteLine("Guest not found.");
                return;
            }

            guest.DisplayInfo();
            Console.WriteLine($"Total bookings ever made: {guest.TotalBookingsMade}");
        }
        

        public static bool ExitSystem()
        {
            Console.WriteLine("Are you sure you want to exit the system? (yes/no)");
            string inputs = (Console.ReadLine() ?? string.Empty).ToLower();
            if(inputs=="no")
            {
                return false;
            }
            else if(inputs=="yes")
            {
                Console.WriteLine("Thank you for using the system --Exit--");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid option");
                return false;
            }
        }
        static void Main(string[] args)
        {
            int option = 0;
            bool exit = false;
            Hotel hotel = new Hotel();
            while (!exit)
            {
                ShowMenue();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please choose a number from 0 to 12");
                    continue;
                }
                switch(option)
                {
                    case 1:
                        AddGuest(hotel);
                        break;

                        case 2:
                        AddRoom(hotel);
                        break;

                        case 3:
                        BookRoom(hotel);
                        break;

                        case 4:
                        CancelBooking(hotel);
                        break;

                        case 5:
                        DisplayAvailableRooms(hotel);
                        break;

                        case 6:
                        DisplayBookedRooms(hotel);
                        break;

                        case 7:
                        SearchGuestID(hotel);
                        break;

                        case 8:
                        ShowHotelStatistics(hotel);
                        break;

                        case 9:
                        DisplayAvailableRoomsByType(hotel);
                        break;

                        case 10:
                        DisplayAllGuests(hotel);
                        break;

                        case 11:
                        FindMostExpensiveBooking(hotel);
                        break;

                        case 12:
                        ShowGuestBookingCount(hotel);
                        break;

                        case 0:
                        exit = ExitSystem();
                        break;
                }
                if (!exit)
                {
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
    class Hotel
    {
        static List<Guest> Guests=new List<Guest>();
        static List<Room> Rooms=new List<Room>();
        static List<Booking> Bookings=new List<Booking>();
        private string hotelName;
        private bool IsValidType(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                return false;
            }

            string t = type.Trim().ToLower();

            return t == "standard" || t == "deluxe" || t == "suite";
        }
        private string NormalizeType(string type)
        {
            string t=type.Trim().ToLower();
            if(t== "standard") return "Standard";
            if (t == "deluxe") return "Deluxe";
            if (t == "suite") return "Suite";
            return type;
        }
        public string HotelName
        {
            get { return hotelName; }
        }
        public void AddGuest(string name, string id)
        {
            foreach(var g in Guests)
            {
                if(g.NationalID==id)
                {
                    Console.WriteLine("Guest with this ID already exists");
                    return;
                }
                
            }
            //  create new guest
            Guest newGuest=new Guest(name,id);
            if(newGuest.FullName==null)
            {
                return;
            }
            //add to list
            Guests.Add(newGuest);
            Console.WriteLine("Guest added successfully.");
        }
        public Guest FindGuest(string nationalID)
        {
           Guest result=Guests.Find((g => g.NationalID == nationalID));
            if(result!=null)
            {
                return result;
            }
            return null;
        }
        public void AddRoom(int number, string type,decimal rate)
        {
            foreach (var r in Rooms)
            {
                if(r.RoomNumber==number)
                {
                    Console.WriteLine("Room with this number already exists");
                    return;
                }
            }
            if(!IsValidType(type))
            {
                Console.WriteLine("Invalid room type. Allowed: Standard, Deluxe, Suite.");
                return;
            }
            string normalizedType = NormalizeType(type);

            Rooms.Add(new Room(number, normalizedType, rate));
            Console.WriteLine("Room added successfully");

        }
        public void DisplayAvailableRooms()
        {
            bool found = false;
            foreach (var R in Rooms)
            {
                if (!R.IsBooked )
                {
                    R.DisplayInfo();
                    Console.WriteLine("-----------------------------------------------------");
                    found = true;
                }
            }
            if(!found)
            {
                Console.WriteLine("No available rooms.");

            }
        }
        public void DisplayBookedRooms()
        {
            bool found = false;
            foreach(var R  in Rooms)
            {
                if(R.IsBooked )
                {
                    R.DisplayInfo();
                    Console.WriteLine("---------------------------------------------------");
                    found = true;
                }
            }
            if(!found)
            {
                Console.WriteLine("No booked rooms available.");

            }
        }

        public void BookRoom(string nationalID, int roomNumber,int nights)
        {
            Guest guest=FindGuest(nationalID);
            if(guest == null)
            {
                Console.WriteLine("Guest not found");
                return;
            }
            Room room = Rooms.Find(r => r.RoomNumber == roomNumber);
                if (room==null)
            {
                Console.WriteLine("Room not found");
                return; 
            }
                //book a room
                if(!room.Book())
            {
                Console.WriteLine("Room is already booked");
                return;
            }
            Bookings.Add(new Booking(guest, room,nights));
            guest.IncrementBookingCount();
            Console.WriteLine("Booking successful.");

        }
        
        public void CancelBooking(int bookingID)
        {
           Booking book=Bookings.Find(b => b.BookingID == bookingID);
            if(book==null)
            {
                Console.WriteLine("the Booking Id is not found");
                return;
            }
            Console.WriteLine("----- Booking Summary -----");
            Console.WriteLine($"Guest name : { book.Guest.FullName}");
            Console.WriteLine($"Room number: {book.Room.RoomNumber}");
            Console.WriteLine($"Nights Stayed: {book.Nights}");
            Console.WriteLine($"Total Cost: {book.TotalCost:F3} OMR");
            Console.WriteLine("----------------------------");

            book.Room.CancelBooking();
            Bookings.RemoveAll(b => b.BookingID == bookingID);
            Console.WriteLine("Booking cancelled successfully.");
        }
        public void SearchGuestBookings(string nationalID)
        {
            Guest guest=FindGuest(nationalID);
            if( guest==null)
            {
                Console.WriteLine("Guest not found");
                return;
            }
            bool found=false;
            foreach (var b in Bookings)
            {
                if(b.Guest.NationalID==nationalID)
                {
                    b.DisplayInfo();
                    found=true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No bookings found for this guest.");
            }
        }
        public void DisplayStatistics()
        {
            int totalGuest = Guests.Count;
            int totalRoom = Rooms.Count;
            int bookRoom = 0;
            int availableRoom = 0;
            decimal totalRevenue = 0;
            decimal avgCost = 0;

            foreach (var bRoom in Rooms )
            {
                if(bRoom.IsBooked==true)
                {
                    bookRoom++;
                }
            }
            foreach(var b in Bookings)
            {
                totalRevenue += b.TotalCost;
            }
            if (Bookings.Count > 0)
            {
                avgCost = totalRevenue / Bookings.Count;
            }    
            availableRoom = totalRoom - bookRoom;
            int totalGuestsCreated = Guest.GetTotalGuestsCreated();
            Console.WriteLine("totalGuest :" + totalGuest);
            Console.WriteLine("totalRoom : " + totalRoom);
            Console.WriteLine("bookRoom : " + bookRoom);
            Console.WriteLine("availableRoom : " + availableRoom);
            Console.WriteLine($"Total Revenue: {totalRevenue:F3} OMR");
            Console.WriteLine($"Avg Cost/Booking: {avgCost:F3} OMR");
            Console.WriteLine($"Total guests ever created: {Guest.GetTotalGuestsCreated()}");

        }

        public void DisplayAvailableRoomsByType(string type)
        {
            bool found=false;
            foreach(var Room in Rooms )
            {
                if (!Room.IsBooked &&
            string.Equals(Room.RoomType, type, StringComparison.OrdinalIgnoreCase))
                {
                    Room.DisplayInfo();
                    Console.WriteLine("========================================");
                    found = true;

                }
            }
            if (!found)
            {
                Console.WriteLine("No available rooms found for this type.");
            }
        }

        public void DisplayAllGuests()
        {
           if(Guests.Count==0)
            {
                Console.WriteLine("No guests registered");
                return;
            }
            Console.WriteLine("=====Guest list=====");
            foreach(var G in Guests)
            {
                G.DisplayInfo();
                Console.WriteLine("--------------------------------------");
            }
            Console.WriteLine($"Total registered guests: {Guests.Count}");

        }

        public void FindMostExpensiveBooking()
        {
            Booking max=null;
            foreach(var b in Bookings)
            {
                if (max == null || b.TotalCost > max.TotalCost)
                {
                    max = b;
                }

            }
            if(max != null)
            {
                max.DisplayInfo();
            }
            else
            {
                Console.WriteLine("No active bookings.");
 
            }
        }
    }
    class Guest
    {
        private static int totalGuestsCreated;
        private string nationalID;
        private string fullName;
        private int totalBookingsMade = 0;
        public int TotalBookingsMade
        {
            get { return totalBookingsMade; }
        }

        public string NationalID
        {
            get { return nationalID; } 
        }
        public string FullName
        {
            get { return fullName; } 
            set
            {
                if(string.IsNullOrWhiteSpace(value) || value.Trim().Length < 3)
                {
                    Console.WriteLine("Name must be at least 3 chars ");
                    return;
                }
                fullName = value;
            }
        }
        public Guest(string name, string id)
        {
             FullName=name;
            nationalID = id;
            totalGuestsCreated++;
        }
        public static int GetTotalGuestsCreated()
        {
            return totalGuestsCreated;
        }
        public void DisplayInfo()
        {
            Console.WriteLine("guest name : " + FullName);
            Console.WriteLine("ID : " + NationalID);
        }
        public void IncrementBookingCount()
        {
            totalBookingsMade++;
        }
    }
    class Room
    {
        private int roomNumber;
        private string roomType;
        private bool isBooked;
        private decimal nightlyRate;

        public int RoomNumber
        {
            get { return roomNumber; }
        }
        public string RoomType
        {
            get { return roomType; } 
        }
        public bool IsBooked
        {
            get { return isBooked; } 
        }
        public decimal NightlyRate
        {
            get { return nightlyRate; }
        }
        public Room(int number, string type, decimal rate)
        {
            roomNumber = number;
            roomType = type;
            isBooked = false ;
            nightlyRate = rate;

        }
        public bool Book()
        {
            if(isBooked==true)
            {
                //already booked
                return false;

            }
               //booking successful
               isBooked=true;
                return true;                
        }
        public void CancelBooking()
        {
            //available 
            isBooked=false;
        }
        public void DisplayInfo()
        {
            //Prints room number, type, and availability status.
            Console.WriteLine("Room number : " + RoomNumber); 
            Console.WriteLine("Room Type : " + RoomType);
            // if (IsBooked == true) → "No"
            // else → "Yes"
            Console.WriteLine("Available: " + (IsBooked ? "No" : "Yes"));
        }
    }
    class Booking
    {
        private static int nextBookingID=1001;
        private int bookingID;
        private Guest guest;
        private Room room;
        private int nights;
        private decimal totalCost;

        public int BookingID
        {
            get { return bookingID; } 
        }
        public int Nights
        { get { return nights; } }
        public decimal TotalCost
            { get { return totalCost; } }
        public Guest Guest
        {
            get { return guest; } 
        }
        
        public Room Room
        {
            get { return room; } 
        }
        public Booking(Guest guest, Room room,int nights)
        {
            bookingID = nextBookingID;
            nextBookingID++;
            this.guest = guest;
            this.room = room;    
            this.nights = nights;
            totalCost = room.NightlyRate * nights;
           
        }

        public void DisplayInfo()
        {
            //Prints the booking ID, guest name, room number, and room type.
            Console.WriteLine("booking ID:" + BookingID);
            Console.WriteLine("guest name:" + Guest.FullName);
            Console.WriteLine("room number:" + Room.RoomNumber);
            Console.WriteLine("room type:" +Room.RoomType);
            Console.WriteLine("Nights: " + Nights);
            Console.WriteLine($"Total Cost: {TotalCost:F3} OMR");
        }
    }
}
