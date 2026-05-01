using SCDV41_CW2_Project.Models;
namespace MitchsMotorsTesting;

[TestClass]
public sealed class Customer_Tests
{
    //test for valid inputs
    [TestMethod]
    public void Customer_ValidValues_CreatesObject()
    {
        //Arrange
        string name = "John Doe";
        string email = "email@test.com";
        int phoneNumber = 12345678;
        int missedBookings = 0;

        //Act
        var customer = new Customer(name, email, phoneNumber, missedBookings);

        //Assert
        //check to make sure customer is not null
        Assert.IsNotNull(customer);

        //checks to ensure the correct values are assigned to each property
        Assert.AreEqual(name, customer.Name);
        Assert.AreEqual(email, customer.Email);
        Assert.AreEqual(phoneNumber, customer.PhoneNumber);
        Assert.AreEqual(missedBookings, customer.MissedBookings);
    }

    //test for invalid name
    [TestMethod]
    public void Customer_InvalidName_ThrowsException()
    {
        //Arrange
        string name = ""; //invalid
        string email = "email@test.com";
        int phoneNumber = 12345678;
        int missedBookings = 0;

        //Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            Customer customer = new Customer(name, email, phoneNumber, missedBookings);
        });
    }

    //test for invalid email
    [TestMethod]
    public void Customer_InvalidEmail_ThrowsException()
    {
        //Arrange
        string name = "John Doe";
        string email = ""; //invalid
        int phoneNumber = 12345678;
        int missedBookings = 0;

        //Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            Customer customer = new Customer(name, email, phoneNumber, missedBookings);
        });
    }

    //test for invalid phonenumber
    [TestMethod]
    public void Customer_InvalidPhonenumber_ThrowsException()
    {
        //Arrange
        string name = "John Doe";
        string email = "email@test.com";
        int phoneNumber = -12345678; //invalid
        int missedBookings = 0;

        //Act & Assert
        Assert.ThrowsException<ArgumentException>(() =>
        {
            Customer customer = new Customer(name, email, phoneNumber, missedBookings);
        });
    }
}
