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
        Console.WriteLine("****************************************");
        Console.WriteLine("* Welcome to the Meals Ordering System *");
        Console.WriteLine("****************************************");

        do
        {
            DisplayOptions(1);
            var option = TakeInputWithMessage("what would you like to do next? Enter Option:");

            switch (option)
            {
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
                case "4":
                    DisplayMenu();
                    break;
                case "5":
                    TakeOrder();
                    break;
                case "6":
                    Console.WriteLine("Thanks for using the Meal Ordering System");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        } while (true);
    }

    // If a user has already logged in, do you need to ask them for their username again?
    private static void TakeOrder()
    {
        var loadUsername = TakeInputWithMessage("Load Username:");
        var loadUserResponse = userController.GetUserByName(loadUsername);
        Console.WriteLine(loadUserResponse.Message);
        if (loadUserResponse.Success)
        {
            var loadedUser = (User)loadUserResponse.ObjectResponse;
            session = new Session(loadedUser);
            Console.WriteLine($"{loadUsername} is successfully loaded in the session");

            var goBack = false;
            do{
                DisplayOptions(2);
                var option = TakeInputWithMessage("What would you like to do next? Enter Option:");
                switch (option)
                {
                    case "1":
                        DisplayMenu();
                        break;
                    case "2":
                        ChooseItems();
                        break;
                    case "3":
                        DisplayHistoryForSessionUser();
                        break;
                    case "4":
                        goBack=true;
                        ClearSession();
                        break;
                    case "5":
                        Console.WriteLine("Thanks for using the system!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (!goBack || session != null);
        }
        else
        {
            Console.WriteLine($"{loadUsername} could not be loaded in the session");
        }
    }

    private static void ChooseItems()
    {
        DisplayMenu();
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
            Console.WriteLine($"Order Placed Successfully");
            WriteHistoryFromSession();
        }
    }

    private static void DisplayMenu()
    {
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("*********************************");
        Console.WriteLine("          * M E N U *            ");
        Console.WriteLine("*********************************");
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

    private static void DisplayHistoryForSessionUser()
    {
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("*********************************");
        Console.WriteLine("          * History *            ");
        Console.WriteLine("*********************************");
        var historyResponse = historyController.GetAllHistoryForUser(session.User.Id);

        var histories = (List<History>)historyResponse.ObjectResponse;
        if (!histories.Any())
        {
            Console.WriteLine($"No history found for user {session.User.UserName}");            
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
        if(ClearSession == null)
        {
            Console.WriteLine("No user is loaded");
            return;
        }

        DateTime dateTime = DateTime.Now;

        var history = new History
        {
            Date = dateTime.ToString(),
            ItemNumbers = session.OrderList.Select(x=>x.Id).ToList(),
            UserId = session.User.Id
        };
        historyController.AddHistory(history);
    }

    // This is a private static method that takes in a message and returns the input of the user after displaying the message given
    private static string TakeInputWithMessage(string Message)
    {
        Console.WriteLine(Message,false);
        var input = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Input cannot be empty, Re-enter please:",false);
            input = Console.ReadLine();
        }
        return input;
    }

    private static void Outpu(string message, bool tab=true)
    {
        var tabstr = tab ? "\t" : string.Empty;
        Console.WriteLine($"{tabstr}{message}");
    }

    private static void DisplayOptions(int level)
    {
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("*********************************");
        Console.WriteLine("  Available Operation Options:   ");
        Console.WriteLine("*********************************");
        switch (level)
        {
            case 1:
                Console.WriteLine("1.Check User    2.Add User    3.Delete User    4.Load Menu    5.Start    6.Exit \r\n");
                break;
            case 2:
                Console.WriteLine("1.Load Menu    2.Choose Items    3.Display History    4.Go Back    5.Exit \r\n");
                break;
            default:
                Console.WriteLine("Invalid Entry");
                break;
        }

        Console.WriteLine("*********************************");
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