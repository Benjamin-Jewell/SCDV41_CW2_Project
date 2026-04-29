using SCDV41_CW2_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCDV41_CW2_Project.Services
{
    internal class BookingManager
    {
        //internal list to store bookings
        private List<Booking> _bookings = new();

        //method to add booking to list
        public void CreateBooking(Booking newBooking)
        {
            _bookings.Add(newBooking);
        }

        //method to output all bookings in list
        public void ViewAllBookings()
        {
            //check to see if there are any bookings at all
            if (_bookings.Count == 0)
            {
                Console.WriteLine("There are currently no bookings stored, please create a booking");
            }
            else
            {
                Console.WriteLine("########################################################");
                Console.WriteLine("All bookings:");
                Console.WriteLine("########################################################\n");
                foreach (var booking in _bookings)
                {
                    booking.BookingInfo();
                }
            }

        }

        //method to output all bookings of a specific customer name in the list
        public void ViewBookingsByCustomer(string name)
        {
            //search for the booking with the correct customer name
            //return that to a list
            var search = _bookings.Where(w => w.Customer.Equals(name)).ToList();

            if (search.Count == 0)
            {
                Console.WriteLine($"There are no bookings with the customer: {name} in the system.");
            }
            else
            {
                //loop through what has been returned and output a summary for each one
                foreach (var booking in search)
                {
                    booking.BookingInfo();
                }
            }
        }

        //method to change booking status
        public void changeStatus(string name, string status)
        {
            //search for the booking with the correct customer name
            //return that to a list
            var search = _bookings.Where(w => w.Customer.Equals(name)).ToList();

            if (search.Count == 0)
            {
                Console.WriteLine($"There are no staff members with the name: {name}");
            }
            else if ((status == "booked") || (status == "completed") || (status == "missed") || (status == "cancelled"))
            {
                //loop through what has been returend and update the availability
                foreach (var booking in search)
                {
                    //set the availability of the staff member to the entered value (true or false)
                    booking.BookingStatus(status);
                    booking.BookingInfo();
                }
            }
            else
            {
                Console.WriteLine("Enter either: booked, completed, missed, or cancelled");
            }
        }

        //method to delete a booking
        public void DeleteBooking(string name)
        {
            //search for the booking with the correct customer name
            //return that to a list
            var search = _bookings.Where(w => w.Customer.Equals(name)).ToList();

            if (search.Count == 0)
            {
                Console.WriteLine($"There are no bookings with the customer: {name} in the system.");
            }
            else
            {
                //loop through what has been returned and delete each one
                foreach (var booking in search)
                {
                    _bookings.Remove(booking);
                    Console.WriteLine($"Booking with customer: {name} has been deleted");
                }
            }
        }
    }
}
