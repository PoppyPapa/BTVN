using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static VuQuangLinh_BT_Buoi4.Bai1;

namespace VuQuangLinh_BT_Buoi4
{
    // Cac ham kiem tra input
    public class CheckInput
    {
        public bool ContainsNumber(string input)
        {
            return input.Any(char.IsDigit);
        }
        public bool ContainSpecialChar(string input)
        {
            Regex specialCharRegex = new Regex(@"[~`!@#$%^&*()+=|\\{}':;,.<>?/""-]");
            return specialCharRegex.IsMatch(input);
        }
        public bool CheckYear(int input)
        {
            return (input < 0 || input > DateTime.Now.Year);
        }
        public bool CheckIsNum(string data, int num)
        {
            return Int32.TryParse(data, out num);
        }
        public bool CheckFloat(string data, float num)
        {
            return float.TryParse(data, out num);
        }
    }


    // Class Bai 1
    internal class Bai1 : CheckInput
    {
        List<Book> list_books = new List<Book>();
        public struct Book
        {
            public string title { get; set; }
            public string author { get; set; }
            public int year_publish { get; set; }
        }
        public void ExecuteTask1()
        {
            bool flag = false;
            do
            {
                int choice = -1;
                Console.WriteLine("\n------Menu quan ly sach------");
                Console.WriteLine("1. Them sach moi");
                Console.WriteLine("2. Hien thi danh sach cac cuon sach");
                Console.WriteLine("3. Tim kiem sach theo tieu de");
                Console.WriteLine("0. Thoat chuong trinh");
                Console.WriteLine("\nNhap lua chon cua ban: ");
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                switch (choice)
                {
                    case 0: Console.WriteLine("Thoat khoi bai 1!"); flag = true; break;
                    case 1: AddBook(); break;
                    case 2: DisplayListBooks(); break;
                    case 3: SearchByTitle(); break;
                    default: Console.WriteLine("Lua chon chua dung, moi ban nhap lai!"); break;
                }
            } while (!flag);
        }
        public void AddBook()  // Them sach moi
        {
            Book new_book = new Book();
            Console.WriteLine("\nNhap thong tin cuon sach moi: ");

            // Xu li nhap tieu de
            Console.Write("Nhap tieu de sach: ");
            new_book.title = Console.ReadLine();
            if (ContainSpecialChar(new_book.title))
            {
                Console.WriteLine("Tieu de khong duoc chua ki tu dac biet!");
                return;
            }
            if (string.IsNullOrWhiteSpace(new_book.title))
            {
                Console.WriteLine("Tieu de khong duoc de trong!");
                return;
            }

            // Xu li nhap ten tac gia
            Console.Write("Nhap ten tac gia: ");
            new_book.author = Console.ReadLine();
            if (ContainsNumber(new_book.author))
            {
                Console.WriteLine("Ten tac gia khong duoc chua chu so!");
                return;
            }
            if (ContainSpecialChar(new_book.author))
            {
                Console.WriteLine("Ten tac gia khong duoc chua ki tu dac biet!");
                return;
            }
            if (string.IsNullOrWhiteSpace(new_book.title))
            {
                Console.WriteLine("Ten tac gia khong duoc de trong!");
                return;
            }

            // Xu li nhap nam xuat ban
            Console.Write("Nhap nam xuat ban: ");
            string year;
            year = Console.ReadLine();
            if (!CheckIsNum(year, new_book.year_publish))
            {
                Console.WriteLine("Nam xuat ban phai la so va khong duoc bo trong!");
                return;
            }
            else
                new_book.year_publish = Int32.Parse(year);

            if (CheckYear(new_book.year_publish))
            {
                Console.WriteLine("Nam xuat ban phai la so nguyen duong va khong lon hon nam hien tai!");
                return;
            }

            // Them vao danh sach cac cuon sach
            list_books.Add(new_book);
        }

        public void DisplayListBooks() // Hien thi tat ca sach
        {
            if (list_books.Count == 0)
            {
                Console.WriteLine("Khong co thong tin cuon sach nao!");
            }
            else
            {
                Console.WriteLine("\nThong tin cac cuon sach dang co: ");
                foreach (Book book in list_books)
                {
                    Console.WriteLine();
                    Display(book);
                }
            }
        }
        public void Display(Book book) // Hien thi 1 cuon sach
        {
            Console.WriteLine("Tieu de: " + book.title + ", " + "Tac gia: " + book.author + ", " + "Nam XB: " + book.year_publish);
        }
        public void SearchByTitle() // Tim kiem theo tieu de sach
        {
            Console.Write("Nhap vao tieu de cuon sach muon tim: ");
            string search = Console.ReadLine();
            bool flag = false;
            foreach (Book book in list_books)
            {
                if (book.title == search)
                {
                    flag = true;
                    Console.WriteLine("Cac cuon sach co tieu de " + '"' + search + '"' + " la: ");
                    Display(book);
                }
            }
            if (!flag)
                Console.WriteLine("Khong tim thay ket qua!");
        }

    }


