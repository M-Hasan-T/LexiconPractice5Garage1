using LexiconPractice5Garage1;

namespace GarageTest
{
    public class GarageTest
    {
        [Fact]
        public void Garage_Constructor_Test()
        {

            // Arrange
            Garage<Vehicle> garage = new Garage<Vehicle>(3);
            Car car = new Car("ABC123", "Black", 4, "Bensin");

            // Act
            garage.AddCarToGarage(car);


            // Assert
            Assert.Equal(3, garage.AllParkingSpaces().Length);
            Assert.Equal(1, garage.NumberOfCars());
        }

        public void CarProperties()
        {
            // Arrange   
            Car car = new Car("ABC 123", "Black", 4, "Bensin");

            // actual
            string actualRegistrationNumber = car.RegistrationNumber;
            string actualColor = car.Color;
            int actualNumberOfWheels = car.NumberOfWheels;
            string actualFuelType = car.FuelType;

            // Assert
            Assert.Equal("ABC 123", actualRegistrationNumber);

            Assert.Equal("Black", actualColor);

            Assert.Equal(4, actualNumberOfWheels);

            Assert.Equal("Bensin", actualFuelType);
        }

    }
}