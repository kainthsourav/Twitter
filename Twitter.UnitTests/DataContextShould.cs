using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DataAccess;
using Xunit;
using Twitter.Models;

namespace Twitter.UnitTests
{
    public class DataContextShould
    {
        private readonly DataContext _Context;
        public DataContextShould()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseSqlServer("Data Source=mydatacenter.database.windows.net;Initial Catalog=mydatapool;User ID=Poonam;Password=Data@mine12;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False").Options;
            _Context = new DataContext(options);  
        }

        [Fact]
        public void Should_Get_RegisterData()
        {
            var result=_Context.RegisterModel.ToList();
            Assert.IsType<List<Register>>(result);
            Assert.NotNull(result);
        }
        [Fact]
        public void Should_Get_TweetsModel()
        {
            var result = _Context.TweetsModel.ToList();
            Assert.IsType<List<TweetModel>>(result);
        }

        [Fact]
        public void Should_Add_To_RegisterData()
        {
            var data = new Register
            {
                userName = "Test",
                name = "Test",
                Email = "Test@Test.com",
                password = "Test",
            };
            _Context.RegisterModel.Add(data);
            _Context.SaveChanges();

            var result = _Context.RegisterModel.Where(x=>x.userName==data.userName && x.password==data.password).ToList();
            Assert.IsType<List<Register>>(result);
            Assert.NotNull(result);
            Assert.Single(result);
            _Context.RegisterModel.Remove(data);
            _Context.SaveChanges();
        }

        
    }
}
