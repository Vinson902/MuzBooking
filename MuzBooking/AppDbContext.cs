using Microsoft.EntityFrameworkCore;
using MuzBooking.Entities;

namespace MuzBooking
{
    public class AppDbContext : DbContext
    {
        DbSet<ServiceObject> servicesObjects;
        public AppDbContext(DbContextOptions options) : base(options) => Database.EnsureCreated();

    }
}
