using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;

namespace StudentAPI.Data.AppDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
