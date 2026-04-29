using SCDV41_CW2_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCDV41_CW2_Project.Services
{
    internal class StaffManager
    {
        //internal list to store Staff Members
        private List<Staff> _staff = new();

        //method to add staff to list
        public void CreateStaff(Staff newStaff)
        {
            _staff.Add(newStaff);
        }

        //method to output all staff in the list
        public void ViewAllStaff()
        {
            //check to see if there are any staff members at all
            if (_staff.Count == 0)
            {
                Console.WriteLine("There are currently no staff members stored, please create a staff member");
            }
            else
            {
                Console.WriteLine("########################################################");
                Console.WriteLine("All staff members:");
                Console.WriteLine("########################################################\n");
                foreach (var staff in _staff)
                {
                    staff.StaffInfo();
                }
            }
        }

        //method to change staff availability
        public void changeAvailability(string name, string availability)
        {
            //search for the staff with the correct name
            //return that to a list
            var search = _staff.Where(w => w.Name.Equals(name)).ToList();

            if (search.Count == 0)
            {
                Console.WriteLine($"There are no staff members with the name: {name}");
            }
            else
            {
                try
                {
                    //test if the entered string can be converted into a bool (if the string is not "true" or "false")
                    var availabilityBool = Convert.ToBoolean(availability);
                    //loop through what has been returend and update the availability
                    foreach (var staff in search)
                    {
                        //set the availability of the staff member to the entered value (true or false)
                        staff.StaffAvailability(availabilityBool);
                        staff.StaffInfo();
                    }
                }
                catch (Exception)
                {
                    //if the entered string cannot be converted into a bool, return an error
                    Console.WriteLine("Please enter available or unavailable");
                }
                
            }
        }

        //method to delete a staff member
        public void DeleteStaff(string name)
        {
            //search for the staff member with the correct name
            //return that to a list
            var search = _staff.Where(w => w.Name.Equals(name)).ToList();

            if (search.Count == 0)
            {
                Console.WriteLine($"There are no staff members with the name: {name} in the system.");
            }
            else
            {
                //loop through what has been returned and delete each one
                foreach (var staff in search)
                {
                    _staff.Remove(staff);
                    Console.WriteLine($"Customer {name} has been deleted");
                }
            }
        }

        //method to return staff member's name for booking information
        public string GetStaffName(string name)
        {
            //search for the staff member with the correct name
            //return that to a list
            var search = _staff.Where(w => w.Name.Equals(name)).ToList();

            if (search.Count == 0)
            {
                Console.WriteLine($"There are no staff members with the name: {name} in the system.");
                return "";
            }
            else
            {
                //loop through what has been returned and returns the name of each one
                var nameOutput = "";
                foreach (var staff in search)
                {
                    nameOutput = staff.Name;
                }
                return nameOutput;
            }
        }

        //method to return staff member's availability for booking system
        public string GetStaffAvailability(string name)
        {
            //search for the staff member with the correct name
            //return that to a list
            var search = _staff.Where(w => w.Name.Equals(name)).ToList();

            if (search.Count == 0)
            {
                Console.WriteLine($"There are no staff members with the name: {name} in the system.");
                return "";
            }
            else
            {
                //loop through what has been returned and returns the name of each one
                var availableOutput = "";
                foreach (var staff in search)
                {
                    var availableOutputB = staff.Available;
                    availableOutput = availableOutputB.ToString();
                }
                return availableOutput;
            }
        }

    }
}
