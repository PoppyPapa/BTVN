using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BT2
{

    internal class Program
    {
        static void Main(string[] args)
        {
            int end = 0;
            for (int i = 0; i < 1;)
            {
                if (end == 4)
                    break;
                else
                {
                    Console.OutputEncoding = Encoding.UTF8;
                    Console.WriteLine("\n");
                    Console.WriteLine("***MENU***");
                    Console.WriteLine("*******************************");
                    Console.WriteLine("1. Thêm học sinh mới.");
                    Console.WriteLine("2. Hiển thị danh sách học sinh.");
                    Console.WriteLine("3. Tìm kiếm.");
                    Console.WriteLine("4. Kết thúc.");
                    Console.WriteLine("*******************************");
                    Console.WriteLine("\nChọn: ");

                    int selection = 0;
                    string nhapvao = Console.ReadLine();

                    bool isNum = int.TryParse(nhapvao, out selection);
                    for (i = 0; i < 1;)
                    {
                        if (isNum == true && selection > 0 && selection < 5)
                            break;
                        else
                        {
                            Console.WriteLine("\nChọn lại: ");
                            nhapvao = Console.ReadLine();
                            isNum = int.TryParse(nhapvao, out selection);
                        }
                    }
                    switch (selection)
                    {
                        case 1:
                            themhocsinh();
                            break;
                        case 2:
                            hienthi();
                            break;
                        case 3:
                            timkiem();
                            break;
                        case 4:
                            end = selection;
                            break;
                    }
                }
            }

            Console.ReadKey();
        }

        //khai báo danh sách học sinh
        public struct danhsachhocsinh
        {
            public string hoten;
            public int namsinh;
            public float diemtrungbinh;
        }
        static List<danhsachhocsinh> hocsinh  = new List<danhsachhocsinh>();

        //thêm học sinh
        static void themhocsinh()
        {
            Console.OutputEncoding = Encoding.UTF8;
            danhsachhocsinh hocsinhmoi = new danhsachhocsinh();
            Console.WriteLine("Họ và tên: ");
            hocsinhmoi.hoten = Console.ReadLine();

            Console.WriteLine("Năm sinh: ");
            bool isNum = int.TryParse(Console.ReadLine(), out hocsinhmoi.namsinh);
            for (int i = 0; i < 1; i--)
            {
                if (isNum == true && hocsinhmoi.namsinh > 1990 && hocsinhmoi.namsinh < 2025)
                    break;
                else
                {
                    Console.WriteLine("Nhập lại năm sinh: ");
                    isNum = int.TryParse(Console.ReadLine(), out hocsinhmoi.namsinh);
                }
            }

            Console.WriteLine("Điểm trung bình: ");
            bool isFloat = float.TryParse(Console.ReadLine(), out hocsinhmoi.diemtrungbinh);
            for (int i = 0; i < 1; i--)
            {
                if (isFloat == true && hocsinhmoi.diemtrungbinh >= 0.0 && hocsinhmoi.diemtrungbinh <= 10.0)
                    break;
                else
                {
                    Console.WriteLine("Nhập lại điểm trung bình: ");
                    isNum = float.TryParse(Console.ReadLine(), out hocsinhmoi.diemtrungbinh);
                }
            }
            hocsinh.Add(hocsinhmoi);
        }

        //hiển thị danh sách học sinh
        static void hienthi()
        {
            for (int i = 1; i <= hocsinh.Count; i++)
            {
                Console.Write("STT {0} - ", i);
                hocsinh.ForEach(hienthi => Console.WriteLine($"Họ và tên: {hienthi.hoten}, Năm sinh: {hienthi.namsinh}, Điểm trung bình: {hienthi.diemtrungbinh}"));
            }
        }

        //tìm kiếm thông tin
        static void timkiem()
        {
            Console.WriteLine("Nhập tên cần tìm");
            string tukhoa = Console.ReadLine();
            foreach (var hoten in hocsinh)
            {
                if (tukhoa == hoten.hoten)
                {
                    Console.WriteLine($"Họ và tên: {hoten.hoten}, Năm sinh: {hoten.namsinh}, Điểm trung bình: {hoten.diemtrungbinh}");
                }
                else
                {
                    Console.WriteLine("Không tìm thấy tên bạn cần!");

                }
            }
        }

    }
}
