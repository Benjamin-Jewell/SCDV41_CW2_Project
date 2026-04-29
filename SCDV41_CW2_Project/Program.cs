//Main program file

using System.Collections.Generic;
using SCDV41_CW2_Project.Models;
using SCDV41_CW2_Project.Services;

CustomerManager customerManager = new CustomerManager();
VehicleManager vehicleManager = new VehicleManager();
StaffManager staffManager = new StaffManager();
BookingManager bookingManager = new BookingManager();

//creating a few vehicles so that there are some in the system by default
//seperate lines for creating the vehicle and adding it the the vehicle list
var startingVehicle1 = new Vehicle("Range Rover1", "SUV");
vehicleManager.CreateVehicle(startingVehicle1);
var startingVehicle2 = new Vehicle("Range Rover2", "SUV");
vehicleManager.CreateVehicle(startingVehicle2);
var startingVehicle3 = new Vehicle("Volkswagen1", "Hatchback");
vehicleManager.CreateVehicle(startingVehicle3);
var startingVehicle4 = new Vehicle("Audi1", "Saloon");
vehicleManager.CreateVehicle(startingVehicle4);
var startingVehicle5 = new Vehicle("Audi2", "Saloon");
vehicleManager.CreateVehicle(startingVehicle5);
var startingVehicle6 = new Vehicle("BMW1", "Saloon");
vehicleManager.CreateVehicle(startingVehicle6);
var startingVehicle7 = new Vehicle("BMW2", "Saloon");
vehicleManager.CreateVehicle(startingVehicle7);

//a list of all valid vehicle types for Mitch's Motors
List<string> validVehicleTypes = new List<string> { "Hatchback", "Saloon", "SUV", "Coupe", "Convertible", "Van" };

//A menu that allows the user to navigate the different options of the program
Console.WriteLine("########################################################");
Console.WriteLine("Welcome to Mitch's Motors Test Drive Management system!");
Console.WriteLine("########################################################");
Console.WriteLine("Select one of the following options:");
Console.WriteLine("########################################################");
Console.WriteLine("1. Create new booking");
Console.WriteLine("2. View all bookings");
Console.WriteLine("3. View bookings by customer name");
Console.WriteLine("4. Edit bookings");
Console.WriteLine("########################################################");
Console.WriteLine("5. Create new customer");
Console.WriteLine("6. View all customers");
Console.WriteLine("7. View customers by name");
Console.WriteLine("8. Edit customers");
Console.WriteLine("########################################################");
Console.WriteLine("9. Create new vehicle");
Console.WriteLine("10. View all vehicles");
Console.WriteLine("11. View vehicles by type");
Console.WriteLine("12. Delete a vehicle");
Console.WriteLine("########################################################");
Console.WriteLine("13. Create new staff member");
Console.WriteLine("14. View all staff members");
Console.WriteLine("15. Edit staff members");
Console.WriteLine("########################################################");
Console.WriteLine("16. Exit.");
Console.WriteLine("########################################################");

