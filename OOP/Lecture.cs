using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP
{
    public class Lecture
    {
        public string Topic { get; set; }
        public DateTime StartDate { get; set; }
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

        public Lecture(string topic, DateTime startDate, Teacher teacher, List<Student> students)
        {
            Topic = topic;
            StartDate = startDate;
            Teacher = teacher;
            Students = students;
        }

        public void PrintAttendanceList()
        {
            string s = "";

            foreach (Student student in Students)
            {
                s += student.FullName() + "\n";
            }

            Console.WriteLine(s);
        }
    }
}