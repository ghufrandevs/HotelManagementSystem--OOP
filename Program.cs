using System.Runtime.CompilerServices;
using System.Xml.Linq;

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
            Console.WriteLine("0.Exit");

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
            hotel.AddRoom(roomNumber, type);
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
            hotel.BookRoom(nationalID, RoomNumber);
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
                    Console.WriteLine("Invalid input. Please choose a number from 0 to 8");
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
            Guests.Add(new Guest(name, id));
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
        public void AddRoom(int number, string type)
        {
            foreach (var r in Rooms)
            {
                if(r.RoomNumber==number)
                {
                    Console.WriteLine("Room with this number already exists");
                    return;
                }
            }
            Rooms.Add(new Room(number, type));
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

        public void BookRoom(string nationalID, int roomNumber)
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
            Bookings.Add(new Booking(guest, room));
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
            foreach (var bRoom in Rooms )
            {
                if(bRoom.IsBooked==true)
                {
                    bookRoom++;
                }
            }
            availableRoom = totalRoom - bookRoom;
            int totalGuestsCreated = Guest.GetTotalGuestsCreated();
            Console.WriteLine("totalGuest :" + totalGuest);
            Console.WriteLine("totalRoom : " + totalRoom);
            Console.WriteLine("bookRoom : " + bookRoom);
            Console.WriteLine("availableRoom : " + availableRoom);

        }


    }
    class Guest
    {
        private static int totalGuestsCreated;
        private string nationalID;
        private string fullName;
        public string NationalID
        {
            get { return nationalID; } 
        }
        public string FullName
        {
            get { return fullName; } 
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    fullName = value;
                }
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
    }
    class Room
    {
        private int roomNumber;
        private string roomType;
        private bool isBooked;

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
        public Room(int number, string type)
        {
            roomNumber = number;
            roomType = type;
            isBooked = false ;

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

        public int BookingID
        {
            get { return bookingID; } 
        }
        public Guest Guest
        {
            get { return guest; } 
        }
        
        public Room Room
        {
            get { return room; } 
        }
        public Booking(Guest guest, Room room)
        {
            bookingID = nextBookingID;
            nextBookingID++;
            this.guest = guest;
            this.room = room;     
           
        }

        public void DisplayInfo()
        {
            //Prints the booking ID, guest name, room number, and room type.
            Console.WriteLine("booking ID:" + BookingID);
            Console.WriteLine("guest name:" + Guest.FullName);
            Console.WriteLine("room number:" + Room.RoomNumber);
            Console.WriteLine("room type:" +Room.RoomType);
        }
    }
}
