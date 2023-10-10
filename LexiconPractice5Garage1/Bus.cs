namespace LexiconPractice5Garage1
{
    class Bus : Vehicle
    {
        public Bus(string registrationNumber, string color, int numberOfWheels, int numberOfSeats) : base(registrationNumber, color, numberOfWheels)
        {
            NumberOfSeats = numberOfSeats;
        }

        public Bus(Vehicle v, int numberOfSeats) : base(v.RegistrationNumber, v.Color, v.NumberOfWheels)
        {
            NumberOfSeats = numberOfSeats;
        }
        public int NumberOfSeats { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}\nNumber of Seats: {NumberOfSeats}";
        }
    }
}
