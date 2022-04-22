using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Twitter.Controllers;
using Twitter.DataAccess;
using Twitter.ViewModel;
using Xunit;
using Twitter.Models;

namespace Twitter.UnitTests
{
    public class UserControllerShould
    {
        private readonly DataContext _mockContext;
        private readonly UserController _controller;
        public UserControllerShould()
        {
            _controller = new UserController(_mockContext);
        }
        [Fact]
        public void Should_ReturnViewForSignIn()
        {
            var result = _controller.SignIn();
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Should_ReturnViewForRegister()
        {
            var result = _controller.Register();
            Assert.IsType<ViewResult>(result);
        }
    }
}
