using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Twitter.Controllers;
using Twitter.DataAccess;
using Twitter.ViewModel;
using Xunit;
using Twitter.Models;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Twitter.UnitTests
{
    public class UserControllerShould
    {
        private readonly DataContext _mockContext;
        private readonly UserController _controller;

        public UserControllerShould()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseSqlServer("Data Source=mydatacenter.database.windows.net;Initial Catalog=mydatapool;User ID=Poonam;Password=Data@mine12;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False").Options;
            _mockContext=new DataContext(options);
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
