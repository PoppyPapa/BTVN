using System.Text.RegularExpressions;

namespace BT3
{
    //Create User Credentials
    public class Account
    {
        const string UserName = "Admin";
        const string Password = "Admin";

        public bool IsValidChar(string Input)
        {
            string pattern = @"^[A-Za-z0-9._@]+$";
            return Regex.IsMatch(Input, pattern);
        }
        public bool Checked_Accout(string _UserName, string _Password)
        {
            if (_UserName == null || _Password == null)
                return false;
            else if (_UserName != UserName || _Password != Password)
                return false;
            else if (_UserName == " " || _Password == " ")
                return false;
            else
                return true;

        }
        public void Enter_Accout(ref string _UserName, ref string _Password)
        {
            Console.WriteLine("Enter your Username:");
            _UserName = Console.ReadLine();


            Console.WriteLine("Enter your Password:");
            _Password = Console.ReadLine();
        }
        public void UserCredentials(ref string _Username, ref string _Password)
        {
            Enter_Accout(ref _Username, ref _Password);
            while (true)
            {

                if (IsValidChar(_Username) && IsValidChar(_Password))
                {
                    if (Checked_Accout(_Username, _Password))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The Username or Password that you entered is incorrect. Please try again: ");
                        Enter_Accout(ref _Username, ref _Password);
                    }
                }
                else
                {
                    Console.WriteLine("The Username or Password that you entered is incorrect. Please try again: ");
                    Enter_Accout(ref _Username, ref _Password);
                }
            }
        }
    }
    public class CheckInput
    {
        public static bool IsValidName(string Name)
        {
            string pattern = @"^[A-Za-z\s]+$";
            return Regex.IsMatch(Name, pattern);
        }
    }
    public struct EmployeeInfo 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }

        public DateTime Birthday { get; set; }
        public DateTime JoinDay { get; set; }
        
            public EmployeeInfo(string _FirstName, string _LastName, int _ID, DateTime _Birthday, DateTime _JoinDay)
        {
            FirstName = _FirstName;
            LastName = _LastName;
            ID = _ID;
            Birthday = _Birthday;
            JoinDay = _JoinDay;
        }
        public void Enter_Info(int N)
        {
            int n = 1;
            do
            {
                Console.WriteLine("Enter First name: ");
                if (CheckInput.IsValidName(Console.ReadLine()))
                {
                    Console.WriteLine("Input Format is incorrect. Please Enter again!");
                    Console.WriteLine("Enter First name: ");
                } 
                    
            }
            while (n > N);
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            string UserName = "";
            string Password = "";
           
            Account Account = new Account();
            Account.UserCredentials(ref UserName, ref Password);
            
            Console.WriteLine("hi!");
        }
            
    }
}
