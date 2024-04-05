using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public static bool IsValidNum(string input)
        {
            int num;
            return int.TryParse(input, out num);
        }
        public static bool IsValidFormatDay(string input, DateTime output)
        {
            string format = "dd/MM/yyyy";
            return DateTime.TryParseExact(input, format, null, System.Globalization.DateTimeStyles.None, out output);

        }
        public static bool IsOver18(DateTime birthDate)
        {
            DateTime currentDate = DateTime.Today;
            int age = currentDate.Year - birthDate.Year;
            if (birthDate > currentDate.AddYears(-age))
                age--;
            return age >= 18;
        }
    }
    public struct EmployeeInfo
    {
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static int ID { get; set; }

        public static DateTime Birthday { get; set; }
        public static DateTime JoinDay { get; set; }

        public EmployeeInfo(string _FirstName, string _LastName, int _ID, DateTime _Birthday, DateTime _JoinDay)
        {
            FirstName = _FirstName;
            LastName = _LastName;
            ID = _ID;
            Birthday = _Birthday;
            JoinDay = _JoinDay;
        }
        public List<EmployeeInfo> _EmployeeInfos = new List<EmployeeInfo>();

        public static int Number_Employee()
        {
            string text;
            int Num = 0, n, temp = 0;
            do
            {
                Console.WriteLine("Input Number of Employees: ");
                text = Console.ReadLine();
                if (!CheckInput.IsValidNum(text))
                {
                    Console.WriteLine("Input Number is incorrect. Please Enter again!");
                }
                else
                {
                    Num = int.Parse(text);
                    if (Num < 1 || Num > 10)
                        Console.WriteLine("Input Number is incorrect. Please Enter again!");
                    else
                        break;
                }
            }
            while (!CheckInput.IsValidNum(text) || Num < 1 || Num > 10);
            return Num;
        }
        public static string Enter_FirstName()
        {
            do
            {
                Console.WriteLine("Enter First name (Nguyen Van): ");
                if (CheckInput.IsValidName(Console.ReadLine()))
                {
                    FirstName = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Input Format is incorrect. Please Enter again!");
                }
            }
            while (!CheckInput.IsValidName(Console.ReadLine()));
            return FirstName;
        }
        public static string Enter_LastName()
        {
            do
            {
                Console.WriteLine("Enter First name (Nguyen Van): ");
                if (CheckInput.IsValidName(Console.ReadLine()))
                {
                    LastName = Console.ReadLine();
                    continue;
                }
                else
                {
                    Console.WriteLine("Input Format is incorrect. Please Enter again!");
                }
            }
            while (!CheckInput.IsValidName(Console.ReadLine()));
            return LastName;
        }
        public static int Enter_ID()
        {
            string text;
            do
            {
                Console.WriteLine("Enter ID Employee: ");
                text = Console.ReadLine();
                if (!CheckInput.IsValidNum(text))
                {
                    Console.WriteLine("Input Format is incorrect. Please Enter again!");
                }
                else
                {
                    ID = int.Parse(text);
                }
            }
            while (!CheckInput.IsValidNum(text));
            return ID;
        }
        public static DateTime Enter_Birthday()
        {
            string text;
            do
            {
                Console.WriteLine("Enter Employee's Birthday: ");
                text = Console.ReadLine();
                if (!CheckInput.IsValidFormatDay(text, Birthday))
                {

                    Console.WriteLine("Input Format is incorrect. Please Enter again!");
                    Console.WriteLine("Enter Employee's Birthday: ");
                }
                else if (!CheckInput.IsOver18(Birthday))
                {
                    Console.WriteLine("Eployee's Age under 18. Please Enter again!");
                    Console.WriteLine("Enter Employee's Birthday: ");
                }
            }
            while (!CheckInput.IsValidFormatDay(text, Birthday));
            return Birthday;
        }
        public static DateTime Enter_Joiningday()
        {
            string text;
            do
            {
                Console.WriteLine("Enter the joining date: ");
                text = Console.ReadLine();
                if (!CheckInput.IsValidFormatDay(text, JoinDay))
                {
                    Console.WriteLine("Input Format is incorrect. Please Enter again!");
                    Console.WriteLine("Enter joining date: ");
                }
                else if (JoinDay > DateTime.Today)
                {
                    Console.WriteLine("The joining date cannot be later than the the current date. Please Enter again!");
                    Console.WriteLine("Enter joining date: ");
                }
            }
            while (!CheckInput.IsValidFormatDay(text, JoinDay));
            return JoinDay;
        }


    }
    public class Program
    {
        static void Main(string[] args)
        {
            //Login 
            string UserName = "";
            string Password = "";

            Account Account = new Account();
            Account.UserCredentials(ref UserName, ref Password);
            
            string text;
            int choice = 0;
            while (true)
            {
                if (choice == 6)
                    break;
                else
                {
                    Console.OutputEncoding = Encoding.UTF8;
                    Console.WriteLine("\n");
                    Console.WriteLine("********* MENU ********");
                    Console.WriteLine("       **********      ");
                    Console.WriteLine("1. Add more bills.");
                    Console.WriteLine("2. Clear Debt bill.");
                    Console.WriteLine("3. Display bill.");
                    Console.WriteLine("4. Display debt bill out of date (30/60/90)");
                    Console.WriteLine("5. Export to text file.");
                    Console.WriteLine("6. Exit.");
                    Console.WriteLine("**********************");
                    Console.WriteLine("\nEnter choice: ");
                    do
                    {
                        text = Console.ReadLine();
                        choice = int.Parse(text);
                        if (!CheckInput.IsValidNum(text) || choice < 0 || choice > 5)
                        {
                            Console.WriteLine("\nPLease, enter again: ");     
                        }
                        else
                        {
                            break;
                        }    
                            
                    }
                    while (!CheckInput.IsValidNum(text) || choice < 0 || choice > 5);
                    switch (choice)
                    {
                        case 1:
                            
                            break;
                        case 2:
                            //ClearDebt();
                            break;
                        case 3:
                            //DisplayBill();
                            break;
                        case 4:
                            //Select_day();
                            break;
                        case 5:
                            //Paid_bill();
                            break;
                        case 6:
                            {
                                choice = 6;
                                Console.WriteLine("**** Program End!!! ****");
                            }

                            break;
                        default:
                            Console.WriteLine("Enter again: ");
                            break;
                                

                    }
                }
            }


            Console.WriteLine("");
        }
        public static void choice_1()
        {
           
            employee.AddtoList(employee.Number_Employee(), new EmployeeInfo(employee.FirstName, employee.LastName, employee.ID, employee.Birthday, employee.JoinDay));

        }
            //Console.WriteLine("hi!");
            
    }
}
