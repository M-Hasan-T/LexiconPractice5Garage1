using System.Text.RegularExpressions;

namespace LexiconPractice5Garage1
{
    class UserInterface : IUI
    {
        string[] menuOptions = {
                    "Quit",
                    "List all parked vehicles",
                    "List vehicle types and how many of each are in the garage",
                    "Add vehicles from the garage",
                    "Remove vehicles from the garage",
                    "Get all details about vehicles",
                    "Find vehicle by registration number",
                    "Find vehicle by a characteristic"

                };

        string[] vehicleTypes = {
                    "Cancel",
                    "Car",
                    "Bus",
                    "Boat",
                    "Airplane",
                    "Motorcycle"
                };

        GarageHandler garageHandler;
        public UserInterface()
        {
        }

        public UserInterface(GarageHandler garagehandler)
        {
            garageHandler = garagehandler;
        }
        public bool GarageMenu()
        {

            bool continueToSubMenu = false;

            while (!continueToSubMenu)
            {
                Console.Clear();

                Console.WriteLine("**** Garage Menu ****\n0.Quit\n1.Create Garage");

                switch (Console.ReadKey().KeyChar)
                {
                    case '0':
                        Console.Clear();
                        return false;
                    case '1':
                        Console.Clear();
                        int size = WaitForNumberInput("Enter the number of parking spaces of the garage: ");
                        if (size > 0)
                        {
                            garageHandler = new GarageHandler(size);
                            continueToSubMenu = true;
                        }
                        Console.WriteLine("The number must be greater than 0.");
                        break;
                    default:
                        InvalidInput();
                        break;
                }
            }
            return true;
        }

        public void Start()
        {
            while (true)
            {
                ShowMenu();
                switch (Console.ReadKey().KeyChar)
                {
                    case '0':
                        return;
                    case '1':
                        Console.Clear();
                        foreach (string space in garageHandler.GetAllSpaces())
                            Console.WriteLine(space);
                        WaitForAnyInput();
                        break;
                    case '2':
                        FindVehicleByType();
                        WaitForAnyInput();
                        break;
                    case '3':
                        ParkVehicleToGarage();
                        WaitForAnyInput();
                        break;
                    case '4':
                        ExitFromGarage();
                        WaitForAnyInput();
                        break;
                    case '5':
                        Console.Clear();
                        Console.WriteLine(garageHandler.GetDetails());
                        WaitForAnyInput();
                        break;
                    case '6':
                        FindVehicleByRegistrationNumber();
                        WaitForAnyInput();
                        break;
                    case '7':
                        FindVehicleByWord();
                        WaitForAnyInput();
                        break;
                    default:
                        InvalidInput();
                        break;
                }
                Console.WriteLine();
            }
        }

        private void FindVehicleByRegistrationNumber()
        {
            string input;
            Vehicle vehicle;
            Console.Clear();
            do
            {
                input = WaitForStringInput("Enter the registration number:");
                if (!string.IsNullOrWhiteSpace(input))
                {
                    vehicle = garageHandler.FindVehicleByRegistrationNumber(input.ToUpper());
                    if (vehicle != null)
                        Console.WriteLine(vehicle);
                    else
                        Console.WriteLine($"Vehicle '{input}' can not be found in the garage!");
                }

            } while (string.IsNullOrWhiteSpace(input));
        }
        private void FindVehicleByWord()
        {
            Console.Clear();
            string input = WaitForStringInput("Enter a characteristic to find the vehicle(s): ");

            Vehicle[] vehicles = garageHandler.FindVehicleByString(input);
            if (vehicles.Length > 0)
                foreach (Vehicle v in vehicles)
                {
                    Console.WriteLine(v);
                    Console.WriteLine(new string('*', 30));
                }
            else
                Console.WriteLine("There is no vehicle with this characteristic");
        }
        private void FindVehicleByType()
        {
            string input;
            Vehicle[] vehicles;

            Console.Clear();

            while (true)
            {
                ShowVehicleTypeSelectMenu("Select vehicle type to search for.");
                char c = Console.ReadKey(true).KeyChar;

                switch (c)
                {
                    case '0':
                        return;
                    case '1':
                        input = "Car";
                        break;
                    case '2':
                        input = "Bus";
                        break;
                    case '3':
                        input = "Boat";
                        break;
                    case '4':
                        input = "Airplane";
                        break;
                    case '5':
                        input = "Motorcycle";
                        break;
                    default:
                        InvalidInput();
                        continue;
                }

                Console.WriteLine();
                if (input.Length > 0)
                {
                    vehicles = garageHandler.FindVehicleByType(input);
                    if (vehicles.Length > 0)
                        foreach (var vehicle in vehicles)
                        {
                            Console.WriteLine(vehicle);
                            Console.WriteLine(new string('*', 30));
                        }

                    else
                    {
                        Console.WriteLine($"There are no vehicles of type '{vehicleTypes[(int)char.GetNumericValue(c)]}' in the garage.");
                    }
                    WaitForAnyInput();
                }

            }
        }
        private void ParkVehicleToGarage()
        {
            int n1;
            string s1;
            bool b1;
            Vehicle vehicleParams;

            if (!garageHandler.HasSpace())
            {
                Console.WriteLine(Environment.NewLine + "Garage is full!");
                return;
            }

            ShowVehicleTypeSelectMenu("Which type of vehicle do you want to park");

            switch (Console.ReadKey().KeyChar)
            {
                case '0':
                    return;
                case '1':
                    vehicleParams = VehicleParams();
                    while ((s1 = WaitForStringInput("Fuel type: ")) == "-1") ;
                    garageHandler.AddVehicle(new Car(vehicleParams, s1));
                    break;
                case '2':
                    vehicleParams = VehicleParams();
                    while ((n1 = WaitForNumberInput("Number of Seats: ")) == -1) ;
                    garageHandler.AddVehicle(new Bus(vehicleParams, n1));
                    break;
                case '3':
                    vehicleParams = VehicleParams();
                    while ((n1 = WaitForNumberInput("Number of Seats: ")) == -1) ;
                    garageHandler.AddVehicle(new Boat(vehicleParams, n1));
                    break;
                case '4':
                    vehicleParams = VehicleParams();
                    while ((n1 = WaitForNumberInput("Number of Engines: ")) == -1) ;
                    garageHandler.AddVehicle(new Airplane(vehicleParams, n1));
                    break;
                case '5':
                    vehicleParams = VehicleParams();
                    while ((n1 = WaitForNumberInput("Cylinder Volume: ")) == -1) ;
                    garageHandler.AddVehicle(new Motorcycle(vehicleParams, n1));
                    break;
                default:
                    InvalidInput();
                    break;
            }
        }