while (true)
{
    Console.WriteLine("Enter your choice (1-17):");

    //user enters their choice of menu option
    try
    {
        var choice = Convert.ToInt32(Console.ReadLine());
    


        if (choice == 1)
        {
            try
            {
                //creating a booking
                Console.WriteLine("Select one of the following options:");
                Console.WriteLine("########################################################");
                Console.WriteLine("1. Create a booking with a new customer");
                Console.WriteLine("2. Create a booking with an existing customer");

                var bookingOption = Convert.ToInt32(Console.ReadLine());

                if (bookingOption == 1)
                {
                    //inputs for a new customer
                    //Customer's name
                    Console.WriteLine("Enter Customer's Name");
                    var customerNameInput = Console.ReadLine();
                    //Customer's email
                    Console.WriteLine("Enter Customer's Email");
                    var customerEmailInput = Console.ReadLine();
                    //Customer's Phone Number
                    Console.WriteLine("Enter Customer's Phone Number");
                    var customerPhoneNumberInput = Convert.ToInt32(Console.ReadLine());
                    //Default number of missed bookings is zero
                    var customerMissedBookingsDefault = 0;

                    //Add details to Customer List
                    var customer = new Customer(customerNameInput, customerEmailInput, customerPhoneNumberInput, customerMissedBookingsDefault);

                    customerManager.CreateCustomer(customer);

                    Console.WriteLine("########################################################");

                    //inputs for a new booking
                    //booking customer (already taken from creating a new customer before)
                    var bookingCustomer = customerManager.GetCustomerName(customerNameInput);

                    Console.WriteLine($"Customer being booked: {bookingCustomer}");

                    //date and time of booking
                    Console.WriteLine("Enter the date and time of the booking");
                    var bookingDateTime = Console.ReadLine();

                    //vehicle being booked
                    Console.WriteLine("Enter name of vehicle being booked");
                    var bookingVehicleInput = Console.ReadLine();
                    //searching for a vehicle with the entered name in the system
                    var bookingVehicle = vehicleManager.GetVehicleName(bookingVehicleInput);

                    //staff accompanying the customer on the booking
                    Console.WriteLine("Enter the name of the staff member accompanying the booking");
                    var bookingStaffInput = Console.ReadLine();
                    //searching for a staff member with the entered name in the system
                    var bookingStaff = staffManager.GetStaffName(bookingStaffInput);

                    var staffAvailable = staffManager.GetStaffAvailability(bookingStaffInput);


                    if (staffAvailable == "True")
                    {
                        var bookingStatus = "Booked";

                        //add details to booking list
                        var booking = new Booking(bookingCustomer, bookingDateTime, bookingVehicle, bookingStaff, bookingStatus);

                        bookingManager.CreateBooking(booking);

                        //update the availability of the staff member in the booking
                        staffManager.changeAvailability(bookingStaff, "false");

                        Console.WriteLine("########################################################");
                        Console.WriteLine("New Booking:");
                        booking.BookingInfo();
                    }
                    else
                    {
                        Console.WriteLine("This staff member is currently unavailable");
                    }
                    

                }
                else if (bookingOption == 2)
                {
                    //inputs for a new booking
                    //booking customer
                    Console.WriteLine("Enter the name of the customer");
                    var customerNameInput = Console.ReadLine();
                    var bookingCustomer = customerManager.GetCustomerName(customerNameInput);

                    //collect number of missed bookings of the customer from the system
                    var bookedCustomerMissedBookings = customerManager.GetCustomerMissedBookings(customerNameInput);
                    //convert the collected value to an integer
                    var bookedCustomerMissedBookingsInt = Convert.ToInt32(bookedCustomerMissedBookings);

                    //checks if the nubmer of customer's missed bookings is greater than or equal to 3
                    if (bookedCustomerMissedBookingsInt >= 3)
                    {
                        //if it is, prevent them from creating a booking
                        Console.WriteLine("This customer is blacklisted from booking a test drive");
                    }
                    else
                    {
                        //if it is not, proceed with the rest of the booking system

                        //date and time of booking
                        Console.WriteLine("Enter the date and time of the booking");
                        var bookingDateTime = Console.ReadLine();

                        //vehicle being booked
                        Console.WriteLine("Enter name of vehicle being booked");
                        var bookingVehicleInput = Console.ReadLine();
                        //searching for a vehicle with the entered name in the system
                        var bookingVehicle = vehicleManager.GetVehicleName(bookingVehicleInput);

                        //staff accompanying the customer on the booking
                        Console.WriteLine("Enter the name of the staff member accompanying the booking");
                        var bookingStaffInput = Console.ReadLine();
                        //searching for a staff member with the entered name in the system
                        var bookingStaff = staffManager.GetStaffName(bookingStaffInput);

                        var staffAvailable = staffManager.GetStaffAvailability(bookingStaffInput);

                        if (staffAvailable == "True")
                        {
                            var bookingStatus = "Booked";

                            //add details to booking list
                            var booking = new Booking(bookingCustomer, bookingDateTime, bookingVehicle, bookingStaff, bookingStatus);

                            bookingManager.CreateBooking(booking);

                            //update the availability of the staff member in the booking
                            staffManager.changeAvailability(bookingStaff, "false");

                            Console.WriteLine("########################################################");
                            Console.WriteLine("New Booking:");
                            booking.BookingInfo();
                        }
                        else
                        {
                            Console.WriteLine("This staff member is currently unavailable");
                        }
                    }
                    
                }
                else
                {
                    Console.WriteLine("Please enter one of the above options");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //if the choice is 2, view all bookings
        else if (choice == 2)
        {
            bookingManager.ViewAllBookings();
        }
        //if the choice is 3, view all bookings of a certain customer name
        else if (choice == 3)
        {
            Console.WriteLine("Enter the name of the customer whose booking you would like to search for");
            var bookingNameSearch = Console.ReadLine();

            Console.WriteLine("########################################################");

            bookingManager.ViewBookingsByCustomer(bookingNameSearch);
        }
        //if the choice is 4, allow the user to either update a booking's status, or delete a booking
        else if (choice == 4)
        {
            Console.WriteLine("Select one of the following options:");
            Console.WriteLine("########################################################");
            Console.WriteLine("1. Update a Booking's missed status");
            Console.WriteLine("2. Delete Booking");

            try
            {
                var bookingUpdOption = Convert.ToInt32(Console.ReadLine());

                //if the user picks option 1, change the availability of a staff member
                if (bookingUpdOption == 1)
                {
                    //takes an input for the customer's name
                    Console.WriteLine("Enter the name of the customer you would like to update the booking of");
                    var bookingStatusName = Console.ReadLine();
                    //takes an input for the booking status to be set
                    Console.WriteLine("Enter the booking status you would like to change it to (booked, completed, missed, or cancelled)");
                    var bookingStatusValue = Console.ReadLine();

                    //sets the string of the availability input to lowercase to be more easily compared
                    bookingStatusValue = bookingStatusValue.ToLower();

                    Console.WriteLine("########################################################");

                    bookingManager.changeStatus(bookingStatusName, bookingStatusValue);

                    //if booking status is missed, update the customer's missed bookings
                    if (bookingStatusValue == "missed")
                    {
                        customerManager.IncrementMissedBooking(bookingStatusName);
                    }

                }
                //if the user picks option 2, delete a booking
                else if (bookingUpdOption == 2)
                {
                    Console.WriteLine("Enter the name of the customer whose booking you would like to delete");
                    var bookingDeleteInput = Console.ReadLine();

                    bookingManager.DeleteBooking(bookingDeleteInput);
                }
                else
                {
                    Console.WriteLine("Please enter one of the above options");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //if the choice is 5, create a new customer
        else if (choice == 5)
        {
            try
            {
                //inputs for a new customer
                //Customer's name
                Console.WriteLine("Enter Customer's Name");
                var customerNameInput = Console.ReadLine();
                //Customer's email
                Console.WriteLine("Enter Customer's Email");
                var customerEmailInput = Console.ReadLine();
                //Customer's Phone Number
                Console.WriteLine("Enter Customer's Phone Number");
                var customerPhoneNumberInput = Convert.ToInt32(Console.ReadLine());
                //Default number of missed bookings is zero
                var customerMissedBookingsDefault = 0;

                //Add details to Customer List
                var customer = new Customer(customerNameInput, customerEmailInput, customerPhoneNumberInput, customerMissedBookingsDefault);

                customerManager.CreateCustomer(customer);

                Console.WriteLine("########################################################");

                customer.CustomerInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //if the choice is 6, output all customers
        else if (choice == 6)
        {
            customerManager.ViewAllCustomers();
        }
        //if the choice is 7, search customers by name
        else if (choice == 7)
        {
            Console.WriteLine("Enter the name of the customer you would like to search for");
            var customerNameSearch = Console.ReadLine();

            Console.WriteLine("########################################################");

            customerManager.ViewCustomersByName(customerNameSearch);
        }
        //if the choice is 8, allow the user to either update a customer or delete a customer
        else if (choice == 8)
        {
            Console.WriteLine("Select one of the following options:");
            Console.WriteLine("########################################################");
            Console.WriteLine("1. Update Customer's missed bookings");
            Console.WriteLine("2. Delete Customer");

            try
            {
                var customerOption = Convert.ToInt32(Console.ReadLine());

                //if the user picks option 1, increment the missed booking value of a customer
                if (customerOption == 1)
                {
                    Console.WriteLine("Enter the name of the customer you would like to increase the missed bookings of");
                    var customerMissedIncrement = Console.ReadLine();

                    Console.WriteLine("########################################################");

                    customerManager.IncrementMissedBooking(customerMissedIncrement);
                }
                //if the user picks option 2, delete a customer
                else if (customerOption == 2)
                {
                    Console.WriteLine("Enter the name of the customer you would like to delete");
                    var customerDeleteInput = Console.ReadLine();

                    customerManager.DeleteCustomer(customerDeleteInput);
                }
                else
                {
                    Console.WriteLine("Please enter one of the above options");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //if the choice is 9, create a new vehicle
        else if (choice == 9)
        {
            try
            {
                //inputs for a new vehicle
                //vehicle name
                Console.WriteLine("Enter Vehicle Name");
                var vehicleNameInput = Console.ReadLine();
                //vehicle type
                Console.WriteLine("Enter Vehicle Type");
                var vehicleTypeInput = Console.ReadLine();

                //automatically change the first letter of the inputted vehicle type to uppercase, and the rest to lowercase
                vehicleTypeInput = vehicleTypeInput.First().ToString().ToUpper() + vehicleTypeInput.Substring(1).ToLower();

                //checks if the inputted vehicle type is a valid vehicle type
                if (validVehicleTypes.Contains(vehicleTypeInput) == false)
                {
                    Console.WriteLine("Please enter a valid vehicle type (Hatchback, Saloon, SUV, etc.)");
                }
                else
                {
                    //add details to vehicle list
                    var vehicle = new Vehicle(vehicleNameInput, vehicleTypeInput);

                    vehicleManager.CreateVehicle(vehicle);

                    Console.WriteLine("########################################################");

                    vehicle.VehicleInfo();
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //if the choice is 10, output all vehicle data
        else if (choice == 10)
        {
            vehicleManager.ViewAllVehicles();
        }
        //if the choice is 11, search vehicle data by type
        else if (choice == 11)
        {

            Console.WriteLine("Enter the type of vehicle you would like to search for");
            var vehicleTypeSearch = Console.ReadLine();

            //automatically change the first letter of the inputted vehicle type to uppercase, and the rest to lowercase
            vehicleTypeSearch = vehicleTypeSearch.First().ToString().ToUpper() + vehicleTypeSearch.Substring(1).ToLower();

            Console.WriteLine("########################################################");
            Console.WriteLine($"All {vehicleTypeSearch} vehicles:\n");

            vehicleManager.ViewVehiclesByType(vehicleTypeSearch);
        }
        //if the choice is 12, delete a vehicle
        else if (choice == 12)
        {
            Console.WriteLine("Enter the name of the vehicle you would like to delete");
            var vehicleDeleteInput = Console.ReadLine();

            vehicleManager.DeleteVehicle(vehicleDeleteInput);
        }
        //if the choice is 13, create a new staff member
        else if (choice == 13)
        {
            try
            {
                //inputs for a new staff member
                //staff name
                Console.WriteLine("Enter Staff Member name");
                var staffNameInput = Console.ReadLine();
                //is staff available (default true)
                var staffAvailableInput = true;

                //Add details to Staff List
                var staff = new Staff(staffNameInput, staffAvailableInput);

                staffManager.CreateStaff(staff);

                Console.WriteLine("########################################################");

                staff.StaffInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //if the choice if 14, output all staff member data
        else if (choice == 14)
        {
            staffManager.ViewAllStaff();
        }
        //if the choice is 15, allow the user to either update a staff member or delete a staff member
        else if (choice == 15)
        {
            Console.WriteLine("Select one of the following options:");
            Console.WriteLine("########################################################");
            Console.WriteLine("1. Update Staff's availability");
            Console.WriteLine("2. Delete Staff");

            try
            {
                var staffOption = Convert.ToInt32(Console.ReadLine());

                //if the user picks option 1, change the availability of a staff member
                if (staffOption == 1)
                {
                    //takes an input for the staff member's name
                    Console.WriteLine("Enter the name of the staff member you would like to update the availability of");
                    var staffAvailabilityName = Console.ReadLine();
                    //takes an input for the availability status to be set
                    Console.WriteLine("Enter the availabilty you would like to change them to (available/unavailable");
                    var staffAvailabilityValue = Console.ReadLine();

                    //sets the string of the availability input to lowercase to be more easily compared
                    staffAvailabilityValue = staffAvailabilityValue.ToLower();

                    //create a variable to store the true/false as a string later, so that it can be taken into the method
                    var staffAvailabilityBool = "notAbool";

                    //if the entered string is "available" set the bool version to true
                    if (staffAvailabilityValue == "available")
                    {
                        staffAvailabilityBool = "true";
                    }
                    //if the entered string is "unavailable" set the bool version to false
                    else if (staffAvailabilityValue == "unavailable")
                    {
                        staffAvailabilityBool = "false";
                    }

                    Console.WriteLine("########################################################");

                    staffManager.changeAvailability(staffAvailabilityName, staffAvailabilityBool);
                }
                //if the user picks option 2, delete a staff member
                else if (staffOption == 2)
                {
                    Console.WriteLine("Enter the name of the staff member you would like to delete");
                    var staffDeleteInput = Console.ReadLine();

                    staffManager.DeleteStaff(staffDeleteInput);
                }
                else
                {
                    Console.WriteLine("Please enter one of the above options");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else if (choice == 16)
        {
            //display an exit message to the user
            Console.WriteLine("########################################################");
            Console.WriteLine("Thank you for using Mitch's Motors Test Drive Management system!");
            Console.WriteLine("Exiting the program...");
            Console.WriteLine("########################################################");
            break;
        }
        else
        {
            Console.WriteLine("Please enter one of the above options");
        }

        }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}

