using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var ParkingGarage = new ParkingGarage();
            ParkingGarage.MainMenu();

            Console.WriteLine("Tryck ned tangent för att start");
            Console.ReadKey(true);
        }
    }
    class ParkingGarage
    {
        private string[] parking = new string[100];
        public void MainMenu()
        {


            int number = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Clear();
                Console.WriteLine("Hi! And Welcome to Prague parking assistance!");
                Console.WriteLine("How can i be of service?");
                Console.WriteLine("1) Park a vehicle");
                Console.WriteLine("2) Relocate vehicles");
                Console.WriteLine("3) Search for a vehicle by registration number");
                Console.WriteLine("4) Quit");
                Console.WriteLine("5) Print the array");
                Console.WriteLine("Make a selection:");
                number = int.Parse(Console.ReadLine());

                switch (number)
                {
                    case 1:
                        {
                            ParkVehicle();
                            break;
                        }
                    case 2:
                        {
                            //RelocateVehicle();
                            break;
                        }
                    case 3:
                        {
                            //SearchVehicle();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Thanks for using Prague parking assistance");
                            Console.WriteLine("Have a nice day!");
                            break;
                        }
                    case 5:
                        {
                            PrintArray();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            } while (number != 0);
            
            
        }

       

        public void ParkVehicle()
        {
            Console.WriteLine("What type of vehicle do you want to park?");
            string regNumberCar;
            string regNumberMc;
            int lenght;
            int compare;
            switch (Console.ReadLine())
            {
                case "car":
                    {
                        //Console.WriteLine("Skriv in registeringsnummer på ditt fordon");
                        //regNumberCar = Console.ReadLine();
                        //lenght = regNumberCar.Length;
                        //compare = 10;
                        //CompareLenghtOnString(lenght, compare);
                        Parking();
                        
                        DoneParking();
                        break;
                    }
                case "mc":
                    {
                        Console.WriteLine("Skriv in registeringsnummer på ditt fordon");
                        regNumberMc = Console.ReadLine();
                        lenght = regNumberMc.Length;
                        compare = 10;
                        CompareLenghtOnString(lenght, compare);
                        //Parking(regNumberMc);
                        DoneParking();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Please enter (car/mc)");
                        ParkVehicle();
                        break;
                    }
            }
        }

        public void Parking()
        {
            string regNumberCar;


            for (int i = 0; i < parking.Length; i++)
            {
                Console.WriteLine("Skriv in ditt regnr:");
                regNumberCar = Console.ReadLine();
                parking[i] = regNumberCar;

            }
            //for (int i = 0; i < parking.Length; i++)
            //{ 
            //Console.WriteLine("Skriv in ditt regnr:");
            //string regNumberCar = Console.ReadLine();
            //Array.Resize(ref parking, parking.Length + 1);
            //parking[parking.Length - 1] = regNumberCar;
            //}
            Array.Sort(parking);
            foreach (var e in parking)
            {
                Console.WriteLine(e);
            }
        }

        private void CompareLenghtOnString(int lenght, int compare)
        {
            if (lenght > compare)
            {
                Console.WriteLine("YAAA BLYAT IDIOT TOO MANY CHARACTERS!(max 10 chars)");
            }
        }

        private void DoneParking()
        {
            Console.WriteLine("Har du Parkerat klart?(y/n)");
            string answer = Console.ReadLine().ToLower();
            string yes = "y";
            string no = "n";
            if (answer == yes)
            {
                MainMenu();
            }
            while (answer == no)
            {
                ParkVehicle();
                break;
            }
        }
        public void PrintArray()
        {
            for (int j = 0; j < parking.Length; j++)
            {
                Console.WriteLine("Dina bilar står här:" , parking[j]);
            }
            Console.ReadLine();
        }

    }        
}