        private void ExitFromGarage()
        {
            string input;
            Console.Clear();
            if (garageHandler.GetAllVehicles().Length != 0)
            {
                do
                {

                    input = WaitForStringInput("Press 0 to exit\nRegistration number of the vehicle that will leave the garage: \n(Press ENTER to view all vehicles)> ");
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        foreach (string space in garageHandler.GetAllVehicles())
                            Console.WriteLine(space);
                        Console.WriteLine(new string('*', 30));
                    }
                    else
                    {
                        if (garageHandler.RemoveVehicle(input.ToUpper()))
                        {
                            Console.WriteLine($"Vehicle '{input}' left the garage");
                        }
                        else if (input == "0") break;
                        else
                        {
                            Console.WriteLine($"Failed because vehicle '{input}' is not in the garage.");
                            input = "";
                        }
                    }
                } while (string.IsNullOrWhiteSpace(input));
            }
            else
            {
                Console.WriteLine("There are no vehicles in the garage!");

            }
        }
        private void ShowVehicleTypeSelectMenu(string input)
        {
            Console.Clear();
            Console.WriteLine($"\n{input}\n");

            for (int i = 1; i < vehicleTypes.Length; i++)
            {
                Console.WriteLine($"{i}. {vehicleTypes[i]}");
            }
            Console.WriteLine($"0. {vehicleTypes[0]}");

            Console.Write("\n> ");
        }

        private void WaitForAnyInput()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private string WaitForStringInput(string input)
        {
            Console.Write(input);
            return Console.ReadLine();
        }


        private int WaitForNumberInput(string info)
        {
            string input;
            Console.Write(info);
            input = Console.ReadLine();
            try
            {
                return int.Parse(input);
            }
            catch (ArgumentNullException ex)
            {
                Console.Error.WriteLine($"Enter a value: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.Error.WriteLine($"Enter only numbers: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.Error.WriteLine($"Enter a number that is smaller: {ex.Message}");
            }

            return -1;
        }

        private Vehicle VehicleParams()
        {
            string input;
            string regNum;
            int wheelCount = 0;
            string color;
            Console.Clear();
            Console.WriteLine("Enter details about the vehicle");
            bool verifyRegistrationNumber;
            do
            {
                Console.Write("Registration number: ");
                input = Console.ReadLine().ToUpper();
                verifyRegistrationNumber = VerifyRegNum(input);
                if (!verifyRegistrationNumber)
                    Console.WriteLine($"'{input}' is not a valid registration number.");
            } while (!verifyRegistrationNumber);
            regNum = input;

            verifyRegistrationNumber = false;
            do
            {
                Console.Write("Number of wheels: ");
                input = Console.ReadLine();
                try
                {
                    wheelCount = int.Parse(input);
                    verifyRegistrationNumber = true;
                }
                catch (ArgumentNullException ex)
                {
                    Console.Error.WriteLine($"Enter a value: {ex.Message}");
                }
                catch (FormatException ex)
                {
                    Console.Error.WriteLine($"Enter only numbers: {ex.Message}");
                }
                catch (OverflowException ex)
                {
                    Console.Error.WriteLine($"Enter a number that is smaller: {ex.Message}");
                }

            } while (!verifyRegistrationNumber);

            verifyRegistrationNumber = false;
            do
            {
                Console.Write("Color: ");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    Console.WriteLine("Enter a color");
                else
                    verifyRegistrationNumber = true;

            } while (!verifyRegistrationNumber);
            color = input;

            return new Vehicle(regNum, color, wheelCount);
        }
        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("**** Garage ****\n");

            for (int i = 1; i < menuOptions.Length; i++)
            {
                Console.WriteLine($"{i}. {menuOptions[i]}");
            }
            Console.WriteLine($"0. {menuOptions[0]}");

            Console.Write(Environment.NewLine + "> ");
        }

        private void InvalidInput()
        {
            Console.WriteLine("\nInvalid selection, press any key to continue.");
            Console.ReadKey();
        }

        private bool VerifyRegNum(string regNum)
        {
            Regex registrationCheckRegex = new Regex(@"[A-HJ-PR-UW-Z]{3}\d{3}$");
            if (registrationCheckRegex.IsMatch(regNum))
                return true;
            else
                return false;
        }

    }

}
