using _01_CafeChallenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeChallengeConsole
{
    public class ProgramUI
    {
        public CafeContent_Repo _repo = new CafeContent_Repo();
        public void Run()
        {
            Menu();
            SeedContent();
        }
        public void SeedContent()
        {
            CafeContent bigMac = new CafeContent(
                "Big Mac",
                "from Mcdonalds",
                "buns, patty, lettuce, onion, pickles, secret sauce",
                1,
                10
                );
            _repo.AddContentToDirectory(bigMac);
        }
        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the option you'd like to select:\n" +
                    "1. Show all items in menu\n" +
                    "2. Add new item to menu\n" +
                    "3. Update existing menu item\n" +
                    "4. Remove item from menu\n" +
                    "5. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        // Show all content
                        ShowAllContent();
                        break;
                    //case "2":
                        //Get content by mealname
                        //ShowContentByMealName();
                       // break;
                    case "2":
                        //Create new streaming content
                        CreateNewItem();
                        break;
                    case "3":
                        //Update existing content
                        UpdateExistingContent();
                        break;
                    case "4":
                        // Delete existing content
                        DeleteContentByMealName();
                        break;
                    case "5":
                        //Exit
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void ShowAllContent()
        {
            Console.Clear();
            List<CafeContent> listOfContent = _repo.GetContents();
            foreach (CafeContent content in listOfContent)
            {
                DisplayContent(content);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public void UpdateExistingContent()
        {
            // Finish this method
            Console.Clear();
            Console.WriteLine("Enter the mealname of the content you'd like to update.");
            string mealname = Console.ReadLine();
            CafeContent oldItem = _repo.GetContentByItem(mealname);
            if (oldItem == null)
            {
                Console.WriteLine("Meal not found, press any key to continue...");
                Console.ReadKey();
                return;
            }
            CafeContent newItem = new CafeContent(
                oldItem.MealName,
                oldItem.Description,
                oldItem.Ingredients,
                oldItem.MealId,
                oldItem.Price
            );
            Console.WriteLine("Which property would you like to update:\n" +
                    "1. Meal Name\n" +
                    "2. Description\n" +
                    "3. Ingredients\n" +
                    "4. Meal ID\n" +
                    "5. Price\n" +
                    "6. Cancel");
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    Console.WriteLine("Enter a new mealname");
                    string newMealName = Console.ReadLine();
                    newItem.MealName = newMealName;
                    bool wasSuccessful = _repo.UpdateExistingContent(mealname, newItem);
                    if (wasSuccessful)
                    {
                        Console.WriteLine("Item successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Could not update {mealname}");
                    }
                    break;
                default:
                    break;
                case "2":
                    Console.WriteLine("Enter a new Meal description.");
                    string newDescription = Console.ReadLine();
                    newItem.Description = newDescription;
                    break;
                case "3":
                    Console.WriteLine("Update meal ingredients");
                    string newIngredients = Console.ReadLine();
                    newItem.Ingredients = newIngredients;
                    break;
                case "4":
                    Console.WriteLine("Enter a new Meal ID number");
                    string mealIdAsString = Console.ReadLine();
                    double mealIdAsDouble = double.Parse(mealIdAsString);
                    newItem.MealId = mealIdAsDouble;
                    break;
                case "5":
                    Console.WriteLine("Enter a new Meal price");
                    string priceAsString = Console.ReadLine();
                    double priceAsDouble = double.Parse(priceAsString);
                    newItem.Price = priceAsDouble;
                    break;
            }

        }

        public void CreateNewItem()
        {
            Console.Clear();
            CafeContent newContent = new CafeContent();
            Console.WriteLine("Please enter a meal name.");
            newContent.MealName = Console.ReadLine();
            Console.WriteLine("Please enter a description.");
            newContent.Description = Console.ReadLine();
            Console.WriteLine("Please enter the ingredients for this meal.");
            newContent.Ingredients = Console.ReadLine();
            Console.WriteLine("Please create a ID number for your meal.");
            string mealIdAsString = Console.ReadLine();
            double mealIdAsDouble = double.Parse(mealIdAsString);
            newContent.MealId = mealIdAsDouble;
            Console.WriteLine("Enter the price for this meal.");
            string priceAsString = Console.ReadLine();
            double priceAsDouble = double.Parse(priceAsString);
            newContent.Price = priceAsDouble;
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

        //public void ShowContentByMealName()
       // {
            //Console.Clear();

           // Console.WriteLine("Enter the mealname of the content you'd like to see.");
            //string mealname = Console.ReadLine();

           // CafeContent content = _repo.GetContentByItem(mealname);

            //if (content != null)
           // {
           //     DisplayContent(content);
           // }
           // else
           // {
          //      Console.WriteLine("That mealname doesn't exist");
           // }
       // }

        public void DeleteContentByMealName()
        {
            Console.WriteLine("Enter the mealname for the content you would like to delete");
            string mealnameToDelete = Console.ReadLine();

            CafeContent contentToDelete = _repo.GetContentByItem(mealnameToDelete);
            bool wasDeleted = _repo.DeleteContentByMealName(contentToDelete);

            if (wasDeleted)
            {
                Console.WriteLine("This content was successfully deleted");
            }
            else
            {
                Console.WriteLine("Content could not be deleted");
            }
        }
        public void DisplayContent(CafeContent content)
        {
            Console.WriteLine($"MealName: {content.MealName}");
            Console.WriteLine($"Description: {content.Description}");
            Console.WriteLine($"Ingredients: {content.Ingredients}");
            Console.WriteLine($"Meal ID {content.MealId}");
            Console.WriteLine($"Price: {content.Price}");
        }

    }
}