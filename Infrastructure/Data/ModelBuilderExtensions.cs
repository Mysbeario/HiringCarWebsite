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
                },
                new CarType {
                    Id = "6",
                        Name = "Kia Sorento",
                        Seat = 7,
                        Cost = 1100000M
                },
                new CarType {
                    Id = "7",
                        Name = "Rondo",
                        Seat = 7,
                        Cost = 800000M
                },
                new CarType {
                    Id = "8",
                        Name = "Sendona",
                        Seat = 8,
                        Cost = 1600000M
                },
                new CarType {
                    Id = "9",
                        Name = "Camry",
                        Seat = 5,
                        Cost = 100000M
                },
                new CarType {
                    Id = "10",
                        Name = "Fortuner",
                        Seat = 7,
                        Cost = 1200000M
                },
                new CarType {
                    Id = "11",
                        Name = "Innova",
                        Seat = 7,
                        Cost = 700000M
                },
                new CarType {
                    Id = "12",
                        Name = "Toyota Corrola Altis",
                        Seat = 5,
                        Cost = 900000M
                },
                new CarType {
                    Id = "13",
                        Name = "Mazda 3",
                        Seat = 5,
                        Cost = 800000M
                },
                new CarType {
                    Id = "14",
                        Name = "Mazda CX5",
                        Seat = 5,
                        Cost = 1200000M
                },
                new CarType {
                    Id = "15",
                        Name = "Mescedes CLA",
                        Seat = 5,
                        Cost = 2000000M
                },
                new CarType {
                    Id = "16",
                        Name = "Mescedes C200",
                        Seat = 5,
                        Cost = 2000000M
                },
                new CarType {
                    Id = "17",
                        Name = "Mescedes C250",
                        Seat = 5,
                        Cost = 2200000M
                },
                new CarType {
                    Id = "18",
                        Name = "Honda City",
                        Seat = 5,
                        Cost = 700000M
                },
                new CarType {
                    Id = "19",
                        Name = "Honda City TOP",
                        Seat = 5,
                        Cost = 800000M
                },
                new CarType {
                    Id = "20",
                        Name = "Chevrolet Blazetrailer",
                        Seat = 7,
                        Cost = 1200000M
                },
                new CarType {
                    Id = "21",
                        Name = "Vinfast Fadil",
                        Seat = 5,
                        Cost = 600000M
                },
                new CarType {
                    Id = "22",
                        Name = "Huyndai Kona",
                        Seat = 5,
                        Cost = 900000M
                },
                new CarType {
                    Id = "23",
                        Name = "Peugoet",
                        Seat = 5,
                        Cost = 1400000M
                },
                new CarType {
                    Id = "24",
                        Name = "Ford Tourneo",
                        Seat = 7,
                        Cost = 1500000M
                },
                new CarType {
                    Id = "25",
                        Name = "Mazda 6",
                        Seat = 4,
                        Cost = 1300000M
                },
                new CarType {
                    Id = "26",
                        Name = "Honda Civic",
                        Seat = 5,
                        Cost = 1100000M
                }
            );
            return modelBuilder;
        }
    }
}