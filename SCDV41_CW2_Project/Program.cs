//Main program file

using SCDV41_CW2_Project.Models;
using SCDV41_CW2_Project.Services;

CustomerManager customerManager = new CustomerManager();

//A menu that allows the user to navigate the different options of the program
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
            //Add the inputs for a new customer
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
        Console.WriteLine("Feature Coming Soon");
    }
    else if (choice == 9)
    {
        Console.WriteLine("Feature Coming Soon");
    }
    else if (choice == 10)
    {
        Console.WriteLine("Feature Coming Soon");
    }
    else if (choice == 11)
    {
        Console.WriteLine("Feature Coming Soon");
    }
    else if (choice == 12)
    {
        Console.WriteLine("Feature Coming Soon");
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
        Console.WriteLine("Exiting the program...");
        break;
    }
    else
    {
        Console.WriteLine("Please enter one of the above options");
    }

}