namespace HotelManagementSystem__OOP
{
    
    
    internal class Program
    {
        public static void ShowMenue()
        {
            Console.WriteLine("Hello to Hotel Management System ");
            Console.WriteLine("Select the option :");
            Console.WriteLine("1.Add a New Guest");
            Console.WriteLine("2.Add a New Room");
            Console.WriteLine("3.Book a Room");
            Console.WriteLine("4.Cancel a Booking");
            Console.WriteLine("5.Display All Available Rooms");
            Console.WriteLine("6.Display All Booked Rooms");
            Console.WriteLine("7.Search for a Guest");
            Console.WriteLine("8.Hotel Statistics Report");
            Console.WriteLine("9.Exit");

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
            while (!exit)
            {
                ShowMenue();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please choose a number from 1 to 9");
                }
                switch(option)
                {
                    case 1:
                        break;
                        case 2:
                        break;
                        case 3:
                        break;
                        case 4:
                        break;
                        case 5:
                        break;
                        case 6:
                        break;
                        case 7:
                        break;
                        case 8:
                        break;

                        case 9:
                        exit = ExitSystem();
                        break;
                }
            }
        }
    }
    class Hotel
    {
        static List<Guest> Guests=new List<Guest>();
        static List<Room> Rooms=new List<Room>();
        static List<Booking> Bookings=new List<Booking>();
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
