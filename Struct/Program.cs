using System.Text.RegularExpressions;

namespace ProductManagement
{
    public class CheckInput
    {
        public static bool IsValidName(string Name)
        {
            string pattern = @"^[A-Za-z0-9\s]+$";
            return Regex.IsMatch(Name, pattern);
        }
        public static bool IsValidNum(string input, out int num)
        {
            //int num;
            return int.TryParse(input, out num);
        }
        public static bool IsValidFormatDay(string input, out DateTime output)
        {
            string format = "dd/MM/yyyy";
            return DateTime.TryParseExact(input, format, null, System.Globalization.DateTimeStyles.None, out output);

        }
    }
    public struct ProductItem
    {
        public string ProductName;
        public int ProductPrice;
        public DateTime ExpiredDate;
        //Calculate Expired Date
        public int IsExpired(DateTime _ExpiredDate)
        {
            DateTime currentDate = DateTime.Today;
            TimeSpan EpiredDate = _ExpiredDate - currentDate;
            int DaysDifference = (int)EpiredDate.TotalDays;
            return DaysDifference;
        }
        public bool CheckName()
        {
            return ProductName.Length > 10;
            
        }
        public string Enter_ProductName()
        {
            string text;
            do
            {
                Console.WriteLine("Enter Product Name: ");
                text = Console.ReadLine();
                if (CheckInput.IsValidName(text))
                {
                    ProductName = text;
                }
                else
                {
                    Console.WriteLine("Input Format is incorrect. Please Enter again!");
                }
            }
            while (!CheckInput.IsValidName(text));
            return ProductName;
        }
        public int Enter_ProductPrice()
        {
            string text;
            do
            {
                Console.WriteLine("Enter Product Price: ");
                text = Console.ReadLine();
                if (!CheckInput.IsValidNum(text, out ProductPrice))
                {
                    Console.WriteLine("Input Format is incorrect. Please Enter again!");
                }
                else
                {
                    CheckInput.IsValidNum(text, out ProductPrice);
                }
            }
            while (!CheckInput.IsValidNum(text, out ProductPrice));
            return ProductPrice;
        }
        public DateTime Enter_ExpiredDate()
        {
            string text;
            do
            {
                Console.WriteLine("Enter Expired Date (DD/MM/YYYY): ");
                text = Console.ReadLine();
                if (!CheckInput.IsValidFormatDay(text,out ExpiredDate) || IsExpired(ExpiredDate) > 180 || ExpiredDate < DateTime.Today)
                {
                    Console.WriteLine("Input is incorrect. Please Enter again!");
                }
            }
            while (!CheckInput.IsValidFormatDay(text,out ExpiredDate) || IsExpired(ExpiredDate) > 180 || ExpiredDate < DateTime.Today);
            return ExpiredDate;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            List<ProductItem> products = new List<ProductItem>();
            
            Console.WriteLine("Enter the products information");
            int Num;
            string input;
            do
            {
                Console.WriteLine("Number of the products: ");
                input = Console.ReadLine();
            }
            while (!CheckInput.IsValidNum(input, out Num));   
            
            for(int i = 0; i < Num; i++)
            {
                ProductItem _products = new ProductItem();
                Console.WriteLine("\nNo {0}", i+1);
                _products.Enter_ProductName();
                _products.Enter_ProductPrice();
                _products.Enter_ExpiredDate();
                products.Add(_products);
            }
            int temp = 1;
            int count = 0;
            Console.WriteLine("\nProducts expiring soon (<30 days): ");
            foreach (ProductItem product in products)
            {
                
                if (product.IsExpired(product.ExpiredDate) <= 30)
                {
                    Console.WriteLine($"Products no {temp} - Product Name: {product.ProductName}, Product Price: {product.ProductPrice}, Expired Date: {product.ExpiredDate.ToString("dd/MM/yyyy")}");
                    count++;                
                }
                temp++; 
            }
            if (count == 0)
            {
                Console.WriteLine("Don't have products expiring soon (<30 days)!");
            }

            temp = 1;
            count = 0;
            Console.WriteLine("\nProducts with names longer than 10 characters: ");
            foreach (ProductItem product in products)
            {
                
                if (product.CheckName())
                {
                    Console.WriteLine($"Products no {temp} - Product Name: {product.ProductName}, Product Price: {product.ProductPrice}, Expired Date: {product.ExpiredDate.ToString("dd/MM/yyyy")}");
                    count++;
                }
                
                temp++;
            }
            if (count == 0)
            {
                Console.WriteLine("Don't have products with names longer than 10 characters!");
            }
        }
    }
}