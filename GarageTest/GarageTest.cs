using LexiconPractice5Garage1;
using System.Drawing;

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

    }
}