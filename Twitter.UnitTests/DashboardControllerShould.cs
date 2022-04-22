using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Controllers;
using Twitter.DataAccess;
using Xunit;

namespace Twitter.UnitTests
{
    public class DashboardControllerShould
    {
        private readonly DataContext _mockContext;
        private readonly DashboardController _controller;
        public DashboardControllerShould()
        {
            _controller = new DashboardController(_mockContext);
        }

        [Fact]  
        public void ReturnNewTweetView()
        {
            var result = _controller.NewTweet();
            Assert.IsType<ViewResult>(result);
        }

    }
}
