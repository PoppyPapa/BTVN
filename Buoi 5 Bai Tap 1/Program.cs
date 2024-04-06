using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeeManagement
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
        public static bool IsValidNum(string input, out int num)
        {
            //int num;
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
        public string FirstName;
        public string LastName;
        public int ID;
        public DateTime Birthday;
        public DateTime StartDay;

        public static int Number_Employee()
        {
            string text;
            int Num = 0;
            do
            {
                Console.WriteLine("Input Number of Employees: ");
                text = Console.ReadLine();
                if (!CheckInput.IsValidNum(text, out Num))
                {
                    Console.WriteLine("Input Number is incorrect. Please Enter again!");
                }
                else
                {
                    CheckInput.IsValidNum(text, out Num);
                    if (Num < 1 || Num > 10)
                        Console.WriteLine("Input Number is incorrect. Please Enter again!");
                    else
                        break;
                }
            }
            while (!CheckInput.IsValidNum(text, out Num) || Num < 1 || Num > 10);
            return Num;
        }
        public string Enter_FirstName()
        {
            string text;
            do
            {
                Console.WriteLine("Enter First name (e.g., Nguyen Van): ");
                text = Console.ReadLine();
                if (CheckInput.IsValidName(text))
                {
                    FirstName = text;
                }
                else
                {
                    Console.WriteLine("Input Format is incorrect. Please Enter again!");
                }
            }
            while (!CheckInput.IsValidName(text));
            return FirstName;
        }
        public string Enter_LastName()
        {
            string text;
            do
            {
                Console.WriteLine("Enter Last name (e.g., A): ");
                text = Console.ReadLine();
                if (CheckInput.IsValidName(text))
                {
                    LastName = text;
                }
                else
                {
                    Console.WriteLine("Input Format is incorrect. Please Enter again!");
                }
            }
            while (!CheckInput.IsValidName(text));
            return LastName;
        }
        public int Enter_ID()
        {
            string text;
            do
            {
                Console.WriteLine("Enter ID Employee: ");
                text = Console.ReadLine();
                if (!CheckInput.IsValidNum(text, out ID))
                {
                    Console.WriteLine("Input Format is incorrect. Please Enter again!");
                }
                else
                {
                    CheckInput.IsValidNum(text, out ID);
                }
            }
            while (!CheckInput.IsValidNum(text, out ID));
            return ID;
        }
        public DateTime Enter_DateOfBirth()
        {
            string text;
            do
            {
                Console.WriteLine("Enter Employee's Birthday: ");
                text = Console.ReadLine();
                if (!CheckInput.IsValidFormatDay(text, Birthday))
                {
                    Console.WriteLine("Input Format is incorrect. Please Enter again!");
                }
                else if (!CheckInput.IsOver18(Birthday))
                {
                    Console.WriteLine("Employee's age must be at least 18. Please Enter again!");
                }
            }
            while (!CheckInput.IsValidFormatDay(text, Birthday) || !CheckInput.IsOver18(Birthday));
            return Birthday;
        }
        public DateTime Enter_DateOfStart()
        {
            string text;
            do
            {
                Console.WriteLine("Enter the starting date: ");
                text = Console.ReadLine();
                if (!CheckInput.IsValidFormatDay(text, StartDay))
                {
                    Console.WriteLine("Input Format is incorrect. Please Enter again!");
                }
                else if (StartDay > DateTime.Today)
                {
                    Console.WriteLine("The starting date cannot be later than the the current date. Please Enter again!");
                }
            }
            while (!CheckInput.IsValidFormatDay(text, StartDay));
            return StartDay;
        }
        public int YearsOfWork()
        {
            DateTime currentDate = DateTime.Today;
            int years = currentDate.Year - StartDay.Year;
            if (StartDay > currentDate.AddYears(-years))
                years--;
            return years;
        }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            //Login 
            string UserName = "";
            string Password = "";

            Account _Account = new Account();
            _Account.UserCredentials(ref UserName, ref Password);

            string text;
            int choice = 0;
            while (true)
            {
                if (choice == 5)
                    break;
                else
                {
                    Console.OutputEncoding = Encoding.UTF8;
                    Console.WriteLine("\n");
                    Console.WriteLine("********* MENU ********");
                    Console.WriteLine("       **********      ");
                    Console.WriteLine("1. Add Employees Information.");
                    Console.WriteLine("2. Display All Employees Information.");
                    Console.WriteLine("3. Display Employees sorted by birthday (Descending).");
                    Console.WriteLine("4. Display Employees sorted by Years of Work (5 or more years of experience).");
                    Console.WriteLine("5. Exit.");
                    Console.WriteLine("**********************");
                    Console.WriteLine("\nEnter choice: ");
                    do
                    {
                        text = Console.ReadLine();
                        if (!CheckInput.IsValidNum(text, out choice) || choice < 0 || choice > 5)
                        {
                            Console.WriteLine("\nPLease, enter again: ");
                        }
                        else
                        {
                            CheckInput.IsValidNum(text, out choice);
                        }

                    }
                    while (!CheckInput.IsValidNum(text, out choice) || choice < 0 || choice > 5);
                    switch (choice)
                    {
                        case 1:
                            choice_1();
                            break;
                        case 2:
                            choice_2();
                            break;
                        case 3:
                            choice_3();
                            break;
                        case 4:
                            choice_4();
                            break;
                        case 5:
                            Console.WriteLine("**** Program End!!! ****");
                            break;
                        default:
                            Console.WriteLine("Enter again: ");
                            break;
                    }
                }
            }
        }
        public static List<EmployeeInfo> Employees = new List<EmployeeInfo>();
        public static void choice_1()
        {
            int Number = EmployeeInfo.Number_Employee();
            for (int temp = 0; temp < Number; temp++)
            {
                Console.WriteLine($"\nEnter information of employee number {temp + 1}: ");
                EmployeeInfo _Employee = new EmployeeInfo();
                _Employee.Enter_FirstName();
                _Employee.Enter_LastName();
                _Employee.Enter_ID();
                _Employee.Enter_DateOfBirth();
                _Employee.Enter_DateOfStart();
                Employees.Add(_Employee);
            }
        }
        public static void choice_2()
        {
            int No = 1;
            foreach (var emp in Employees)
            {
                Console.WriteLine($"No {No} - Name: {emp.FirstName} {emp.LastName}, ID: {emp.ID}, Date of Birth: {emp.Birthday.ToString("dd/MM/yyyy")}, Date of Start: {emp.StartDay.ToString("dd/MM/yyyy")}");
                No++;
            }
        }
        public static void choice_3()
        {
            Employees.Sort((emp1, emp2) => emp2.Birthday.CompareTo(emp1.Birthday));
            int No = 1;
            foreach (var emp in Employees)
            {
                Console.WriteLine($"No {No} - Name: {emp.FirstName} {emp.LastName}, ID: {emp.ID}, Birthday: {emp.Birthday.ToString("dd/MM/yyyy")}, Joining Date: {emp.StartDay.ToString("dd/MM/yyyy")}");
                No++;
            }
        }
        public static void choice_4()
        {
            int No = 1;
            foreach (var emp in Employees)
            {
                if (emp.YearsOfWork() >= 5)
                {
                    Console.WriteLine($"No {No} - Name: {emp.FirstName} {emp.LastName}, ID: {emp.ID}, Years of Work: {emp.YearsOfWork()}");
                    No++;
                }
            }
        }
    }
}
