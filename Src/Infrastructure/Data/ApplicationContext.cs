using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data {
    public class ApplicationContext : IdentityDbContext {
        public ApplicationContext () { }
        public ApplicationContext (DbContextOptions<ApplicationContext> options) : base (options) { }

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<CarType> CarType { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite ($"Data Source=../Infrastructure/HiringCar.db");
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);
            modelBuilder.Seed ();
        }
    }
}