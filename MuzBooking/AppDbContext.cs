using Microsoft.EntityFrameworkCore;
using MuzBooking.Entities;

namespace MuzBooking
{
    public class AppDbContext : DbContext
    {
        public DbSet<ServiceObject> ServicesObjects { get; set; }
        public DbSet<Equipment> EquipmentObjects { get; set; }
        public AppDbContext(DbContextOptions options) : base(options) =>
            Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceObject>().HasOne(p => p.Equipment).WithMany(g => g.serviceObjects).HasForeignKey(p => p.EquipmentId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Equipment>().HasData(
                new Equipment
                {
                    Id = 1,
                    AvailableAmount = 10,
                    EquipmentGuid = Guid.Parse("a9a28a80-f39b-4587-bf23-cb708cf7ad1d"),
                    Name = "Guitar",
                    CreatedAt = DateTime.Now
                },
                new Equipment
                {
                    Id = 2,
                    AvailableAmount = 15,
                    EquipmentGuid = Guid.Parse("1aa0019e-828f-4a77-9a91-57e8dd2274b2"),
                    Name = "Drums",
                    CreatedAt = DateTime.Now
                }
                );
        }
    }
}
