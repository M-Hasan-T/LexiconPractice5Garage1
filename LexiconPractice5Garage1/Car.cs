namespace LexiconPractice5Garage1
{
    public class Car : Vehicle
    {
        public Car(string registrationNumber, string color, int numberOfWheels, string fuelType) : base(registrationNumber, color, numberOfWheels)
        {
            FuelType = fuelType;
        }

        public Car(Vehicle v, string fuelType) : base(v.RegistrationNumber, v.Color, v.NumberOfWheels)
        {
            FuelType = fuelType;
        }
        public string FuelType { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}\nFuel Type: {FuelType}";
        }
    }
}

