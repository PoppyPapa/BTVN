using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Collection
{
    public class Quanlysinhvien
    {
        public string HoTen {  get; set; } 
        public int ID { get; set; }

        GenericClass<Quanlysinhvien> danhsachsinhvien = new GenericClass<Quanlysinhvien>(); 
        
        public void Nhap_HoTen()
        {
            Console.WriteLine("Nhap vao Ho va Ten");
            string input = Console.ReadLine();
            
            while(!ValidateData.IsValidName(input))
        }
        

    }
}
