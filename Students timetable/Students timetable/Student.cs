using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_timetable
{
    internal class Student
    {
        public Guid Id { get; set; } // Unique identify
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Group { get; set; }
        public Student(string firstName, string lastName, string group)
        {
            Id= Guid.NewGuid();
            Name = firstName;
            Surname = lastName;
            Group = group;
        }
    }
}