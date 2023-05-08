/* Project file name : Assignment 4
 * Purpose of program : To Create a Car Inventory, in which, User Can add 3 Brands with their Name, Body Type and Years.
 *                       User Can Edet Information Of Car and User can delete any information of Car, too. 
 *                       User can display the stored information of Cars.
 * 
 * Revision History:
 *     Created bt Jay Jasoliya, 25-03-2023, 
                  Rutvi Mistry, 31-03-2023.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace A4JasoliyaJMistryR
{
    internal class Program
    {
        static string[] carBrands = new string[3]; // Array to store car brands
        static List<string> carInventory = new List<string>(); // List to store car inventory
        static int inventoryCount = 0; // Number of cars in inventory
        static void Main(string[] args)
        {
            int choice = 0;



            // Get the name of each car brand from the user

            for (int i = 0; i < carBrands.Length; i++)
            {
                Console.Write($"Enter car brand #{i + 1}: ");
                carBrands[i] = Console.ReadLine();
            }
            Console.Clear();

            // Display the main menu and get the user's choice

            while (choice != 5)
            {
                Console.WriteLine("\nMain Menu");
                Console.WriteLine("1. Add New Car");
                Console.WriteLine("2. Edit Existing Car");
                Console.WriteLine("3. Delete Car");
                Console.WriteLine("4. Display All Cars");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice (1-5): ");

                // Validate user input

                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 5)
                {
                    Console.Clear();
                    switch (choice)
                    {
                        case 1:
                            AddNewCar();
                            break;
                        case 2:
                            EditExistingCar();
                            break;
                        case 3:
                            DeleteExistingCar();
                            break;
                        case 4:
                            DisplayAllCars();
                            break;
                        case 5:
                            Console.WriteLine("Goodbye!");
                            break;
                    }
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Invalid choice! Please enter a number between 1 and 5.");
                }

            }
            Console.Clear(); ;
        }

        static void AddNewCar()
        {
            string brand = "";
            string body = "";
            int bodyType = 0;
            bool validInput = false;
            string year = "";
            int carYear = 0;
            string answer = "";
            bool validInput1 = false;

            // Ask user if they want to add new car or not

            Console.WriteLine("\nAdd New Car");

            // Ask user to enter the car brand

            Console.Write("Enter the car brand (");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{carBrands[i]}");
                if (i != 2) Console.Write("/");
            }
            Console.Write("): ");

            try
            {
                brand = Console.ReadLine();
                if (!carBrands.Contains(brand))
                {
                    throw new Exception("Invalid brand!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please enter a valid brand.");
                AddNewCar();
                return;
            }

            // Ask user to select bodytype of the car

            while (!validInput)
            {
                Console.WriteLine("Select body type:");
                Console.WriteLine("1. Sedan");
                Console.WriteLine("2. Hatchback");
                Console.WriteLine("3. SUV");
                Console.WriteLine("4. Pickup Truck");
                Console.Write("Enter the body type (1-4): ");

                try
                {
                    bodyType = int.Parse(Console.ReadLine());

                    if (bodyType >= 1 && bodyType <= 4)
                    {
                        validInput = true;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Please enter a valid body type (1-4).");
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a valid body type (1-4).");
                }
            }

            // shows the output of selected body type

            switch (bodyType)
            {
                case 1:
                    body = "1";
                    Console.WriteLine("Selected Body Type is : Sedan");
                    break;
                case 2:
                    body = "2";
                    Console.WriteLine("Selected Body Type is : Hatchback");
                    break;
                case 3:
                    body = "3";
                    Console.WriteLine("Selected Body Type is : SUV");
                    break;
                case 4:
                    body = "4";
                    Console.WriteLine("Selected Body Type is : Pickup Truck");
                    break;
                default:
                    break;
            }

            // Ask user to enter a year of the car

            while (!validInput1)
            {
                Console.Write("Enter the year (1900-2024): ");

                try
                {
                    carYear = int.Parse(Console.ReadLine());

                    if (carYear >= 1900 && carYear <= 2024)
                    {
                        validInput1 = true;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Please enter a valid year (1900-2024).");
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a valid year (1900-2024).");
                }
            }

            // Ask user if they want to add another car
           
                year = carYear.ToString();
                Console.WriteLine("Selected year: " + year);

                string carInfo = $"{brand}-{body}-{year}";
                Console.WriteLine($"\n{carInfo}");
                carInventory.Add(carInfo);
                
                Console.WriteLine("\nCar information saved.");
            do
            {
                Console.Write("Do you want to add another car ? (y/n) : ");
                try
                {
                    answer = Console.ReadLine();

                    if (answer.ToLower()=="y" )
                    {
                        AddNewCar();
                        break;
                    }
                    else if (answer.ToLower() == "n")
                    {
                        break;                     
                    }
                    else
                    {
                        throw new Exception();
                    }
                    
                }
                catch (Exception)
                {
                    
                    Console.WriteLine("\nInvalid Answer ! Please enter 'y' or 'n'.");
                }
            } while (true);
            
        }
        static void EditExistingCar()
        {
            Console.WriteLine("Enter the car information you want to edit in the format: Brand-Body-Year");
            string carInfo = Console.ReadLine();

            // Search for the car in the inventory

            int carIndex = carInventory.IndexOf(carInfo);
            if (carIndex == -1)
            {
                Console.WriteLine("Car not found");
                return;
            }

            Console.WriteLine("Car information found");
            string[] carParts = carInfo.Split('-');

            // Get new brand

            Console.Write("Enter the new brand: ");
            string newBrand = Console.ReadLine();
            while (string.IsNullOrEmpty(newBrand))
            {
                Console.Write("Invalid input. Enter the new brand: ");
                newBrand = Console.ReadLine();
            }

            // Get new body type

            Console.WriteLine("Select body type:");
            Console.WriteLine("1. Sedan");
            Console.WriteLine("2. Hatchback");
            Console.WriteLine("3. SUV");
            Console.WriteLine("4. Pickup Truck");
            Console.Write("Enter the new body type (1-4): ");

            string newBodyType = Console.ReadLine();
            while (string.IsNullOrEmpty(newBodyType))
            {
                Console.Write("Invalid input. Enter the new body type: ");
                newBodyType = Console.ReadLine();
            }

            // Get new year

            Console.Write("Enter the new year: ");
            int newYear;

            while (!int.TryParse(Console.ReadLine(), out newYear))
            {
                Console.Write("Invalid input. Enter the new year: ");
            }

            // Update car information in the inventory

            string newCarInfo = $"{newBrand}-{newBodyType}-{newYear}";
            carInventory[carIndex] = newCarInfo;

            Console.WriteLine("Record updated");
        }
        static void DeleteExistingCar()
        {
            // Ask the user for the car they want to delete

            Console.Write("Enter the car you want to delete in the format: Brand-Body-Year (e.g. Ford-1-2022): ");
            string carToDelete = Console.ReadLine();

            // Check if the car exists in the inventory

            int carIndex = carInventory.IndexOf(carToDelete);
            if (carIndex == -1)
            {
                Console.WriteLine("Car not found.");
                return;
            }

            // Confirm if the user wants to delete the car

            Console.Write("Car found. Are you sure you want to delete it? y/n: ");
            string confirmation = Console.ReadLine();

            if (confirmation.ToLower() == "y")
            {
                // Remove the car from the inventory

                carInventory.RemoveAt(carIndex);
                inventoryCount--;
                Console.WriteLine("Car successfully deleted.");
            }
            else
            {
                Console.WriteLine("Deletion cancelled.");
            }
        }
        static void DisplayAllCars()
        {
            // show the output of the list of cars from inventory

            Console.WriteLine("List of all cars in inventory:");

            foreach (string car in carInventory)
            {
                Console.WriteLine(car);
            }

            Console.WriteLine("\nPress Enter to return to the main menu.");
            Console.ReadLine();
        }

    }
}