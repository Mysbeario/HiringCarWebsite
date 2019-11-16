using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context {
    public class ApplicationContext : DbContext {
        public ApplicationContext() { }
        public ApplicationContext (DbContextOptions<ApplicationContext> options) : base (options) { }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarType> CarTypes { get; set; }
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite (@"Data source=HiringCar.db");
        }
    }
}