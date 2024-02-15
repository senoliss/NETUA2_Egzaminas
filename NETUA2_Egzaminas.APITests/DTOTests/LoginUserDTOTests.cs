using NETUA2_Egzaminas.API.DTOs;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace NETUA2_Egzaminas.APITests.DTOTests
{
    public class LoginUserDTOTests
    {
        // ========================= Testing USERNAME =========================
        #region UserNameTests
        [Fact]
        public void UserName_Null_ShouldFail()
        {
            // Arrange
            var dto = new LoginUserDTO
            {
                UserName = null,
                Password = "test",
            };
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            // Act
            var result = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void UserName_Length2_ShouldFail()
        {
            // Arrange
            var dto = new LoginUserDTO
            {
                UserName = "de",
                Password = "test",
            };
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            // Act
            var result = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void UserName_Length3_ShouldPass()
        {
            // Arrange
            var dto = new LoginUserDTO
            {
                UserName = "dei",
                Password = "test",
            };
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            // Act
            var result = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UserName_Length15_ShouldPass()
        {
            // Arrange
            var dto = new LoginUserDTO
            {
                UserName = new string('a', 15),
                Password = "test",
            };
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            // Act
            var result = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UserName_Length16_ShouldFail()
        {
            // Arrange
            var dto = new LoginUserDTO
            {
                UserName = new string('a', 16),
                Password = "test",
            };
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            // Act
            var result = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            // Assert
            Assert.False(result);
        }
        #endregion

        // ========================= Testing PASSWORD =========================
        #region PasswordTests

        [Fact]
        public void Password_Null_ShouldFail()
        {
            // Arrange
            var dto = new LoginUserDTO
            {
                UserName = "bestUserName",
                Password = null,
            };
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            // Act
            var result = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Password_Length2_ShouldFail()
        {
            // Arrange
            var dto = new LoginUserDTO
            {
                UserName = "bestUserName",
                Password = "te",
            };
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            // Act
            var result = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Password_Length3_ShouldPass()
        {
            // Arrange
            var dto = new LoginUserDTO
            {
                UserName = "bestUserName",
                Password = "tes",
            };
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            // Act
            var result = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Password_Length15_ShouldPass()
        {
            // Arrange
            var dto = new LoginUserDTO
            {
                UserName = "bestUserName",
                Password = new string('a', 15),
            };
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            // Act
            var result = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Password_Length16_ShouldFail()
        {
            // Arrange
            var dto = new LoginUserDTO
            {
                UserName = "bestUserName",
                Password = new string('a', 16),
            };
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            // Act
            var result = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            // Assert
            Assert.False(result);
        }

        #endregion
    }
}