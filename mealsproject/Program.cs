﻿using System.ComponentModel;
using System.Reflection.Emit;
using MealsProject.ControllersLayer;
using MealsProject.Models;

class Program
{
    static readonly UserController userController = new UserController();
    static readonly HistoryController historyController = new HistoryController();
    static readonly MenuController menuController = new MenuController();
    static Session? session;
    static void Main(string[] args)

    {
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("~   Welcome to the Meals App Project   ~");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        do
        {
            var userIn = TakeInputWithMessage("Enter your user name:");                      //Using method to get a string name
            var userPw = TakeInputWithMessage("Enter your password:");                       //Using same method to get a string for password
            var userResponse = userController.ValidateUserByNameAndPassword(userIn, userPw); //Casting response to user controller to validate
            var user = (User)userResponse.ObjectResponse;

            if (userResponse.Success && user != null)
            {

                DisplayOptions(1);                                                           //To see the options to select, at the bottom of this prog
                var option = TakeInputWithMessage("what would you like to do next? Enter Option:"); //method to get input

                switch (option)                                   //switch evaluates the number entered in option to the case number
                {
                    case "1":
                        DisplayMenu();
                        break;
                    case "2":
                        ChooseItems(user);
                        break;
                    case "3":
                        DisplayHistoryForSessionUser(user);
                        break;
                    case "4":
                        Console.WriteLine("Thanks for using the Meal App Project");
                        ClearSession();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Option... Try Again");
                        break;

                        /*
                        case "1":
                            // Login Case
                            // You have username, need password
                            var username = TakeInputWithMessage("Input Username:");
                            var userResponse = userController.GetUserByName(username);
                            // Do some kind of conditional check on the password
                            Console.WriteLine(userResponse.Message);    //how to change Console.WriteLine to Output
                            break;
                        case "2":
                            // Register Case
                            var addUsername = TakeInputWithMessage("Input Username to Add:");
                            var addUserResponse = userController.AddUser(addUsername);
                            Console.WriteLine(addUserResponse.Message);  //how to change Console.WriteLine to Output
                            break;
                        case "3":
                            // Should only be possible after the user has logged in
                            // Unless you create some kind of admin user, but the adminshould still login
                            var deleteUsername = TakeInputWithMessage("Input Username to Delete:");
                            var deleteUserResponse = userController.DeleteUser(deleteUsername);
                            Console.WriteLine(deleteUserResponse.Message);  //how to change Console.WriteLine to Output
                            break;
                        case "1":
                            DisplayMenu();
                            break;
                        case "2":
                            TakeOrder(user);
                            break;
                        case "3":
                            Console.WriteLine("Thanks for using the Meal Ordering System");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            break;
                        */
                }
            }
            else
            {
                Console.WriteLine(userResponse.Message);
            }
        } while (true);
    }

    // If a user has already logged in, do you need to ask them for their username again?
    private static void TakeOrder(User user)
    {
        // var loadUsername = TakeInputWithMessage("Load Username:");         //Removing this code to not ask their username again
        // var loadUserResponse = userController.GetUserByName(loadUsername);
        // Console.WriteLine(loadUserResponse.Message);
        // if (loadUserResponse.Success)
        // {
        //     var loadedUser = (User)loadUserResponse.ObjectResponse;
        session = new Session(user);
        // Console.WriteLine($"{loadUsername} is successfully loaded in the session");

        var goBack = false;
        do
        {
            DisplayOptions(2);
            var option = TakeInputWithMessage("What would you like to do next? Enter Option:");
            switch (option)
            {
                case "1":
                    DisplayMenu();                                           //Method to display the menu
                    break;
                case "2":
                    ChooseItems(user);                                       //Method to enter menu item
                    break;
                case "3":
                    DisplayHistoryForSessionUser(user);                      //Method to see history for specific user
                    break;
                case "4":
                    goBack = true;
                    ClearSession();                                          //Method to null the session 
                    break;
                case "5":
                    Console.WriteLine("Thanks for using the meals app!");
                    Environment.Exit(0);                                     //Found this method that terminates the current process passing 0 as successful
                    break;
                default:
                    Console.WriteLine("Invalid Option, Good Bye");
                    break;
            }
        } while (!goBack || session != null);
        //  }
        //  else
        //  {
        //      Console.WriteLine($"{loadUsername} could not be loaded in the session");
        //  }
    }

