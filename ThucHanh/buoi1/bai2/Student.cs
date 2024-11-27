using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai2
{
    internal class Student
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }
        public double GPA { get; set; }

        public Student(string id, string name, string faculty, double gpa)
        {
            ID = id;
            Name = name;
            Faculty = faculty;
            GPA = gpa;
        }

        public override string ToString()
        {
            return $"Mã số: {ID}, Họ tên: {Name}, Khoa: {Faculty}, Điểm trung bình: {GPA}";
        }
    }
}
