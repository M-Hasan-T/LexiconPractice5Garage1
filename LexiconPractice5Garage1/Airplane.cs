using Microsoft.VisualBasic.FileIO;

namespace LexiconPractice5Garage1
{
    class Airplane : Vehicle
    {
        public Airplane(string registrationNumber, string color, int numberOfWheels, int numberOfEngines) : base(registrationNumber, color, numberOfWheels)
        {
            NumberOfEngines = numberOfEngines;
        }
        public Airplane(Vehicle v, int numberOfEngines) : base(v.RegistrationNumber, v.Color, v.NumberOfWheels)
        {
            NumberOfEngines = numberOfEngines;
        }
        public int NumberOfEngines { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}\nNumber of Engines: {NumberOfEngines}";
        }
    }
}
