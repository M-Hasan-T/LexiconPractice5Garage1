using System.Collections;

namespace LexiconPractice5Garage1
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {

        private T[] parkingSpaces;
        private int numberOfCars;
        public Garage(int size)
        {
            parkingSpaces = new T[size];
        }

        public int SizeOfGarage
        {
            get { return parkingSpaces.Length; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }

        public bool AddCarToGarage(T vehicle)
        {
            // Because registration number is unique, we can not add a second vehicle with the same registration number.
            if (FindByRegistrationNumber(vehicle.RegistrationNumber) != null)
                return false;

            for (int i = 0; i < parkingSpaces.Length; i++)
            {
                if (parkingSpaces[i] is null)
                {
                    parkingSpaces[i] = vehicle;
                    numberOfCars++;
                    return true;
                }
            }
            return false;
        }

        public bool RemoveCarFromGarage(string registrationNumber)
        {
            for (int i = 0; i < parkingSpaces.Length; i++)
            {
                if (parkingSpaces[i] is not null)
                {
                    if (parkingSpaces[i].RegistrationNumber == registrationNumber)
                    {
                        parkingSpaces[i] = null;
                        numberOfCars--;
                        return true;
                    }
                }
            }
            return false;
        }
        public T[] FindByString(string keyword)
        {
            Dictionary<string, Vehicle> vehicles = new Dictionary<string, Vehicle>();

            for (int i = 0; i < parkingSpaces.Length; i++)
            {
                if (parkingSpaces[i] != null)
                {
                    if (parkingSpaces[i].CompareWith(keyword))
                        vehicles[parkingSpaces[i].RegistrationNumber] = parkingSpaces[i];
                }
            }

            T[] v = new T[vehicles.Count];
            vehicles.Values.CopyTo(v, 0);
            return v;
        }

        public T FindByRegistrationNumber(string regNum)
        {
            for (int i = 0; i < parkingSpaces.Length; i++)
            {
                if (parkingSpaces[i] != null)
                    if (parkingSpaces[i].RegistrationNumber == regNum)
                        return parkingSpaces[i];
            }

            return null;
        }
        public T[] AllParkingSpaces()
        {
            return parkingSpaces.ToArray();
        }

        public int NumberOfCars()
        {
            return numberOfCars;
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var parkingSpace in parkingSpaces)
            {
                if (parkingSpace != null)
                    yield return parkingSpace;
            }
        }
    }
}