    private static void ChooseItems(User user)
    {
        DisplayMenu();
        session = new Session(user);
        do
        {
            var menuItemNumber = TakeInputWithMessage("Enter Menu Item Number:");
            var item = (Menu)menuController.GetMenuItem(int.Parse(menuItemNumber)).ObjectResponse;
            session.OrderList.Add(item);
            Console.WriteLine($"{item.ItemName} added to order.\r\n");
        }
        while (TakeInputWithMessage("Add More? (Y/N)").ToUpper() == "Y");
        Console.WriteLine($"Total Amount: ${session.OrderList.Sum(o => o.Price)}");
        if (TakeInputWithMessage("Place Order? (Y/N)").ToUpper() == "Y")
        {
            Console.WriteLine($"Order Placed Successfully, Good Bye");
            WriteHistoryFromSession();
        }
    }

    private static void DisplayMenu()                    //Static means the method DisplayMenu belongs to the program class and not an object of the program class.
    {                                                    //Void menas that the method does not have a return value.
        Console.WriteLine(Environment.NewLine);          //this is a property that adds a new line to a string
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("          * M E N U *            ");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        var menuResponse = menuController.GetAllMenuItems();
        var menuItems = menuResponse.ObjectResponse as List<Menu>;

        foreach (var item in menuItems)
        {
            Console.WriteLine($"{item.Id}=> {item.ItemName} (${item.Price})");
        }
    }

    private static void ClearSession()
    {
        Console.WriteLine("Clearing Session!");
        session = null;
    }

    private static void DisplayHistoryForSessionUser(User user)   //using parameter user
    {
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("       * H i S T O R Y*          ");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        var historyResponse = historyController.GetAllHistoryForUser(user.Id);

        var histories = (List<History>)historyResponse.ObjectResponse;
        if (!histories.Any())
        {
            Console.WriteLine($"No history found for user {user.UserName}");
        }

        foreach (var history in histories)
        {
            Console.WriteLine($"***{history.Date}***");
            Console.WriteLine("--------------------------");
            foreach (var itemNumber in history.ItemNumbers)
            {
                var menuItem = (Menu)menuController.GetMenuItem(itemNumber).ObjectResponse;
                Console.WriteLine($"=>{menuItem.ItemName} ({menuItem.Price})");
            }

            Console.WriteLine("--------------------------\r\n");
        }
        Console.WriteLine("-------History Complete--------");
    }

    private static void WriteHistoryFromSession()
    {
        if (ClearSession == null)
        {
            Console.WriteLine("No user is loaded");
            return;
        }

        DateTime dateTime = DateTime.Now;

        var history = new History
        {
            Date = dateTime.ToString(),
            ItemNumbers = session.OrderList.Select(x => x.Id).ToList(),
            UserId = session.User.Id
        };
        historyController.AddHistory(history);
    }

    // This is a private static method that takes in a message and returns the input of the user after displaying the message given
    private static string TakeInputWithMessage(string Message)
    {
        Console.WriteLine(Message, false);
        var input = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Input cannot be empty, Re-enter please:", false);
            input = Console.ReadLine();
        }
        return input;
    }

    private static void Outpu(string message, bool tab = true)
    {
        var tabstr = tab ? "\t" : string.Empty;
        Console.WriteLine($"{tabstr}{message}");
    }

    private static void DisplayOptions(int level)                      //See the options from start of program
    {
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("  Available Operation Options:   ");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        switch (level)
        {
            //case 1:
            //    Console.WriteLine("1.View Menu    2.Place Order    3.Exit \r\n");
            //    break;
            case 1:
                Console.WriteLine("1.View Menu    2.Place Order    3.View History    4.Log out \r\n");
                break;
            default:
                Console.WriteLine("Invalid Option");
                break;
        }

        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }
}


