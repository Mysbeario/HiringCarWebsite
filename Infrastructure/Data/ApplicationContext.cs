using Core.Entities;
using Core.Entities.CustomerAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data {
    public class ApplicationContext : DbContext {
        public ApplicationContext () { }
        public ApplicationContext (DbContextOptions<ApplicationContext> options) : base (options) { }

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<CarType> CarType { get; set; }
        public virtual DbSet<CustomerAccount> CustomerAccount { get; set; }
        public virtual DbSet<CustomerDetail> CustomerDetail { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite ($"Data Source=../Infrastructure/HiringCar.db");
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Seed ();
        }
    }
}