using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconPractice5Garage1
{
    interface IUI
    {
        public interface IUI
        {
            bool GarageMenu();
            void Start();
            void FindVehicleByType();
            void ParkVehicleToGarage();
            void ExitFromGarage();
            void ShowVehicleTypeSelectMenu(string input);
            void WaitForAnyInput();
            string WaitForStringInput(string input);
            int WaitForNumberInput(string input);
            Vehicle VehicleParams();
            void ShowMenu();
        }
    }
}
