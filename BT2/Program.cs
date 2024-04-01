using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BT1
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
                    Console.WriteLine("**********************");
                    Console.WriteLine("1. Thêm mới.");
                    Console.WriteLine("2. Hiển thị danh sách.");
                    Console.WriteLine("3. Tìm kiếm.");
                    Console.WriteLine("4. Kết thúc.");
                    Console.WriteLine("**********************");
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
                            themsach();
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

        //khai báo danh mục sách 
        public struct danhmucsach
        {
            public string tensach;
            public string tacgia;
            public int namxuatban;
        }
        static List<danhmucsach> thuviensach = new List<danhmucsach>();

        //thêm đầu sách
        static void themsach()
        {
            Console.OutputEncoding = Encoding.UTF8;
            danhmucsach sachmoi = new danhmucsach();
            Console.WriteLine("Tên đầu sách: ");
            sachmoi.tensach = Console.ReadLine();

            Console.WriteLine("Tác giả: ");
            sachmoi.tacgia = Console.ReadLine();

            Console.WriteLine("Năm xuất bản: ");
            bool isNum = int.TryParse(Console.ReadLine(), out sachmoi.namxuatban);
            for (int i = 0; i < 1; i--)
            {
                if (isNum == true && sachmoi.namxuatban > 0 && sachmoi.namxuatban < 2025)
                    break;
                else
                {
                    Console.WriteLine("Nhập lại năm xuất bản: ");
                    isNum = int.TryParse(Console.ReadLine(), out sachmoi.namxuatban);
                }
            }
            thuviensach.Add(sachmoi);
        }

        //hiển thị danh mục sách
        static void hienthi()
        {
            for (int i = 1; i <= thuviensach.Count; i++)
            {
                Console.Write("STT {0} - ", i);
                thuviensach.ForEach(hienthi => Console.WriteLine($"Tiêu đề: {hienthi.tensach}, Tác giả: {hienthi.tacgia}, Năm xuất bản: {hienthi.namxuatban}"));
            }
        }

        //tìm kiếm thông tin
        static void timkiem()
        {
            Console.WriteLine("Nhập tiêu đề cần tìm");
            string tukhoa = Console.ReadLine();
            foreach (var tieude in thuviensach)
            {
                if (tukhoa == tieude.tensach)
                {
                    Console.WriteLine($"Tiêu đề: {tieude.tensach}, Tác giả: {tieude.tacgia}, Năm xuất bản: {tieude.namxuatban}");
                }
                else
                {
                    Console.WriteLine("Không tìm thấy sách bạn cần!");

                }
            }
        }

    }
}
