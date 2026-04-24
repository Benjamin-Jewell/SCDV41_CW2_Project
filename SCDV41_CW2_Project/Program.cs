//Main program file

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

//user enters their choice of menu option
var choice = Convert.ToInt32(Console.ReadLine());
