using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_timetable
{
    internal class DoublePeriods
    {
        public string Day { get; set; }
        public string Time { get; set; }
        public string Lesson { get; set; }
        public DoublePeriods(string day, string time, string lesson) 
        {
            Day= day;
            Time= time;
            Lesson= lesson;
        }
    }
}
