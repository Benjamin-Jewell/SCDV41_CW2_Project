using SCDV41_CW2_Project.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCDV41_CW2_Project.Models
{
    internal class Customer
    {
        //properties
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        public int MissedBookings { get; set; }

        //constructor
        public Customer(string name, string email, int phoneNumber, int missedBookings)
        {
            //validation
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name must have a value.");
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("Email must have a value");
            }
            if (phoneNumber <= 0)
            {
                throw new ArgumentException("Please enter a valid phone number");
            }

            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            MissedBookings = missedBookings;
        }

        //methods

        //method to view customer info
        public  void CustomerInfo()
        {
            Console.WriteLine($"{Name}:\n\nEmail: {Email}\nPhone Number: {PhoneNumber}\nMissed Bookings: {MissedBookings}\n");
        }
    }
}
