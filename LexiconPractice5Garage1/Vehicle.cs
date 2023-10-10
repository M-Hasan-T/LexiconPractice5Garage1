namespace LexiconPractice5Garage1
{
    public class Vehicle : IVehicle
    {
        public Vehicle(string registrationNumber, string color, int numberOfWheels)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            NumberOfWheels = numberOfWheels;
        }

        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }


        public override string ToString() => $"Registration Number: {RegistrationNumber}\nColor: {Color}\nNumber of Wheels: {NumberOfWheels}";

        public virtual bool CompareWith(string keyword)
        {
            if (Color == keyword || NumberOfWheels.ToString() == keyword)
                return true;

            return false;
        }
    }
}
