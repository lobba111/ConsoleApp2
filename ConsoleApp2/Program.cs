using System;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        public static void Main(string[] args)
        {
            string[] parking = new string[101];
            Array.Fill(parking, "LEDIGT");
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu(parking);
            }
            Console.WriteLine("Tryck ned tangent för att start");
            Console.ReadKey(true);
        }
            public static bool MainMenu(string[] parking)
            {

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

                    switch (Console.ReadLine().ToLower())
                    {
                        case "1":
                            {
                                ParkVehicle(parking);
                                return true;
                            }
                        case "2":
                            {
                                RelocateVehicle(parking);
                                return true;
                            }
                        case "3":
                            {
                                SearchVehicle(parking);
                                return true;
                            }
                        case "q":
                            {
                                Console.WriteLine("Thanks for using Prague parking assistance");
                                Console.WriteLine("Have a nice day!");
                                return false; 
                                
                            }
                        case "5":
                            {
                                PrintArray(parking);
                                return true;
                            }
                        default:
                            {
                                Console.WriteLine("Error: Invalid Input");
                                return true;
                            }
                    }
                }
            }
        
        public static void SearchVehicle(string[] parking)
        {
            Console.WriteLine("Car or MC");
            switch (Console.ReadLine().ToUpper())
            {
                case "CAR":
                    {
                    Console.WriteLine("Type the registration number: ");
                    string hit = "CAR" + "_" + Console.ReadLine().ToUpper() + "%";
                    for (int i = 1; i < parking.Length - 1; i++)
                        {
                        if (hit == parking[i])
                            {
                            Console.WriteLine("{0} is located at {1}", hit, i);
                            }
                        }
                        Console.ReadKey();
                        return;
                    }
                case "MC":
                    {
                        Console.WriteLine("Type the registration number: ");
                        string hit = "MC" + "_" + Console.ReadLine().ToUpper();
                        for (int i = 100; i > 1; i--)
                        {
                                if (hit == parking[i])
                                {
                                    continue;
                                }
                                if (parking[i].Contains('#'))
                                {
                                    Console.WriteLine("{0} is located at {1}", hit, i);
                                    break;
                                }

                        }
                        
                        
                        Console.ReadKey();
                        return;
                    }


                default:
                    {
                        Console.WriteLine("Invalid Input!");
                        return;
                    }
                    
                    
            }
            
        }

        public static void RelocateVehicle(string[] parking)
        {
            Console.WriteLine("Car or MC");
            switch (Console.ReadLine().ToUpper())
            {
                case "CAR":
                    {
                        Console.WriteLine("Type the registration number: ");
                        string hit = "CAR" + "_" + Console.ReadLine().ToUpper() + "%";
                        for (int i = 1; i < parking.Length - 1; i++)
                        {
                            if (hit == parking[i])
                            {
                                Console.WriteLine("{0} is located at {1}", hit, i);
                            }
                        
                        Console.WriteLine("Do you wish to relocate? (y/n)");
                        string answer = Console.ReadLine().ToLower();
                        string yes = "y";
                        string no = "n";
                        if (answer == yes)
                        {
                            Console.WriteLine("Enter a Parkingspot: (1-100)");
                            string relocate = Console.ReadLine();
                            int index = int.Parse(relocate);
                            var buffer = parking[i];
                            parking[i] = parking[index];
                            parking[index] = buffer;
                            Console.WriteLine("Car: {0}, Successfully moved to spot : {1}", hit, index);
                            Console.ReadKey();
                            MainMenu(parking);
                        }
                        while (answer == no)
                        {
                            ParkVehicle(parking);
                            break;
                        }
                        }

                        return;
                    }
                case "MC":
                    {
                        Console.WriteLine("Type the registration number: ");
                        string hit = "MC" + "_" + Console.ReadLine().ToUpper();
                        for (int i = 1; i < parking.Length - 1; i++)
                        {
                            if (hit == parking[i])
                            {
                                Console.WriteLine("{0} is located at {1}", hit, i);
                            }

                            Console.WriteLine("Do you wish to relocate? (y/n)");
                            string answer = Console.ReadLine().ToLower();
                            string yes = "y";
                            string no = "n";
                            if (answer == yes)
                            {
                                Console.WriteLine("Enter a Parkingspot: (1-100)");
                                string relocate = Console.ReadLine();
                                int index = int.Parse(relocate);
                                    //parking[i] = hit.Remove('#', '%');
                                    parking[i] = hit.TrimEnd('#', '%');
                                    var buffer = parking[i];
                                    parking[i] = parking[index];
                                    parking[index] = buffer;
                                    Console.WriteLine("MC: {0}, Successfully moved to spot : {1}", hit, index);
                                    Console.ReadKey();
                                    MainMenu(parking);
                                
                                
                                

                            }
                            while (answer == no)
                            {
                                ParkVehicle(parking);
                                break;
                            }
                        }

                        return;
                    }


                default:
                    {
                        Console.WriteLine("Invalid Input!");
                        return;
                    }


            }

            //if (parking[i] == regnummer)
            //{
            //    continue;
            //}
            //int index = int.Parse(parking[i]);
            //var index = parking[i].IndexOf("CAR_", '%', +1);

            //if (parking[i].Contains("LEDIGT"))
            //{
            //    continue;
            //}
            //if (parking.Length <= y || parking.Length <= index) return false;
            //{
            //    var buffer = parking[i];
            //    parking[i] = parking[y];
            //    parking[y] = buffer;
            //}



            //Console.WriteLine("Ange Regnummer: ");
            //string regnummer = Console.ReadLine().ToUpper(); 
            //for (int i = 1; i < parking.Length -1; i++)
            //{
            //    parking[i].ToString();
            //    var index = parking[i].IndexOf(regnummer[i], '_', +1);
            //    Console.WriteLine("test : {0}", index);

            //}

        }

        public static void ParkVehicle(string[] parking)
            {
                string car = "car".ToUpper();
                string mc = "mc".ToUpper() ;
                Console.WriteLine("What type of vehicle do you want to park?");
                switch (Console.ReadLine().ToLower())
                {
                    case "car":
                        {
                            ParkingCar(car, parking);
                            DoneParking(parking);
                            break;
                        }
                    case "mc":
                        {
                            ParkingMC(mc, parking);
                            DoneParking(parking);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter (car/mc)");
                            ParkVehicle(parking);
                            break;
                        }
                }
            }
        public static void ParkingCar(string car, string[] parking)
            {
                string regNumberCar;
                for (int i = 1; i < 2; i++)
                {  
                    Console.WriteLine("Skriv in ditt regnr:");
                    regNumberCar = car + "_" + Console.ReadLine().ToUpper() + "%";
                if (!parking[i].Contains("LEDIGT"))
                {
                    i++;
                }
                    parking[i] = regNumberCar;
                }
                
            }
            public static void ParkingMC(string mc, string[] parking)
            {
                string regNumberMc;
                Console.WriteLine("Skriv in ditt regnr: ");
                regNumberMc = mc + "_" + Console.ReadLine().ToUpper();
                for (int i = 100; i > 1; i--)
                {
                    
                    if (parking[i].Contains('%'))
                    {
                        continue;
                    }
                    if (parking[i].Contains("LEDIGT"))
                    {
                        parking[i] = regNumberMc + '#';
                        DoneParking(parking);
                    }
                    if (parking[i].Contains('#'))
                    {
                        parking[i] += regNumberMc + '%';
                    }
                DoneParking(parking);
                   
                }
                
            }
            private static void CompareLenghtOnString(int lenght, int compare)
            {
                if (lenght > compare)
                {
                    Console.WriteLine("YAAA BLYAT IDIOT TOO MANY CHARACTERS!(max 10 chars)");
                }
            }

            private static void DoneParking(string[] parking)
            {
                Console.WriteLine("Har du Parkerat klart?(y/n)");
                string answer = Console.ReadLine().ToLower();
                string yes = "y";
                string no = "n";
                if (answer == yes)
                {
                    MainMenu(parking);
                }
                while (answer == no)
                {
                    ParkVehicle(parking);
                    break;
                }
            }
            public static void PrintArray(string[] parking)
            {
            Console.Clear();
            for (int j = 1; j < parking.Length; j++)
            {
                //var charsToHide = new char[] { '%', '#' };
                //foreach (var c in charsToHide)
                //{
                //    parking[j] = parking[j].Trim(charsToHide);
                //}

                if (parking[j].Contains("LEDIGT"))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("Plats: {0}", j);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" {0}", parking[j]);
                    Console.ResetColor();
                }
                if (!parking[j].Contains("LEDIGT"))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("Plats: {0}", j);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" {0}", parking[j]);
                    Console.ResetColor();
                }
            }
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Press any Key to Continue..."); Console.ReadKey();
                    MainMenu(parking);
            }    
    }
}
  



