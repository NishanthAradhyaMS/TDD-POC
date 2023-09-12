using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TodoApp.Controllers;
using Microsoft.Extensions.Options;
using TodoApp.Models;
using FluentAssertions;
using TodoApp.IntegrationTesting.Fixtures;

namespace TodoApp.IntegrationTesting.System.Controller
{
    public class UserControllerTest
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnStatusCode200()
        {
            // Arrange
            var sut = new UserController();

            // Act
            var result= (OkResult)await sut.GetAync();

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Post_OnSuccess_ReturnStatusCode201()
        {
            // Arrange
            var sut = new UserController();
            
            // Act
            var result = (CreatedResult)await sut.PostAsyn(UserFixture.GetUser());
            // Assert
            result.StatusCode.Should().Be(201);
            
        }
        [Fact]
        public async Task Post_OnBadrequest_Return400()
        {
            // Arrange
            var sut = new UserController();

            // Act
            var result = (BadRequestResult)await sut.PostAsyn(UserFixture.UserWithBadRequest());
            // Assert
            result.StatusCode.Should().Be(400);
            Assert.IsType<BadRequestResult>(result);

        }

        [Fact]
        public async Task GetUserById_OnBadRequest_ReturnStatusCode400()
        {
            // Arrange
            var sut = new UserController();

            // Act
            var result = (BadRequestResult)await sut.GetUserByIdAsync(UserFixture.UserInvalidId());
            // Assert
            result.StatusCode.Should().Be(400);
            Assert.IsType<BadRequestResult>(result);

        }
        [Fact]
        public async Task GetUserById_OnSuccess_ReturnStatusCode200()
        {
            // Arrange
            var sut = new UserController();

            // Act
            var result = (OkResult)await sut.GetUserByIdAsync(UserFixture.UservalidId());

            // Assert
            result.StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task UpdateUser_OnInvalidId_ReturnBadRequest_WithStatusCode400()
        {
            // Arrange
            var sut = new UserController();

            // Act
            var result = (BadRequestResult)await sut.UpdateUserAsync(UserFixture.UserInvalidId(),UserFixture.GetUser());
            // Assert
            result.StatusCode.Should().Be(400);
            Assert.IsType<BadRequestResult>(result);

        }

        [Fact]
        public async Task UpdateUser_OnInvalidUser_ReturnBadRequest_WithStatusCode400()
        {
            // Arrange
            var sut = new UserController();

            // Act
            var result = (BadRequestResult)await sut.UpdateUserAsync(UserFixture.UservalidId(), UserFixture.UserWithBadRequest());
            // Assert
            result.StatusCode.Should().Be(400);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeleteUser_OnInvalidUserId_ReturnBadRequest_WithStatusCode400()
        {
            // Arrange
            var sut = new UserController();

            // Act
            var result = (BadRequestResult)await sut.DeleteUserAsync(UserFixture.UserInvalidId());
            // Assert
            result.StatusCode.Should().Be(400);
            Assert.IsType<BadRequestResult>(result);

        }

        [Fact]
        public async Task DeleteUser_OnSuccess_ReturnOk_WithStatusCode200()
        {
            // Arrange
            var sut = new UserController();

            // Act
            var result = (OkResult)await sut.DeleteUserAsync(UserFixture.UservalidId());
            // Assert
            result.StatusCode.Should().Be(200);
            Assert.IsType<OkResult>(result);

        }



    }
}
