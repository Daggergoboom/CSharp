using Business.Dtos;
using Business.Factories;
using Business.Models;

namespace Tests.Factories;

public class UserFactoryTests
{
    [Fact]
    public void Create_ShouldReturnUserRegistrationForm()
    {
        // Act
        var result = UserFactory.Create();


        // Assert
        Assert.NotNull(result);
        Assert.IsType<UserRegistrationForm>(result);
    }

    [Fact]
    public void Create_ShouldReturnUser_WhenUserRegistrationFormIsProvided()
    {

        // Arrange
        var userRegistrationform = new UserRegistrationForm
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@domain.com",
            PhoneNumber = "123456789",
            Address = "Main Street 1",
            PostalCode = "12345",
            City = "City"
        };
            // Act
            var result = UserFactory.Create(userRegistrationform);


        // Assert
        Assert.NotNull(result);
        Assert.IsType<User>(result);
        Assert.Equal(userRegistrationform.FirstName, result.FirstName);
        Assert.Equal(userRegistrationform.LastName, result.LastName);
        Assert.Equal(userRegistrationform.Email, result.Email);
        Assert.Equal(userRegistrationform.PhoneNumber, result.PhoneNumber);
        Assert.Equal(userRegistrationform.Address, result.Address);
        Assert.Equal(userRegistrationform.PostalCode, result.PostalCode);
        Assert.Equal(userRegistrationform.City, result.City);
    }
}
