using System;
using System.Globalization;
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
                    Console.WriteLine("2. Hiển thị danh sách.");
                    Console.WriteLine("3. Tìm kiếm.");
                    Console.WriteLine("4. Kết thúc.");
                    Console.WriteLine("**********************");
                    Console.WriteLine("\nEnter choice: ");

                    string text = Console.ReadLine();
                    for (i = 0; i < 1;)
                    {
                        bool isNum  = int.TryParse(text, out choice);
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
                        //case 2:
                        //    hienthi();
                        //    break;
                        //case 3:
                        //    timkiem();
                        //    break;
                        case 4:
                            choice = 0;
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
                while(IsValidName(Name) == false)
                {
                    Console.WriteLine("\nPLease, enter again: ");
                    Name = Console.ReadLine();
                }
                bill.bill_CustomerName = Name;

                //Release Date
                Console.WriteLine("Enter Release date (MM/DD/YYYY): ");
                bill.bill_ReleaseDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", null);

                //Total Price
                Console.WriteLine("Enter Total Price ($): ");
                isNum = int.TryParse(Console.ReadLine(), out bill.bill_TotalPrice);
                while (isNum == false)
                {
                    Console.WriteLine("\nPLease, enter again: ");
                    isNum = int.TryParse(Console.ReadLine(), out bill.bill_TotalPrice);
                }

                //Amout onwed
                Console.WriteLine("Enter Amout Owned ($): ");
                isNum = int.TryParse(Console.ReadLine(), out bill.bill_debt);
                while (isNum == false)
                {
                    Console.WriteLine("\nPLease, enter again: ");
                    isNum = int.TryParse(Console.ReadLine(), out bill.bill_debt);
                }
                
                //Bill Status
                bill.bill_Status = bill.bill_debt != 0;

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
            Bill bill = ListBill.FirstOrDefault(Owned_Bill => Owned_Bill.bill_ID == billID);
            if(bill.bill_Status != null)
            {
                bill.bill_debt = 0;
                bill.bill_Status = false;
                Console.WriteLine("Debt cleared!");
            } 
            else
            {
                Console.WriteLine("Don't find ID bill!");
            }    
        }


    }
}

