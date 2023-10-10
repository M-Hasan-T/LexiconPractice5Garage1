namespace LexiconPractice5Garage1
{
    public class GarageHandler : IHandler
    {
        private Garage<Vehicle> garage;

        public GarageHandler(int size)
        {
            garage = new Garage<Vehicle>(size);
        }

        public Garage<Vehicle> Garage
        {
            get { return garage; }
        }

        public bool AddVehicle(Vehicle v)
        {
            return garage.AddCarToGarage(v);
        }

        public bool RemoveVehicle(string registrationNumber)
        {
            return garage.RemoveCarFromGarage(registrationNumber);
        }

        public Vehicle[] FindVehicleByString(string keyword)
        {
            return garage.FindByString(keyword);
        }

        public Vehicle FindVehicleByRegistrationNumber(string regNum)
        {
            return garage.FindByRegistrationNumber(regNum);
        }

        public Vehicle[] FindVehicleByType(string type)
        {
            List<Vehicle> result = new List<Vehicle>();
            foreach (Vehicle v in garage)
                if (v.GetType().Name == type)
                    result.Add(v);

            return result.ToArray();
        }
        public string[] GetAllVehicles()
        {
            Vehicle[] vehiclesArray = garage.ToArray();
            string[] allVehicles = new string[garage.Count()];

            for (int i = 0; i < vehiclesArray.Length; i++)
                if (vehiclesArray[i] != null) allVehicles[i] = $"Parking slot{i + 1}: {vehiclesArray[i]}";

            return allVehicles;
        }

        public string[] GetAllSpaces()
        {
            Vehicle[] vehiclesArray = garage.AllParkingSpaces();
            string[] allVehicles = new string[vehiclesArray.Length];
            for (int i = 0; i < vehiclesArray.Length; i++)
                if (vehiclesArray[i] == null)
                    allVehicles[i] = $"Parking slot {i + 1} is empty.";
                else
                    allVehicles[i] = $"Parking slot {i + 1}: {vehiclesArray[i]}";

            return allVehicles;

        }

        public string GetDetails()
        {
            Dictionary<string, int> types = new Dictionary<string, int>();
            Vehicle[] vehiclesArray = garage.AllParkingSpaces();
            int n;

            for (int i = 0; i < vehiclesArray.Length; i++)
            {
                if (vehiclesArray[i] != null)
                {
                    string typeName = vehiclesArray[i].GetType().Name;
                    if (types.ContainsKey(typeName))
                        types[typeName] += 1;
                    else
                        types[typeName] = 1;
                }
            }

            return $"Number of places: {garage.SizeOfGarage}\n" +
                $"Number of vehicles: {garage.NumberOfCars()}\n" +
                $"Cars: {(types.TryGetValue("Car", out n) ? n : 0)}\n" +
                $"Airplanes: {(types.TryGetValue("Airplane", out n) ? n : 0)}\n" +
                $"Motorcycles: {(types.TryGetValue("Motorcycle", out n) ? n : 0)}\n" +
                $"Buses: {(types.TryGetValue("Bus", out n) ? n : 0)}\n" +
                $"Boats: {(types.TryGetValue("Boat", out n) ? n : 0)}";
        }

        public bool HasSpace()
        {
            return garage.Count() < garage.SizeOfGarage;
        }
    }
}
