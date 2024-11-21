using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitap01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tạo danh sách 
            List<Student> students = new List<Student>
            {
                new Student { Id = 1, Name = "Anh", Age = 17 },
                new Student { Id = 2, Name = "Huy", Age = 19 },
                new Student { Id = 3, Name = "Nam", Age = 16 },
                new Student { Id = 4, Name = "Cuong", Age = 15 },
                new Student { Id = 5, Name = "Minh", Age = 20 }
            };

            // a. In full danh sach
            Console.WriteLine("Danh ssach hoc sinh:");
            students.ForEach(s => Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Age: {s.Age}"));

            // b. in hoc sinh tuoi tu 15-18
            var st_tuoi = students.Where(s => s.Age >= 15 && s.Age <= 18).ToList();
            Console.WriteLine("\nHS tuoi tu 15-18:");
            st_tuoi.ForEach(s => Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Age: {s.Age}"));

            // c. in hoc sinh bat dau tu \"A\"
            var students_A = students.Where(s => s.Name.StartsWith("A")).ToList();
            Console.WriteLine("\nHS co ten bat dau bang 'A':");
            students_A.ForEach(s => Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Age: {s.Age}"));

            // d. tinh tong tuoi hoc sinh
            var sumAge = students.Sum(s => s.Age);
            Console.WriteLine($"\nTổng tuổi học sinh: {sumAge}");

            // e. in hoc sinh co tuoi cao nhat
            var gia_Student = students.OrderByDescending(s => s.Age).FirstOrDefault();
            Console.WriteLine($"\nHS cao tuoi nhat: Id: {gia_Student.Id}, Name: {gia_Student.Name}, Age: {gia_Student.Age}");

            // f. xep tang dan theo tuoi
            var sapxep_Students = students.OrderBy(s => s.Age).ToList();
            Console.WriteLine("\nDanh sach tuoi tang dan:");
            sapxep_Students.ForEach(s => Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Age: {s.Age}"));
        }
    }
}
