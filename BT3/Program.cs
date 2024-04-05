using Microsoft.VisualBasic;
using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace ListOfBills
{
    //Bill properties
    public struct Bill
    {
        public int bill_ID;
        public string bill_CustomerName;
        public DateTime bill_ReleaseDate;
        public int bill_TotalPrice;
        public bool bill_Status;
        public int bill_debt;
    }

    public class Program
    {
        static List<Bill> ListBill = new List<Bill>();
        static bool IsValidName(string Name)
        {
            string pattern = @"^[A-Za-z\s]+$";
            return Regex.IsMatch(Name, pattern);
        }
        static void Main(string[] args)
        {
            int choice = 0;
            for (int i = 0; i < 10;)
            {
                if (choice == 4)
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

                    string text = Console.ReadLine();
                    while(true || choice != 6)
                    {
                        bool isNum = int.TryParse(text, out choice);
                        if (isNum == false && choice < 0 && choice > 5)
                        {
                            Console.WriteLine("\nPLease, enter again: ");
                            text = Console.ReadLine();
                            isNum = int.TryParse(text, out choice);
                        }
                        else
                            break;
                    }
                    switch (choice)
                    {
                        case 1:
                            AddBill();
                            break;
                        case 2:
                            ClearDebt();
                            break;
                        case 3:
                            DisplayBill();
                            break;
                        case 4:
                            Select_day();
                            break;
                        case 5:
                            Paid_bill();
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
        }
        static void AddBill()
        {
            Console.WriteLine("Enter number of quantities: ");
            string quantity = Console.ReadLine();
            int quantityNumber;


            bool isNum = int.TryParse(quantity, out quantityNumber);
            while (isNum == false)
            {
                Console.WriteLine("Enter again: ");
            }
            for (int i = 1; i <= quantityNumber; i++)
            {
                Console.WriteLine("Enter bill {0} information", i);
                Bill bill = new Bill();

                //Bill ID
                Console.WriteLine("Enter bill ID: ");
                isNum = int.TryParse(Console.ReadLine(), out bill.bill_ID);
                while (isNum == false)
                {
                    Console.WriteLine("\nPLease, enter again: ");
                    isNum = int.TryParse(Console.ReadLine(), out bill.bill_ID);
                }

                //Customer Name
                Console.WriteLine("Enter Customer name: ");
                string Name = Console.ReadLine();
                while (IsValidName(Name) == false)
                {
                    Console.WriteLine("\nPLease, enter again: ");
                    Name = Console.ReadLine();
                }
                bill.bill_CustomerName = Name;

                //Release Date
                Console.WriteLine("Enter Release date (MM/DD/YYYY): ");
                string date = Console.ReadLine();   
                string format = "MM/dd/yyyy";
                bool IsValidDate = DateTime.TryParseExact(date, format, null, System.Globalization.DateTimeStyles.None, out bill.bill_ReleaseDate);

                while (IsValidDate == false || bill.bill_ReleaseDate < DateTime.Today)
                {
                    Console.WriteLine("Enter date Error!!");
                    Console.WriteLine("Enter again (MM/DD/YYYY): ");
                    bill.bill_ReleaseDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", null);
                }
                

                //Total Price
                Console.WriteLine("Enter Total Price ($): ");
                isNum = int.TryParse(Console.ReadLine(), out bill.bill_TotalPrice);
                while (isNum == false)
                {
                    Console.WriteLine("\nPLease, enter again: ");
                    isNum = int.TryParse(Console.ReadLine(), out bill.bill_TotalPrice);
                }

                //Amout onwed
                Console.WriteLine("Enter Amout Debt ($): ");
                isNum = int.TryParse(Console.ReadLine(), out bill.bill_debt);
                while (isNum == false || bill.bill_debt > bill.bill_TotalPrice)
                {
                    Console.WriteLine("\nPLease, enter again: ");
                    isNum = int.TryParse(Console.ReadLine(), out bill.bill_debt);
                }

                //Bill Status
                if(bill.bill_debt != 0)
                {
                    bill.bill_Status = true;
                } 
                else
                bill.bill_Status = false;

                ListBill.Add(bill);
            }
        }
        static void ClearDebt()
        {
            Console.WriteLine("Enter bill ID: ");
            int billID;

            bool isNum = int.TryParse(Console.ReadLine(), out billID);
            while (isNum == false)
            {
                Console.WriteLine("\nPLease, enter again: ");
                isNum = int.TryParse(Console.ReadLine(), out billID);
            }
            Bill debt_bill = ListBill.FirstOrDefault(DebBill => DebBill.bill_ID == billID);
            if (debt_bill.bill_Status == true)
            {
                debt_bill.bill_debt = 0;
                debt_bill.bill_Status = false;
                Console.WriteLine("Debt cleared!");
            }
            else
            {
                Console.WriteLine("Don't find ID bill!");
            }
        }
        static void DisplayBill() 
        {
            Console.WriteLine("Enter bill ID: ");
            string input = Console.ReadLine();
            int billID;
            if(input == "")
            {
                Console.WriteLine("Display all bills");
                foreach(var bill in ListBill)
                {
                    if (bill.bill_Status == true)
                    {
                        Console.WriteLine("Debt bill:");
                        Console.WriteLine($"Bill ID: {bill.bill_ID}, Customer Name: {bill.bill_CustomerName}, Release date: {bill.bill_ReleaseDate}, Total price: {bill.bill_TotalPrice}, Amout debt: {bill.bill_debt}.");
                    }    
                    else
                    {
                        Console.WriteLine("Paid bill:");
                        Console.WriteLine($"Bill ID: {bill.bill_ID}, Customer Name: {bill.bill_CustomerName}, Total price: {bill.bill_TotalPrice}, Release date: {bill.bill_ReleaseDate}");
                    }      
                }
            }
            else
            {
                bool IsNum = int.TryParse(input, out billID);
                while(IsNum == false)
                {
                    Console.WriteLine("Enter bill ID: ");
                    input= Console.ReadLine();
                    IsNum = int.TryParse(input, out billID);
                }
                Bill find_bill = ListBill.FirstOrDefault(FindBill => FindBill.bill_ID == billID);
                if(find_bill.bill_Status == true)
                    Console.WriteLine("Debt bill!");
                else
                    Console.WriteLine("Paid bill!");
                Console.WriteLine(($"Bill ID: {find_bill.bill_ID}, Customer Name: {find_bill.bill_CustomerName}, Release date: {find_bill.bill_ReleaseDate}, Total price: {find_bill.bill_TotalPrice}, Amout debt: {find_bill.bill_debt}."));
            }  
        }
        static void Display_DedtBill_byday(int days)
        {
            DateTime today = DateTime.Now;
            foreach(var Overdate_bill in ListBill)
            {
                TimeSpan timespan = today - Overdate_bill.bill_ReleaseDate; 
                if (timespan.TotalDays <= days && Overdate_bill.bill_Status)
                {
                    Console.WriteLine("Debt bill out of {0} days", days);
                    Console.WriteLine($"Bill ID: {Overdate_bill.bill_ID}, Customer Name: {Overdate_bill.bill_CustomerName}, Release date: {Overdate_bill.bill_ReleaseDate}, Total price: {Overdate_bill.bill_TotalPrice}, Amout debt: {Overdate_bill.bill_debt}.");
                }    
            }
            return;
            
        }
        static void Select_day()
        {
            Console.WriteLine("Input number of day (30/60/90): ");
            int days = Convert.ToInt32(Console.ReadLine());
            switch(days)
            {
                case 30:
                    Display_DedtBill_byday(days);
                    break;
                case 60:
                    Display_DedtBill_byday(days);
                    break;
                case 90:
                    Display_DedtBill_byday(days);
                    break;
                default:
                    Console.WriteLine("Enter again: ");
                    break;
            }    
  
        }
        static void ExporttoFile(string path, List<Bill> listbill)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var bill in ListBill)
                {
                    if (!bill.bill_Status)
                    {
                        writer.WriteLine(($"Bill ID: {bill.bill_ID}, Customer Name: {bill.bill_CustomerName}, Release date: {bill.bill_ReleaseDate}, Total price: {bill.bill_TotalPrice}, Amout debt: {bill.bill_debt}."));
                    }
                }
            }
           
        }
        static void Paid_bill()
        {
            ExporttoFile("Bill paid.txt", ListBill);
        }


    }
}
