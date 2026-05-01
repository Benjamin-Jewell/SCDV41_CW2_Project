using SCDV41_CW2_Project.Models;
namespace MitchsMotorsTesting;

[TestClass]
public class Booking_Tests
{
    //tests for valid inputs
    [TestMethod]
    public void Booking_ValidValues_CreatesObject()
    {
        //Arrange
        string customer = "John Doe";
        string datetime = "1/5/2026";
        string vehicle = "Audi1";
        string staff = "Test Staff1";
        string status = "Booked";

        //Act
        var booking = new Booking(customer, datetime, vehicle, staff, status);

        //Assert
        //check to make sure booking isn't null
        Assert.IsNotNull(booking);

        //checks to make sure the correct values are assigned to each property
        Assert.AreEqual(customer, booking.Customer);
        Assert.AreEqual(datetime, booking.DateTime);
        Assert.AreEqual(vehicle, booking.Vehicle);
        Assert.AreEqual(staff, booking.Staff);
        Assert.AreEqual(status, booking.Status);

    }

    //tests for invalid customer
    [TestMethod]
    public void Booking_InvalidCustomer_ThrowsException()
    {
        //Arrange
        string customer = "";
        string datetime = "1/5/2026";
        string vehicle = "Audi1";
        string staff = "Test Staff1";
        string status = "Booked";

        //Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            Booking booking = new Booking(customer, datetime, vehicle, staff, status);
        });
    }

    //tests for invalid date and time
    [TestMethod]
    public void Booking_InvalidDateTime_ThrowsException()
    {
        //Arrange
        string customer = "John Doe";
        string datetime = "";
        string vehicle = "Audi1";
        string staff = "Test Staff1";
        string status = "Booked";

        //Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            Booking booking = new Booking(customer, datetime, vehicle, staff, status);
        });
    }

    //tests for invalid vehicle
    [TestMethod]
    public void Booking_InvalidVehicle_ThrowsException()
    {
        //Arrange
        string customer = "John Doe";
        string datetime = "1/5/2026";
        string vehicle = "";
        string staff = "Test Staff1";
        string status = "Booked";

        //Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            Booking booking = new Booking(customer, datetime, vehicle, staff, status);
        });
    }

    //tests for invalid staff member
    [TestMethod]
    public void Booking_InvalidStaff_ThrowsException()
    {
        //Arrange
        string customer = "John Doe";
        string datetime = "1/5/2026";
        string vehicle = "Audi1";
        string staff = "";
        string status = "Booked";

        //Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            Booking booking = new Booking(customer, datetime, vehicle, staff, status);
        });
    }
}
