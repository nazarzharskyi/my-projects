using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
        public class Buyer 
        {

            public string Name { get; set; }

            public string Surname { get; set; }



            public Buyer()
            {

            }

            public Buyer(string name, string surname)
            {
                Name = name;
                Surname = surname;
            }
        }
    
}
