//Main program file

using System.Collections.Generic;
using SCDV41_CW2_Project.Models;
using SCDV41_CW2_Project.Services;

CustomerManager customerManager = new CustomerManager();
VehicleManager vehicleManager = new VehicleManager();

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
Console.WriteLine("4. View bookings by vehicle type");
Console.WriteLine("5. Edit bookings");
Console.WriteLine("########################################################");
Console.WriteLine("6. Create new customer");
Console.WriteLine("7. View all customers");
Console.WriteLine("8. View customers by name");
Console.WriteLine("9. Edit customers");
Console.WriteLine("########################################################");
Console.WriteLine("10. Create new vehicle");
Console.WriteLine("11. View all vehicles");
Console.WriteLine("12. View vehicles by type");
Console.WriteLine("13. Edit vehicles");
Console.WriteLine("########################################################");
Console.WriteLine("14. Create new staff member");
Console.WriteLine("15. View all staff members");
Console.WriteLine("16. Edit staff members");
Console.WriteLine("########################################################");
Console.WriteLine("17. Exit.");
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
            Console.WriteLine("Feature Coming Soon");
        }
        else if (choice == 2)
        {
            Console.WriteLine("Feature Coming Soon");
        }
        else if (choice == 3)
        {
            Console.WriteLine("Feature Coming Soon");
        }
        else if (choice == 4)
        {
            Console.WriteLine("Feature Coming Soon");
        }
        else if (choice == 5)
        {
            Console.WriteLine("Feature Coming Soon");
        }
        //if the choice is 6, create a new customer
        else if (choice == 6)
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
        else if (choice == 7)
        {
            customerManager.ViewAllCustomers();
        }
        else if (choice == 8)
        {
            Console.WriteLine("Enter the name of the customer you would like to search for");
            var customerNameSearch = Console.ReadLine();

            Console.WriteLine("########################################################");

            customerManager.ViewCustomersByName(customerNameSearch);
        }
        else if (choice == 9)
        {
            Console.WriteLine("Feature Coming Soon");
        }
        else if (choice == 10)
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
        else if (choice == 11)
        {
            vehicleManager.ViewAllVehicles();
        }
        else if (choice == 12)
        {

            Console.WriteLine("Enter the type of vehicle you would like to search for");
            var vehicleTypeSearch = Console.ReadLine();

            //automatically change the first letter of the inputted vehicle type to uppercase, and the rest to lowercase
            vehicleTypeSearch = vehicleTypeSearch.First().ToString().ToUpper() + vehicleTypeSearch.Substring(1).ToLower();

            Console.WriteLine("########################################################");
            Console.WriteLine($"All {vehicleTypeSearch} vehicles:\n");

            vehicleManager.ViewVehiclesByType(vehicleTypeSearch);
        }
        else if (choice == 13)
        {
            Console.WriteLine("Feature Coming Soon");
        }
        else if (choice == 14)
        {
            Console.WriteLine("Feature Coming Soon");
        }
        else if (choice == 15)
        {
            Console.WriteLine("Feature Coming Soon");
        }
        else if (choice == 16)
        {
            Console.WriteLine("Feature Coming Soon");
        }
        else if (choice == 17)
        {
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

