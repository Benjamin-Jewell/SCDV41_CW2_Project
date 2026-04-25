using SCDV41_CW2_Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCDV41_CW2_Project.Models
{
    internal class Vehicle
    {
        //properties
        public string Name { get; set; }
        public string Type { get; set; }

        //constructor
        public Vehicle(string name, string type)
        {
            //validation
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name must have a value");
            }
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentNullException("Type must have a value");
            }

            Name = name;
            Type = type;
        }

        //methods

        //method to view vehicle info
        public void VehicleInfo()
        {
            Console.WriteLine($"{Name}:\nType: {Type}\n");
        }
    }
}
