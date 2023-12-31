using Microsoft.EntityFrameworkCore;
using PingChecker.Models;

namespace PingChecker.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options){}
        public DbSet<User> Users {get;set;}
        public DbSet<Comment> Comments {get;set;}
    }
}