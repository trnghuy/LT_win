using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai2
{
    internal class Program
    {
        static List<Student> dssv = new List<Student>();

        static void Main()
        {
            int choice;
            do
            {
                Console.WriteLine("\n====== MENU ======");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Xuất danh sách sinh viên");
                Console.WriteLine("3. Xuất danh sách sinh viên thuộc khoa CNTT");
                Console.WriteLine("4. Xuất danh sách sinh viên có điểm TB >= 5");
                Console.WriteLine("5. Xuất danh sách sinh viên sắp xếp theo điểm TB tăng dần");
                Console.WriteLine("6. Xuất danh sách sinh viên có điểm TB >= 5 và thuộc khoa CNTT");
                Console.WriteLine("7. Xuất sinh viên có điểm TB cao nhất và thuộc khoa CNTT");
                Console.WriteLine("8. Thống kê xếp loại sinh viên");
                Console.WriteLine("0. Thoát");


                Console.Write("Nhập lựa chọn: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        DisplayStudents();
                        break;
                    case 3:
                        DisplayStudentsByFaculty("CNTT");// xuất tất cả sv thuọc khoa cntt
                        break;
                    case 4:
                        DisplayStudentsByGPA(5); // xuất sv có dtb>5
                        break;
                    case 5:
                        DisplayStudentsSortedByGPA();// xắp sếp sv theo dtb tăng dần
                        break;
                    case 6:
                        DtbCaoThuocKhoa(5, "CNTT"); // dtb > 5 thuộc khoa cntt
                        break;
                    case 7:
                        TopCaoCuaKhoa("CNTT"); // dtb cao nhất khoa
                        break;
                    case 8:
                        soLuongXepLoai();
                        break;
                    case 0:
                        Console.WriteLine("Chương trình kết thúc.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            } while (choice != 0);
        }

        static void AddStudent()
        {
            Console.Write("Nhập mã số: ");
            string id = Console.ReadLine();
            Console.Write("Nhập họ tên: ");
            string name = Console.ReadLine();
            Console.Write("Nhập khoa: ");
            string faculty = Console.ReadLine();
            Console.Write("Nhập điểm trung bình: ");
            double gpa = double.Parse(Console.ReadLine());

            dssv.Add(new Student(id, name, faculty, gpa));
            Console.WriteLine("Thêm sinh viên thành công!");
        }

        static void DisplayStudents()
        {
            Console.WriteLine("\nDanh sách sinh viên:");
            foreach (var student in dssv)
                Console.WriteLine(student);
            
        }
        static void DisplayStudentsByFaculty(string faculty)
        {
            Console.WriteLine($"\nDanh sách sinh viên thuộc khoa {faculty}:");
            var filteredStudents = dssv.Where(s => s.Faculty == faculty).ToList();
            if (!filteredStudents.Any())
            {
                Console.WriteLine("Không có sinh viên thuộc khoa này.");
            }
            else
            {
                foreach (var student in filteredStudents)
                {
                    Console.WriteLine(student);
                }
            }
        }

        static void DisplayStudentsByGPA(double minGPA)
        {
            Console.WriteLine($"\nDanh sách sinh viên có điểm TB >= {minGPA}:");
            var filteredStudents = dssv.Where(s => s.GPA >= minGPA).ToList();
            if (!filteredStudents.Any())
            {
                Console.WriteLine("Không có sinh viên thỏa mãn điều kiện.");
            }
            else
            {
                foreach (var student in filteredStudents)
                {
                    Console.WriteLine(student);
                }
            }
        }

        static void DisplayStudentsSortedByGPA()
        {
            Console.WriteLine("\nDanh sách sinh viên sắp xếp theo điểm trung bình tăng dần:");
            var sortedStudents = dssv.OrderBy(s => s.GPA).ToList();
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }
        }

        static void DtbCaoThuocKhoa(double minGPA, string faculty)
        {
            Console.WriteLine($"\nDanh sách sinh viên có điểm TB >= {minGPA} và thuộc khoa {faculty}:");
            var filteredStudents = dssv.Where(s => s.GPA >= minGPA && s.Faculty == faculty).ToList();
            if (!filteredStudents.Any())
            {
                Console.WriteLine("Không có sinh viên thỏa mãn điều kiện.");
            }
            else
            {
                foreach (var student in filteredStudents)
                {
                    Console.WriteLine(student);
                }
            }
        }

        static void TopCaoCuaKhoa(string faculty)
        {
            Console.WriteLine($"\nSinh viên có điểm TB cao nhất thuộc khoa {faculty}:");
            var topStudent = dssv.Where(s => s.Faculty == faculty)
                                     .OrderByDescending(s => s.GPA)
                                     .FirstOrDefault();
            if (topStudent == null)
            {
                Console.WriteLine("Không có sinh viên thuộc khoa này.");
            }
            else
            {
                Console.WriteLine(topStudent);
            }
        }

        static void soLuongXepLoai()
        {
            Console.WriteLine("\nThống kê xếp loại sinh viên:");
            var categories = new Dictionary<string, int>
        {
            { "Xuất sắc", 0 },
            { "Giỏi", 0 },
            { "Khá", 0 },
            { "Trung bình", 0 },
            { "Yếu", 0 },
            { "Kém", 0 }
        };

            foreach (var student in dssv)
            {
                if (student.GPA >= 9) categories["Xuất sắc"]++;
                else if (student.GPA >= 8) categories["Giỏi"]++;
                else if (student.GPA >= 7) categories["Khá"]++;
                else if (student.GPA >= 5) categories["Trung bình"]++;
                else if (student.GPA >= 4) categories["Yếu"]++;
                else categories["Kém"]++;
            }

            foreach (var category in categories)
            {
                Console.WriteLine($"{category.Key}: {category.Value}");
            }
        }
    }
}
