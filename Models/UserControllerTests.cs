using NUnit.Framework;
using Moq;
using CRUD_application_2.Controllers;
using CRUD_application_2.Services;
using CRUD_application_2.Models;

[TestFixture]
public class UserControllerTests
{
    private Mock<IUserService> _userServiceMock;
    private UserController _userController;

    [SetUp]
    public void Setup()
    {
        _userServiceMock = new Mock<IUserService>();
        _userController = new UserController(_userServiceMock.Object);
    }

    [Test]
    public void GetUser_ReturnsUser_WhenUserExists()
    {
        // Arrange
        var expectedUser = new User { Id = 1, Name = "Test User" };
        _userServiceMock.Setup(s => s.GetUser(1)).Returns(expectedUser);

        // Act
        var result = _userController.GetUser(1);

        // Assert
        Assert.AreEqual(expectedUser, result);
    }
}
