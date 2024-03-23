using Microsoft.EntityFrameworkCore;
using RestAspNet8VStudio.Model;

namespace RestAspNetStudio.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Reservation> Reservations { get; set; }



    }
}
