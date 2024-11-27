using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai3
{
    internal class Program
    {
        static List<Student> dssv = new List<Student>();
        static List<Teacher> dsTeacher = new List<Teacher>();

        static void Main()
        {
            int choice;
            do
            {
                Console.WriteLine("\n====== MENU ======");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Thêm giáo viên");
                Console.WriteLine("3. Xuất danh sách sinh viên");
                Console.WriteLine("4. Xuất danh sách giáo viên");
                Console.WriteLine("5. Số lượng từng danh sách");
                Console.WriteLine("6. Xuất danh sách sinh viên thuộc khoa CNTT");
                Console.WriteLine("7. Xuất danh sách giáo viên có địa chỉ chứa 'Quận 9'");
                Console.WriteLine("8. Xuất danh sách sinh viên điểm trung bình cao nhất thuộc khoa CNTT");
                Console.WriteLine("9. Xếp loại sinh viên theo thang điểm 10");
                Console.WriteLine("0. Thoát");


                Console.Write("Nhap lua chon: ");
                choice = int.Parse(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        AddTeacher();
                        break;
                    case 3:
                        DisplayStudents();
                        break;
                    case 4:
                        DisplayTeachers();
                        break;
                    case 5:
                        DisplayCounts();
                        break;
                    case 6:
                        DisplayStudentsByFaculty("CNTT");
                        break;
                    case 7:
                        DisplayTeachersByAddress("Quận 9");
                        break;
                    case 8:
                        DisplayTopStudentsByFaculty("CNTT");
                        break;
                    case 9:
                        TheoDiem10();
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
            Console.Write("Nhap ma so: ");
            string id = Console.ReadLine();
            Console.Write("Nhap ho ten: ");
            string name = Console.ReadLine();
            Console.Write("Nhap khoa: ");
            string faculty = Console.ReadLine();
            Console.Write("Nhap diem trung binh: ");
            double gpa = double.Parse(Console.ReadLine());

            dssv.Add(new Student(id, name, faculty, gpa));
            Console.WriteLine("Thêm sinh viên thành công!");
        }

        static void AddTeacher()
        {
            Console.Write("Nhập mã số: ");
            string id = Console.ReadLine();
            Console.Write("Nhập họ tên: ");
            string name = Console.ReadLine();
            Console.Write("Nhập địa chỉ: ");
            string address = Console.ReadLine();

            dsTeacher.Add(new Teacher(id, name, address));
            Console.WriteLine("Thêm giáo viên thành công!");
        }

        static void DisplayStudents()
        {
            Console.WriteLine("\nDanh sách sinh viên:");
            foreach (var student in dssv)
                Console.WriteLine(student);
        }

        static void DisplayTeachers()
        {
            Console.WriteLine("\nDanh sách giáo viên:");
            foreach (var teacher in dsTeacher)
                Console.WriteLine(teacher);
        }

        static void DisplayCounts()
        {
            Console.WriteLine($"\nTổng số sinh viên: {dssv.Count}");
            Console.WriteLine($"Tổng số giáo viên: {dsTeacher.Count}");
        }

        static void DisplayStudentsByFaculty(string faculty)
        {
            Console.WriteLine($"\nDanh sách sinh viên thuộc khoa {faculty}:");
            foreach (var student in dssv.Where(s => s.Faculty == faculty))
                Console.WriteLine(student);
        }

        static void DisplayTeachersByAddress(string address)
        {
            Console.WriteLine($"\nDanh sách giáo viên có địa chỉ chứa '{address}':");
            foreach (var teacher in dsTeacher.Where(t => t.Address.Contains(address)))
                Console.WriteLine(teacher);
        }

        static void DisplayTopStudentsByFaculty(string faculty)
        {
            var topStudents = dssv.Where(s => s.Faculty == faculty)
                                      .OrderByDescending(s => s.GPA) //   sắp xếp cao xún thấp
                                      .Take(1); // lấy cao nhất

            Console.WriteLine($"\nSinh viên điểm trung bình cao nhất thuộc khoa {faculty}:");
            foreach (var student in topStudents)
                Console.WriteLine(student);
        }

        static void TheoDiem10()
        {
            Console.WriteLine("\nXếp loại sinh viên theo thang điểm 10:");
            var categories = new Dictionary<string, int>
        {
            { "Xuất sắc", 0 },
            { "Giỏi", 0 },
            { "Khá", 0 },
            { "Trung bình", 0 },
            { "Yếu", 0 }
        };

            foreach (var student in dssv)
            {
                if (student.GPA >= 9) categories["Xuất sắc"]++;
                else if (student.GPA >= 8) categories["Giỏi"]++;
                else if (student.GPA >= 6.5) categories["Khá"]++;
                else if (student.GPA >= 5) categories["Trung bình"]++;
                else categories["Yếu"]++;
            }

            foreach (var category in categories)
                Console.WriteLine($"{category.Key}: {category.Value}");
        }
    }
}
