using SCDV41_CW2_Project.Models;
namespace MitchsMotorsTesting;

[TestClass]
public class Staff_Tests
{
    //tests for valid inputs
    [TestMethod]
    public void Staff_ValidValues_CreatesObject()
    {
        //Arrage
        string name = "Test Staff1";
        bool available = true;

        //Act
        var staff = new Staff(name, available);

        //Assert
        //Check to make sure staff is not null
        Assert.IsNotNull(staff);

        //Checks to make sure the correct values have been assigned to each property
        Assert.AreEqual(name, staff.Name);
        Assert.AreEqual(available, staff.Available);
    }

    //tests for invalid name
    [TestMethod]
    public void Staff_InvalidName_ThrowsExceptioj()
    {
        //Arrange
        string name = "";
        bool available = true;

        //Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            Staff staff = new Staff(name, available);
        });
    }
}
