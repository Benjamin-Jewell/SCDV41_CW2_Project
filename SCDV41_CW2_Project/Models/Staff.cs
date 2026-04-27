using SCDV41_CW2_Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCDV41_CW2_Project.Models
{
    internal class Staff
    {
        //properties
        public string Name { get; set; }
        public bool Available { get; set; } 

        //constructor

        public Staff(string name, bool available)
        {
            //validation
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name must have a value.");
            }
            
            Name = name;
            Available = available;
        }

        //methods

        //method to view staff info
        public void StaffInfo()
        {
            Console.WriteLine($"{Name}:\n\nAvailable: {Available}\n");
        }
    }
}
