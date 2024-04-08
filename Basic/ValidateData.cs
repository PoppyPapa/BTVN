using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Generic_Collection
{
    public class ValidateData
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
        public static bool CheckXSSInput(string input)
        {
            try
            {
                var listdangerousString = new List<string> { "<applet", "<body", "<embed", "<frame", "<script", "<frameset", "<html", "<iframe", "<img", "<style", "<layer", "<link", "<ilayer", "<meta", "<object", "<h", "<input", "<a", "&lt", "&gt" };
                if (string.IsNullOrEmpty(input)) return false;
                foreach (var dangerous in listdangerousString)
                {
                    if (input.Trim().ToLower().IndexOf(dangerous) >= 0) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
