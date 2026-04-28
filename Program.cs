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
            fullName=name;
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

    }
    class Booking
    {

    }
}
