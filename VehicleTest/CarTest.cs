
using LexiconPractice5Garage1;
namespace VehicleTest
{
    public class CarTest
    {
        [Fact]
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