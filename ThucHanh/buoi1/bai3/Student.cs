using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai3
{
    internal class Student : Person
    {
        public string Faculty { get; set; }
        public double GPA { get; set; }

        public Student(string id, string name, string faculty, double gpa)
            : base(id, name)
        {
            Faculty = faculty;
            GPA = gpa;
        }

        public override string ToString()
        {
            return base.ToString() + $", Khoa: {Faculty}, Điểm trung bình: {GPA}";
        }
    }
}
