namespace LexiconPractice5Garage1
{
    class Motorcycle : Vehicle
    {
        public Motorcycle(string registrationNumber, string color, int numberOfWheels, int cylinderVolume) : base(registrationNumber, color, numberOfWheels)
        {
            CylinderVolume = cylinderVolume;
        }
        public Motorcycle(Vehicle v, int cylinderVolume) : base(v.RegistrationNumber, v.Color, v.NumberOfWheels)
        {
            CylinderVolume = cylinderVolume;
        }
        public int CylinderVolume { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}\nCylinder Volume: {CylinderVolume}";
        }
    }
}