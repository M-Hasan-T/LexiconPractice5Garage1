namespace LexiconPractice5Garage1
{
    class Boat : Vehicle
    {
        public Boat(string registrationNumber, string color, int numberOfWheels, int length) : base(registrationNumber, color, numberOfWheels)
        {
            Length = length;
        }

        public Boat(Vehicle v, int length) : base(v.RegistrationNumber, v.Color, v.NumberOfWheels)
        {
            Length = length;
        }
        public double Length { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}\nLength: {Length}";
        }
    }
}