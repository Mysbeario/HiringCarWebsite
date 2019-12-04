using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data {
    public static class ModelBuilderExtensions {
        public static ModelBuilder Seed (this ModelBuilder modelBuilder) {
            modelBuilder.Entity<CarType> ().HasData (
                new CarType {
                    Id = 1,
                        Name = "Ford EcoSport",
                        Seat = 5,
                        Cost = 700000M
                },
                new CarType {
                    Id = 2,
                        Name = "Ford Everest",
                        Seat = 7,
                        Cost = 1500000M
                },
                new CarType {
                    Id = 3,
                        Name = "Ford Fiesta",
                        Seat = 5,
                        Cost = 700000M
                },
                new CarType {
                    Id = 4,
                        Name = "Kia Morning",
                        Seat = 5,
                        Cost = 500000M
                },
                new CarType {
                    Id = 5,
                        Name = "Kia Cerato",
                        Seat = 5,
                        Cost = 700000M
                },
                new CarType {
                    Id = 6,
                        Name = "Kia Sorento",
                        Seat = 7,
                        Cost = 1100000M
                },
                new CarType {
                    Id = 7,
                        Name = "Rondo",
                        Seat = 7,
                        Cost = 800000M
                },
                new CarType {
                    Id = 8,
                        Name = "Sendona",
                        Seat = 8,
                        Cost = 1600000M
                },
                new CarType {
                    Id = 9,
                        Name = "Camry",
                        Seat = 5,
                        Cost = 100000M
                },
                new CarType {
                    Id = 10,
                        Name = "Fortuner",
                        Seat = 7,
                        Cost = 1200000M
                },
                new CarType {
                    Id = 11,
                        Name = "Innova",
                        Seat = 7,
                        Cost = 700000M
                },
                new CarType {
                    Id = 12,
                        Name = "Toyota Corrola Altis",
                        Seat = 5,
                        Cost = 900000M
                },
                new CarType {
                    Id = 13,
                        Name = "Mazda 3",
                        Seat = 5,
                        Cost = 800000M
                },
                new CarType {
                    Id = 14,
                        Name = "Mazda CX5",
                        Seat = 5,
                        Cost = 1200000M
                },
                new CarType {
                    Id = 15,
                        Name = "Mescedes CLA",
                        Seat = 5,
                        Cost = 2000000M
                },
                new CarType {
                    Id = 16,
                        Name = "Mescedes C200",
                        Seat = 5,
                        Cost = 2000000M
                },
                new CarType {
                    Id = 17,
                        Name = "Mescedes C250",
                        Seat = 5,
                        Cost = 2200000M
                },
                new CarType {
                    Id = 18,
                        Name = "Honda City",
                        Seat = 5,
                        Cost = 700000M
                },
                new CarType {
                    Id = 19,
                        Name = "Honda City TOP",
                        Seat = 5,
                        Cost = 800000M
                },
                new CarType {
                    Id = 20,
                        Name = "Chevrolet Blazetrailer",
                        Seat = 7,
                        Cost = 1200000M
                },
                new CarType {
                    Id = 21,
                        Name = "Vinfast Fadil",
                        Seat = 5,
                        Cost = 600000M
                },
                new CarType {
                    Id = 22,
                        Name = "Huyndai Kona",
                        Seat = 5,
                        Cost = 900000M
                },
                new CarType {
                    Id = 23,
                        Name = "Peugoet",
                        Seat = 5,
                        Cost = 1400000M
                },
                new CarType {
                    Id = 24,
                        Name = "Ford Tourneo",
                        Seat = 7,
                        Cost = 1500000M
                },
                new CarType {
                    Id = 25,
                        Name = "Mazda 6",
                        Seat = 4,
                        Cost = 1300000M
                },
                new CarType {
                    Id = 26,
                        Name = "Honda Civic",
                        Seat = 5,
                        Cost = 1100000M
                }
            );

            modelBuilder.Entity<Car> ().HasData(
                new Car {
                    Id = 1,
                    CarTypeId = 19,
                    NumberPlate = "51G-23560",
                    Color = "White"
                },
                new Car {
                    Id = 2,
                    CarTypeId = 12,
                    NumberPlate = "51G-69186",
                    Color = "Silver"
                },
                new Car {
                    Id = 3,
                    CarTypeId = 14,
                    NumberPlate = "51G-74141",
                    Color = "White"
                },
                new Car {
                    Id = 4,
                    CarTypeId = 16,
                    NumberPlate = "51G-65404",
                    Color = "White"
                },
                new Car {
                    Id = 5,
                    CarTypeId = 10,
                    NumberPlate = "94A-19715",
                    Color = "White"
                },
                new Car {
                    Id = 6,
                    CarTypeId = 13,
                    NumberPlate = "51G-22986",
                    Color = "White"
                },
                new Car {
                    Id = 7,
                    CarTypeId = 9,
                    NumberPlate = "51G-23186",
                    Color = "Silver"
                },
                new Car {
                    Id = 8,
                    CarTypeId = 15,
                    NumberPlate = "51G-63428",
                    Color = "White"
                },
                new Car {
                    Id = 9,
                    CarTypeId = 18,
                    NumberPlate = "51G-75835",
                    Color = "White"
                },
                new Car {
                    Id = 10,
                    CarTypeId = 10,
                    NumberPlate = "94A-37715",
                    Color = "White"
                },
                new Car {
                    Id = 11,
                    CarTypeId = 13,
                    NumberPlate = "51G-32986",
                    Color = "White"
                },
                new Car {
                    Id = 12,
                    CarTypeId = 21,
                    NumberPlate = "61A-76150",
                    Color = "White"
                },
                new Car {
                    Id = 13,
                    CarTypeId = 11,
                    NumberPlate = "51G-37128",
                    Color = "Black"
                },
                new Car {
                    Id = 14,
                    CarTypeId = 11,
                    NumberPlate = "51G-99604",
                    Color = "Silver"
                },
                new Car {
                    Id = 15,
                    CarTypeId = 13,
                    NumberPlate = "51F-56476",
                    Color = "White"
                },
                new Car {
                    Id = 16,
                    CarTypeId = 13,
                    NumberPlate = "51G-89975",
                    Color = "Dark Blue"
                },
                new Car {
                    Id = 17,
                    CarTypeId = 22,
                    NumberPlate = "51G-21640",
                    Color = "White"
                },
                new Car {
                    Id = 18,
                    CarTypeId = 18,
                    NumberPlate = "51A-48815",
                    Color = "White"
                },
                new Car {
                    Id = 19,
                    CarTypeId = 14,
                    NumberPlate = "51G-58430",
                    Color = "Red"
                },
                new Car {
                    Id = 20,
                    CarTypeId = 6,
                    NumberPlate = "51G-22488",
                    Color = "White"
                },
                new Car {
                    Id = 21,
                    CarTypeId = 5,
                    NumberPlate = "51F-12136",
                    Color = "White"
                },
                new Car {
                    Id = 22,
                    CarTypeId = 2,
                    NumberPlate = "51F-90254",
                    Color = "Silver"
                },
                new Car {
                    Id = 23,
                    CarTypeId = 16,
                    NumberPlate = "51G-XX404",
                    Color = "White"
                },
                new Car {
                    Id = 24,
                    CarTypeId = 14,
                    NumberPlate = "51G-57912",
                    Color = "White"
                },
                new Car {
                    Id = 25,
                    CarTypeId = 2,
                    NumberPlate = "51H-23163",
                    Color = "Black"
                },
                new Car {
                    Id = 26,
                    CarTypeId = 4,
                    NumberPlate = "51F-56959",
                    Color = "Red"
                },
                new Car {
                    Id = 27,
                    CarTypeId = 11,
                    NumberPlate = "51G-35204",
                    Color = "Silver"
                },
                new Car {
                    Id = 28,
                    CarTypeId = 5,
                    NumberPlate = "51G-12592",
                    Color = "White"
                },
                new Car {
                    Id = 29,
                    CarTypeId = 18,
                    NumberPlate = "51G-74963",
                    Color = "White"
                },
                new Car {
                    Id = 30,
                    CarTypeId = 12,
                    NumberPlate = "51G-33591",
                    Color = "White"
                },
                new Car {
                    Id = 31,
                    CarTypeId = 15,
                    NumberPlate = "51G-22542",
                    Color = "White"
                },
                new Car {
                    Id = 32,
                    CarTypeId = 17,
                    NumberPlate = "51G-32014",
                    Color = "White"
                }
            );
            return modelBuilder;
        }
    }
}