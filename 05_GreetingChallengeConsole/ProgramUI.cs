using _05_Greeting_Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _05_GreetingChallengeConsole
{
    public class ProgramUI
    {
        public CustomerContent_Repo _repo = new CustomerContent_Repo();
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
                Console.WriteLine("Enter the option you'dlike to select:\n" +
                    "1.View customer database\n" +
                    //"2.Find customer by name\n" +
                    "2.Add new customer\n" +
                    "3.Update customer profile\n" +
                    "4 Delete customer profile\n" +
                    "5.Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ShowAllCustomers();
                        break;
                    //case "2":
                        //FindCustomerByName();
                       // break;
                    case "2":
                        AddNewCustomer();
                        break;
                    case "3":
                        UpdateExistingContent();
                        break;
                    case "4":
                        DeleteCustomerByName();
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
        public void ShowAllCustomers()
        {
            Console.Clear();
            List<CustomerContent> listOfContent = _repo.GetContents();
            foreach (CustomerContent content in listOfContent)
            {
                DisplayContent(content);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public void UpdateExistingContent()
        {

            Console.Clear();
            Console.WriteLine("Enter the name of the person's data you'd like to update.");
            string firstName = Console.ReadLine();
            CustomerContent oldItem = _repo.FindPersonByName(firstName);
            if (oldItem == null)
            {
                Console.WriteLine("Person not found, press any key to continue...");
                Console.ReadKey();
                return;
            }
            CustomerContent newItem = new CustomerContent(
                oldItem.FirstName,
                oldItem.LastName,
                oldItem.Type,
                oldItem.Email
            );
            Console.WriteLine("Which property would you like to update:\n" +
                    "1. First Name\n" +
                    "2. Last Name\n" +
                    "3. Type\n" +
                    "4. Email Message\n" +
                    "5. Nevermind");
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    Console.WriteLine("Enter a new first name.");
                    string newFirstName = Console.ReadLine();
                    newItem.FirstName = newFirstName;
                    bool wasSuccessful = _repo.UpdateExistingContent(firstName, newItem);
                    if (wasSuccessful)
                    {
                        Console.WriteLine("First Name successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Could not update {firstName}");
                    }
                    break;
                default:
                    break;
                case "2":
                    Console.WriteLine("Enter a new last name.");
                    string newLastName = Console.ReadLine();
                    newItem.LastName = newLastName;
                    break;
                case "3":
                    Console.WriteLine("Enter a new customer type.");
                    string newType = Console.ReadLine();
                    newItem.Type = newType;
                    break;
                case "4":
                    Console.WriteLine("Enter a new email message letter.");
                    string newEmail = Console.ReadLine();
                    newItem.Email = newEmail;
                    break;
            }

        }
        public void AddNewCustomer()
        {
            Console.Clear();
            CustomerContent newContent = new CustomerContent();
            Console.WriteLine("Please enter a first name.");
            newContent.FirstName = Console.ReadLine();
            Console.WriteLine("Please enter a last name.");
            newContent.LastName = Console.ReadLine();
            Console.WriteLine("Please enter a type for this customer.\n" +
                "1. Potential.\n" +
                "2. Current.\n" +
                "3. Past.");
            newContent.Type = Console.ReadLine();
            Console.WriteLine("Please enter message to be sent to customer email.\n" +
                " A.We currently have the lowest rates on Helicopter Insurance!\n" +
                " B.Thank you for your work with us. We appreciate your loyalty. Here's a coupon.\n" +
                " C.It's been a long time since we've heard from you, we want you back");
            newContent.Email = Console.ReadLine();
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
        public void FindCustomerByName()
        {
            Console.Clear();

            Console.WriteLine("Enter the name of the person you'd like to find.");
            string firstName = Console.ReadLine();

            CustomerContent content = _repo.FindPersonByName(firstName);

            if (content != null)
            {
                DisplayContent(content);
            }
            else
            {
                Console.WriteLine("That person doesn't exist");
            }
        }
        public void DeleteCustomerByName()
        {
            Console.WriteLine("Enter the name of the person you would like to delete");
            string firstNameToDelete = Console.ReadLine();

            CustomerContent contentToDelete = _repo.FindPersonByName(firstNameToDelete);
            bool wasDeleted = _repo.DeleteCustomerByName(contentToDelete);

            if (wasDeleted)
            {
                Console.WriteLine("This content was successfully deleted");
            }
            else
            {
                Console.WriteLine("Person could not be deleted");
            }
        }
        public void DisplayContent(CustomerContent content)
        {
            Console.WriteLine($"FirstName: {content.FirstName}");
            Console.WriteLine($"LastName: {content.LastName}");
            Console.WriteLine($"Customer Type: {content.Type}");
            Console.WriteLine($"Email Message: {content.Email}");

        }
    }
}