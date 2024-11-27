using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai3
{
    internal class Teacher : Person
    {
        public string Address { get; set; }

        public Teacher(string id, string name, string address)
            : base(id, name)
        {
            Address = address;
        }

        public override string ToString()
        {
            return base.ToString() + $", Địa chỉ: {Address}";
        }
    }
}
