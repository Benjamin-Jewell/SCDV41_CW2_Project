using SCDV41_CW2_Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCDV41_CW2_Project.Models
{
    internal class Booking
    {
        //properties
        public string Customer {  get; set; }
        public string DateTime { get; set; }
        public string Vehicle { get; set; }
        public string Staff { get; set; }
        public string Status { get; set; }

        //constructor
        public Booking(string customer, string datetime, string vehicle, string staff, string status)
        {
            //validation
            if (string.IsNullOrWhiteSpace(customer))
            {
                throw new ArgumentNullException("Please provide a valid customer");
            }
            if (string.IsNullOrWhiteSpace(datetime))
            {
                throw new ArgumentNullException("Date and Time must have a value");
            }
            if (string.IsNullOrWhiteSpace(vehicle))
            {
                throw new ArgumentNullException("Vehicle must have a value");
            }
            if (string.IsNullOrWhiteSpace(staff))
            {
                throw new ArgumentNullException("Staff must have a value");
            }

            Customer = customer;
            DateTime = datetime;
            Vehicle = vehicle;
            Staff = staff;
            Status = status;
        }

        //methods

        //method to view booking info
        public void BookingInfo()
        {
            Console.WriteLine($"Customer: {Customer}\nDate/Time: {DateTime}\nVehicle: {Vehicle}\nAccompanying Staff Member: {Staff}\nSatus: {Status}\n");
        }

        //method to change booking status
        public void BookingStatus(string status)
        {
            Status = status;
        }

    }
}
