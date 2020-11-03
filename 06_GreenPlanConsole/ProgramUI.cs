using _06_GreenPlan_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlanConsole
{
    public class ProgramUI
    {
        public GreenPlanContent_Repo _repo = new GreenPlanContent_Repo();
        public void Run()
        {
            Menu();
        }
        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Enter the option you'd like to select:\n" +
                    "1.View vehicle database\n" +
                    //"2.Find customer by name\n" +
                    "2.Add new vehicle\n" +
                    "3.Update vehicle database\n" +
                    "4 Delete vehicle database\n" +
                    "5.Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ShowAllCars();
                        break;
                    //case "2":
                    //FindCustomerByName();
                    // break;
                    case "2":
                        AddNewCar();
                        break;
                    case "3":
                        UpdateExistingContent();
                        break;
                    case "4":
                        DeleteVehicleByName();
                        break;
                    case "5":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void ShowAllCars()
        {
            Console.Clear();
            List<GreenPlanContent> listOfContent = _repo.GetContents();
            foreach (GreenPlanContent content in listOfContent)
            {
                DisplayContent(content);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public void UpdateExistingContent()
        {

            Console.Clear();
            Console.WriteLine("Enter the name of the vehicles's data you'd like to update.");
            string cartype = Console.ReadLine();
            GreenPlanContent oldItem = _repo.FindCarByName(cartype);
            if (oldItem == null)
            {
                Console.WriteLine("vehicle not found, press any key to continue...");
                Console.ReadKey();
                return;
            }
            GreenPlanContent newItem = new GreenPlanContent(
                oldItem.CarType,
                oldItem.PriceEstimate,
                oldItem.FuelCost,
                oldItem.Mileage,
                oldItem.CarName

            );
            Console.WriteLine("Which property would you like to update:\n" +
                                "1. CarType\n" +
                                "2. CarName\n" +
                                "3. Price Estimate\n" +
                                "4. Fuel Cost\n" +
                                "5. Mileage\n" +
                                "6. Nevermind");
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    Console.WriteLine("Enter a car type.\n" + 
                        "Gas\n" +
                        "Hybrid\n" +
                        "Electric");
                    string newFirstName = Console.ReadLine();
                    newItem.CarType = newFirstName;
                    bool wasSuccessful = _repo.UpdateExistingContent(cartype, newItem);
                    if (wasSuccessful)
                    {
                        Console.WriteLine("Car Type successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Could not update {cartype}");
                    }
                    break;
                default:
                    break;
                case "2":
                    Console.WriteLine("Enter a new car name");
                    string newCarName = Console.ReadLine();
                    newItem.CarName = newCarName;
                    break;
                case "3":
                    Console.WriteLine("Enter price estimate");
                    string priceEstimateAsString = Console.ReadLine();
                    double priceEstimateAsDouble = double.Parse(priceEstimateAsString);
                    newItem.PriceEstimate = priceEstimateAsDouble;
                    break;
                case "4":
                    Console.WriteLine("Enter Vechile fuel cost");
                    string fuelCostAsString = Console.ReadLine();
                    double fuelCostAsDouble = double.Parse(fuelCostAsString);
                    newItem.FuelCost = fuelCostAsDouble;
                    break;
            }

        }
        public void AddNewCar()
        {
            Console.Clear();
            GreenPlanContent newContent = new GreenPlanContent();
            Console.WriteLine("Enter the type of Vehicle\n" +
                 "Gas.\n" +
                 "Hybrid.\n" +
                 "Electric");
            newContent.CarType = Console.ReadLine();
            Console.WriteLine("Enter a name for the vehicle.");
            newContent.CarName = Console.ReadLine();

            Console.WriteLine("Enter the estimated price for this vehicle");
            string priceEstimateAsString = Console.ReadLine();
            double priceEstimateAsDouble = double.Parse(priceEstimateAsString);
            newContent.PriceEstimate = priceEstimateAsDouble;

            Console.WriteLine("Enter fuel cost for this vehicle (per tank/battery)");
            string fuelCostAsString = Console.ReadLine();
            double fuelCostAsDouble = double.Parse(fuelCostAsString);
            newContent.FuelCost = fuelCostAsDouble;
            bool wasAdded = _repo.AddContentToDirectory(newContent);
            if (wasAdded == true)
            {
                Console.WriteLine("Your content was succesfully added.");
            }
            else
            {
                Console.WriteLine("Oops something went wrong. Your content was not added.");
            }
        }

        public void DeleteVehicleByName()
        {
            Console.WriteLine("Enter the name of the person you would like to delete");
            string firstNameToDelete = Console.ReadLine();

            GreenPlanContent contentToDelete = _repo.FindCarByName(firstNameToDelete);
            bool wasDeleted = _repo.DeleteVehicleByName(contentToDelete);

            if (wasDeleted)
            {
                Console.WriteLine("This vehicle was successfully deleted");
            }
            else
            {
                Console.WriteLine("Vehiclle could not be deleted");
            }
        }
        public void DisplayContent(GreenPlanContent content)
        {
            Console.WriteLine($"Car Type {content.CarType}");
            Console.WriteLine($"Car Name {content.CarName}");
            Console.WriteLine($"Price of Vehicle {content.PriceEstimate}");
            Console.WriteLine($"Cost per tank/battery {content.FuelCost}");
            Console.WriteLine($"Estimated Mileage for 1 Tank {content.Mileage}");

        }
    }
}