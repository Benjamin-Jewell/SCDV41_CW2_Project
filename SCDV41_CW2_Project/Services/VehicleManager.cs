using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SCDV41_CW2_Project.Models;

namespace SCDV41_CW2_Project.Services
{
    internal class VehicleManager
    {
        //internal list to store vehicle data
        private List<Vehicle> _vehicles = new();

        //method to add vehicle data to the list
        public void CreateVehicle(Vehicle newVehicle)
        {
            _vehicles.Add(newVehicle);
        }

        //method to output all vehicle data in list
        public void ViewAllVehicles()
        {
            //check to see if there is any vehicle data at all in the list
            if (_vehicles.Count == 0)
            {
                Console.WriteLine("There are currently no vehicles stored, please create a customer");
            }
            else
            {
                Console.WriteLine("########################################################");
                Console.WriteLine("All vehicles:");
                Console.WriteLine("########################################################");

                foreach (var vehicle in _vehicles)
                {
                    vehicle.VehicleInfo();
                }
            }
        }

        //method to output all vehicles of a specific type in the list
        public void ViewVehiclesByType(string type)
        {
            //search for vehicle data with the corresponding type
            //return that to a list
            var search = _vehicles.Where(w => w.Type.Equals(type)).ToList();

            if (search.Count == 0)
            {
                Console.WriteLine($"There are no vehicles with the type: {type} in the system.");
            }
            else
            {
                //loop through what has been returned and output a summary for each one
                foreach (var vehicle in search)
                {
                    vehicle.VehicleInfo();
                }
            }
        }
    }
}
