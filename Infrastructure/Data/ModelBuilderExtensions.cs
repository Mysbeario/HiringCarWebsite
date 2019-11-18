using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data {
    public static class ModelBuilderExtensions {
        public static ModelBuilder Seed (this ModelBuilder modelBuilder) {
            modelBuilder.Entity<CarType> ().HasData (
                new CarType {
                    Id = "1",
                        Name = "Ford EcoSport",
                        Seat = 5,
                        Cost = 700000M
                },
                new CarType {
                    Id = "2",
                        Name = "Ford Everest",
                        Seat = 7,
                        Cost = 1500000M
                },
                new CarType {
                    Id = "3",
                        Name = "Ford Fiesta",
                        Seat = 5,
                        Cost = 700000M
                },
                new CarType {
                    Id = "4",
                        Name = "Kia Morning",
                        Seat = 5,
                        Cost = 500000M
                },
                new CarType {
                    Id = "5",
                        Name = "Kia Cerato",
                        Seat = 5,
                        Cost = 700000M
                }
            );
            return modelBuilder;
        }
    }
}