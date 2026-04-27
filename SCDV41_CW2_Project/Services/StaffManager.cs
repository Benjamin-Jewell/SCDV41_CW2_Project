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
    }
}
