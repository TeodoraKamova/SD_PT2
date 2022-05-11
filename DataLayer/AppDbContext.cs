using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=HotelDB;Uid=root;Pwd=root;");
        }

        public DbSet<Field> Fields { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Interest> Interests { get; set; }
    }
}
