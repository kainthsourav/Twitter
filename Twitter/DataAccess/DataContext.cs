using Microsoft.EntityFrameworkCore;
using Twitter.Models;

namespace Twitter.DataAccess
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Register> RegisterModel { get; set; }
        public DbSet<TweetModel> TweetsModel { get; set; }

    }
}