    // Class Bai 2
    internal class Bai2 : CheckInput
    {
        List<Student> list_students = new List<Student>();
        public struct Student
        {
            public string name { get; set; }
            public int age { get; set; }
            public float average_score { get; set; }
        }
        public void ExecuteTask2()
        {
            bool flag = false;
            do
            {
                int choice = -1;
                Console.WriteLine("\n------Menu quan ly hoc sinh------");
                Console.WriteLine("1. Them hoc sinh moi");
                Console.WriteLine("2. Hien thi danh sach hoc sinh");
                Console.WriteLine("3. Tim hoc sinh theo ten");
                Console.WriteLine("0. Thoat chuong trinh");
                Console.WriteLine("\nNhap lua chon cua ban: ");
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                switch (choice)
                {
                    case 0: Console.WriteLine("Thoat khoi bai 2!"); flag = true; break;
                    case 1: AddStudent(); break;
                    case 2: DisplayListStudents(); break;
                    case 3: SearchByName(); break;
                    default: Console.WriteLine("Lua chon chua dung, moi ban nhap lai!"); break;
                }
            } while (!flag);
        }
        public void AddStudent()  // Them hoc sinh moi
        {
            Student new_student = new Student();
            Console.WriteLine("\nNhap thong tin hoc sinh moi: ");

            // Xu li nhap ten
            Console.Write("Nhap ten: ");
            new_student.name = Console.ReadLine();
            if (ContainsNumber(new_student.name))
            {
                Console.WriteLine("Ten hoc sinh khong duoc chua chu so!");
                return;
            }
            if (ContainSpecialChar(new_student.name))
            {
                Console.WriteLine("Ten hoc sinh khong chua ki tu dac biet!");
                return;
            }
            if (string.IsNullOrWhiteSpace(new_student.name))
            {
                Console.WriteLine("Ten hoc sinh khong duoc de trong!");
                return;
            }

            // Xu li nhap tuoi
            Console.Write("Nhap tuoi: ");
            string age = Console.ReadLine();
            if (!CheckIsNum(age, new_student.age))
            {
                Console.WriteLine("Tuoi hoc sinh phai la mot so nguyen va khong duoc bo trong!");
                return;
            }
            else
                new_student.age = Int32.Parse(age);
            if (new_student.age < 5 || new_student.age > 18)
            {
                Console.WriteLine("Tuoi hoc sinh phai tu 6 den 18 tuoi");
                return;
            }

            // Xu li nhap diem trung binh
            Console.Write("Nhap diem trung binh: ");
            string avarage = Console.ReadLine();
            if (!CheckFloat(avarage, new_student.average_score))
            {
                Console.WriteLine("Diem trung binh phai la so thuc va khong duoc bo trong!");
                return;
            }
            else
                new_student.average_score = float.Parse(avarage);
            if (new_student.average_score < 0 || new_student.average_score > 10)
            {
                Console.WriteLine("Diem trung binh phai nam trong khoang tu 0 den 10");
                return;
            }

            list_students.Add(new_student); // Them vao danh sach hoc sinh
        }

        public void DisplayListStudents() // Hien thi tat ca hoc sinh
        {
            if (list_students.Count == 0)
            {
                Console.WriteLine("Khong co thong tin hoc sinh nao!");
            }
            else
            {
                Console.WriteLine("\nThong tin cac hoc sinh dang co: ");
                foreach (Student student in list_students)
                {
                    Console.WriteLine();
                    Display(student);
                }
            }
        }
        public void Display(Student student) // Hien thi 1 hoc sinh
        {
            Console.WriteLine("Ten: " + student.name + ", " + "Tuoi: " + student.age + ", " + "DTB: " + student.average_score);
        }
        public void SearchByName() // Tim kiem theo ten hoc sinh
        {
            Console.Write("Nhap vao ten hoc sinh muon tim: ");
            string search = Console.ReadLine();
            bool flag = false;
            foreach (Student student in list_students)
            {
                if (student.name == search)
                {
                    flag = true;
                    Console.WriteLine("Cac hoc sinh co ten " + '"' + search + '"' + " la: ");
                    Display(student);
                };
            }
            if (!flag)
                Console.WriteLine("Khong tim thay ket qua!");
        }
    }


    // Class Bai 3
    internal class Bai3
    {
        public void ExecuteTask3()
        {

        }
    }

}