using SCDV41_CW2_Project.Models;
namespace MitchsMotorsTesting;

[TestClass]
public class Vehicle_Tests
{
    //test for valid inputs
    [TestMethod]
    public void Vehicle_ValidValues_CreatesObject()
    {
        //Arrange
        string name = "Vauxhall1";
        string type = "Hatchback";

        //Act
        var vehicle = new Vehicle(name, type);

        //Assert
        //Check to make sure vehicle is not null
        Assert.IsNotNull(vehicle);

        //Checks to make usre the correct values have been assigned to each property
        Assert.AreEqual(name, vehicle.Name);
        Assert.AreEqual(type, vehicle.Type);
    }

    //tests for invalid name
    [TestMethod]
    public void Vehicle_InvalidName_ThrowsException()
    {
        //Arrange
        string name = "";
        string type = "Hatchback";

        //Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            Vehicle vehicle = new Vehicle(name, type);
        });

    }

    //tests for invalid vehicle type
    [TestMethod]
    public void Vehicle_InvalidType_ThrowsException()
    {
        //Arrange
        string name = "Vauxhall1";
        string type = "";

        //Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            Vehicle vehicle = new Vehicle(name, type);
        });

    }
}