/*    {

        bool validChoice = true;
        
        Console.WriteLine("Welcome! Please select an option:");
        Console.WriteLine("1 Enter new meal selection");
        Console.WriteLine("2 View all previous meal selections");
        Console.WriteLine("3 Exit");



        do //overall do while loop to collect all user inputs needed
        {
            try
            {
                int returnMenuChoice = Convert.ToInt32(Console.ReadLine());

                switch (returnMenuChoice)
                {
                    case 1:
                        string entreeInput = "";
                        List<string> entreeList = new List<string>();
                        string secondMealAnswer = " ";
                        bool enterSecondEntree = true;

                        decimal price;
                        string priceInput;
                        DateTime date;
                        string dateInput;
                        string entree;

                        //when they enter 1 for Enter Meal Selection, they will come here
                        // wait for them to type a meal out of their heads or present my list of meal options to select with numbers in front of them 
                        // they will select the number of the meal or type a meal
                        // we should ask if they want to add another meal for a max of 2
                        // I will add the meals they have entered or selected to their own selection record

                     do      //nested do while loops to validate user inputs until validChoice is true at each collection point
                       {
                           Console.WriteLine("Please type a meal you desire:");
                           entreeInput = Console.ReadLine();   
                           entreeList.Add(entreeInput);
                           Console.WriteLine("Would you like to enter a second meal? yes or no");
                           secondMealAnswer = Console.ReadLine();
                           if (secondMealAnswer.ToLower().Trim() == "yes")
                             {
                                enterSecondEntree = true;
                             }
                           else if (secondMealAnswer.ToLower().Trim() == "no")
                             {
                                enterSecondEntree = false;
                             }
                            else
                            {
                                enterSecondEntree = false;
                            }
                       }
                       while (enterSecondEntree == true);
                     
                        do //nested do while loops to validate user inputs until validChoice is true at each point
                        {
                            Console.WriteLine("Enter the date of the meal selection using one of the following formats - MM DD YYYY or MM-DD-YYYY:");
                            dateInput = Console.ReadLine();
                            if (!DateTime.TryParse(dateInput, out date) || date > DateTime.Now)
                            {
                                Console.WriteLine("Date must be one of the following format - MM DD YYYY or MM-DD-YYYY, and cannot be in the future. Please Try again");
                            }
                            else
                            {
                                break;
                            }
                        } while (true);

                        Console.WriteLine("The meals you have entered:");
                        foreach (string item in entreeList)
                        {
                            Console.WriteLine(item);
                        }

                        validChoice = true;
                        break;

                    case 2:
                                                
                        Console.WriteLine("DISPLAY ALL PREVIOUS MEAL SELECTIONS HERE"); // Placeholder
                        validChoice = true; //Would like to return to the main menu or exit at this point option.
                        break;

                    case 3:
                        Console.WriteLine("Exiting program");
                        validChoice = true;
                        return;

                    default:
                        Console.WriteLine("Please enter a valid number.");
                        validChoice = false;
                        break;
                }
            }
            catch (Exception message)
            {
                validChoice = false;
                Console.WriteLine(message); //might not need to display the message to end user, but it's helpful for debuggin, will remove later.
                Console.WriteLine("\n Please enter a valid number.");
            }
        } while (!validChoice);
    }
}
*/


/*
using MealsProject.PresentationLayer;
using System.Reflection.Emit;
using MealsProject.ControllersLayer;
using MealsProject.Models;

namespace MealsProject;

class Program
{
    static readonly UserController userController = new UserController();
    static readonly HistoryController historyController = new HistoryController();
    static readonly MenuController menuController = new MenuController();
    static Session? session;
    static void Main(string[] args)
    {
        //MainMenu.startMenu();
        userMenu.returningUserMenu();
    }
}
*/