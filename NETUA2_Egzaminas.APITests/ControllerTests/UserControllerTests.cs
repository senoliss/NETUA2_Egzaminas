using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NETUA2_Egzaminas.API.Controllers;
using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.API.Interfaces;
using NETUA2_Egzaminas.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NETUA2_Egzaminas.APITests.ControllerTests
{
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _userService;
        private readonly Mock<IJwtService> _jwtService;
        private readonly Mock<ILogger<UsersController>> _logger;

        public UserControllerTests()
        {
            _userService = new Mock<IUserService>();
            _jwtService = new Mock<IJwtService>();
            _logger = new Mock<ILogger<UsersController>>();
        }

        [Fact]
        public void GetAllUsers_ShouldReturnOk_Test()
        {
            //arrange
            List<User> fake = new List<User>
                {
                    new User { UserId = 1, UserName = "test1", Email = "test1@gmail.com", Password = Encoding.UTF8.GetBytes("ALWiRbVOLdq/IB++osf/GjGYI5mx4s88gbR5M9GStrY="), PasswordSalt = Encoding.UTF8.GetBytes("SWhG31IxpyOR7dSsZ3DcRCXWVxV9j9iqYoeY5RPO1XOvrGd3kgU82ovsNn4C9GfjHHEtj7F6QXVEPEgjKGHa3Q=="), Role = "User", UserInfo = new UserInfo {Id = 1, Name = "string", Surname = "string", PersonalID = "0", PhoneNumber = "0", Email = "string", UserId = 1, ImageId = 9, ResidenceId = null }},
                    new User { UserId = 2, UserName = "test2", Email = "test2@gmail.com", Password = Encoding.UTF8.GetBytes("ALWiRbVOLdq/IB++osf/GjGYI5mx4s88gbR5M9GStrY="), PasswordSalt = Encoding.UTF8.GetBytes("SWhG31IxpyOR7dSsZ3DcRCXWVxV9j9iqYoeY5RPO1XOvrGd3kgU82ovsNn4C9GfjHHEtj7F6QXVEPEgjKGHa3Q=="), Role = "User", UserInfo = null },
                    new User { UserId = 3, UserName = "test3", Email = "test3@gmail.com", Password = Encoding.UTF8.GetBytes("ALWiRbVOLdq/IB++osf/GjGYI5mx4s88gbR5M9GStrY="), PasswordSalt = Encoding.UTF8.GetBytes("SWhG31IxpyOR7dSsZ3DcRCXWVxV9j9iqYoeY5RPO1XOvrGd3kgU82ovsNn4C9GfjHHEtj7F6QXVEPEgjKGHa3Q=="), Role = "User", UserInfo = null },
                    new User { UserId = 4, UserName = "test4", Email = "test4@gmail.com", Password = Encoding.UTF8.GetBytes("ALWiRbVOLdq/IB++osf/GjGYI5mx4s88gbR5M9GStrY="), PasswordSalt = Encoding.UTF8.GetBytes("SWhG31IxpyOR7dSsZ3DcRCXWVxV9j9iqYoeY5RPO1XOvrGd3kgU82ovsNn4C9GfjHHEtj7F6QXVEPEgjKGHa3Q=="), Role = "Admin", UserInfo = null }
                };

            _userService.Setup(x => x.GetAll()).Returns(fake);
            var sut = new UsersController(_userService.Object, _jwtService.Object, _logger.Object);

            //act
            var actual = sut.GetAll();

            //assert
            var okResult = Assert.IsType<OkObjectResult>(actual);   // checks if the 'actual' result returned by the controller is 200OK
            var actualUsers = okResult.Value as List<User>;         // extracts the 'Value' prop from OkObjectResult. if the value is not List<Users>, 'actualUsers' will be null
            Assert.NotNull(actualUsers);                            // Checks if the 'actualUsers' are noit null. If it is null the test will fail indicating that the 'Value' was not a 'List<User>'.
            Assert.Equal(fake.Count(), actualUsers.Count());        // Checks if the count of actual users returned matches the count of fake users we made above.
        }

        [Fact]
        public void CreateUser_ShouldReturnOk_Test()
        {
            // Arrange
            var newUserDto = new RegisterUserDTO
            {
                UserName = "newuser",
                Password = "newpassword",
                Email = "newuser@gmail.com",
                // Include other properties as needed
            };
            var fakeUser = new User
            {
                UserId = 3,
                UserName = newUserDto.UserName,
                Email = newUserDto.Email,
                Password = new byte[0], // Adjust this based on your implementation
                Role = "User",
            };

            _userService.Setup(x => x.CreateAccount(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(fakeUser);
            var sut = new UsersController(_userService.Object, _jwtService.Object, _logger.Object);

            // Act
            var actual = sut.Register(newUserDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actual);
            var actualUser = okResult.Value as User;
            Assert.NotNull(actualUser);
            Assert.Equal(fakeUser.UserId, actualUser.UserId);
        }

        [Fact]
        public void DeleteUser_ShouldReturnOk_Test()
        {
            // Arrange
            int userIdToDelete = 1;
            var fakeUserToDelete = new User
            {
                UserId = userIdToDelete,
                UserName = "test1",
                Email = "test1@gmail.com",
                Password = new byte[0], // Adjust this based on your implementation
                Role = "User",
            };

            _userService.Setup(x => x.GetUserById(userIdToDelete)).Returns(fakeUserToDelete);
            var sut = new UsersController(_userService.Object, _jwtService.Object, _logger.Object);

            // Act
            var actual = sut.Delete(userIdToDelete);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actual);
            var actualUser = okResult.Value as User;
            Assert.NotNull(actualUser);
            Assert.Equal(fakeUserToDelete.UserId, actualUser.UserId);
            // Add more assertions as needed
        }

        [Fact]
        public void Login_ShouldReturnOk_Test()
        {
            // Arrange
            var loginUserDto = new LoginUserDTO
            {
                UserName = "testuser",
                Password = "testpassword",
            };

            var fakeUser = new User
            {
                UserId = 1,
                UserName = "testuser",
                Role = "User", // Set the role as needed
            };

            _userService.Setup(x => x.GetUser(It.IsAny<string>())).Returns(fakeUser);

            // Since we return out int? userId from jwt token
            _userService.Setup(x => x.TryLogin(It.IsAny<User>(), It.IsAny<string>()))
                       .Returns(new ResponseDTO(true, "User connected successfully!"));

            _jwtService.Setup(x => x.GetJwtToken(fakeUser)).Returns("fakeToken"); // Adjust this based on your implementation

            var sut = new UsersController(_userService.Object, _jwtService.Object, _logger.Object);

            // Act
            var actual = sut.Login(loginUserDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actual);
            var actualToken = okResult.Value as string;
            Assert.NotNull(actualToken);
            // Add more assertions as needed
        }
    }
}
