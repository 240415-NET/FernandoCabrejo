using System.ComponentModel;
using System.Reflection.Emit;
using MealsProject.ControllersLayer;
using MealsProject.Models;

class Program
{
    static readonly UserController userController = new UserController();
    static readonly HistoryController historyController = new HistoryController();
    static readonly MenuController menuController = new MenuController();
    static Session? session;
    static void Main(string[] args)                                                         //Main class to start the program

    {
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("~   Welcome to the Meals App Project   ~");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        do
        {
            var userIn = TakeInputWithMessage("Enter your user name:");                      //Using method to get a string name
            var userPw = TakeInputWithMessage("Enter your password:");                       //Using same method to get a string for password
            var userResponse = UserController.ValidateUserByNameAndPassword(userIn, userPw); //Casting response to user controller to validate
            var user = (User)userResponse.ObjectResponse;

            if (userResponse.Success && user != null)
            {
                do
                {

                    DisplayOptions(1);                                                           //To see the options to select, at the bottom of this prog
                    var option = TakeInputWithMessage("what would you like to do next? Enter Option:"); //method to get input

                    switch (option)                                   //switch evaluates the number entered in option to the case number
                    {
                        case "1":
                            DisplayMenu();                      //displays the menu 1.View Menu 2.Place Order 3. View History 4.Log out
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
                            Console.WriteLine("Invalid Option... Try Again");   //test for invalid option to try again
                            break;
                    }
                }
                while (true);
            }
            else
               {
                    Console.WriteLine(userResponse.Message);
               }
            }
            while (true);
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
                        ChooseItems(user);                                       //Method to select and place an order
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
                var menuItemNumber = TakeInputWithMessage("Enter Menu Item Number:");  //have to interact with SQL MealsMenu to retrieve the list of items
                var item = (Menu)menuController.GetMenuItem(int.Parse(menuItemNumber)).ObjectResponse;
                session.OrderList.Add(item);                                           //insert a row in MealsHistory with id,date, userid, itemid
                Console.WriteLine($"{item.ItemName} added to order.\r\n");
            }
            while (TakeInputWithMessage("Add More? (Y/N)").ToUpper() == "Y");
            Console.WriteLine($"Total Amount: ${session.OrderList.Sum(o => o.Price)}");  //display joint of MealsHistory using itemid to display the item name and price
            if (TakeInputWithMessage("Place Order? (Y/N)").ToUpper() == "Y")
            {
                Console.WriteLine($"Order Placed Successfully");                    //***Need to display options again, instead of asking for user name, removed Good Bye
                WriteHistoryFromSession();                                          //***or log them out once order is placed, but is better to display options
                //Environment.Exit(0);                              //=> added the following on 5/20 to log them out: Environment.Exit(0); should replace with DisplayOptions(1)**
                                                                  //=> to see the menu again instead of logging them off
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
                Console.WriteLine($"{item.Id}=> {item.ItemName} (${item.Price})");  //change to come from SQL instead of json
            }                                                                      //** needs to display the available operation options DisplayMenu()  *****
        }                                                                          //instead of asking for the user name and password again ***
                                                                                   //if user is already in, go back to display options ********
        private static void ClearSession()
        {
            Console.WriteLine("Clearing Session!");
            session = null;
        }

        private static void DisplayHistoryForSessionUser(User user)   //using parameter user
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("    ~~~ H i S T O R Y  ~~~       ");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            //var historyResponse = historyController.GetAllHistoryForUser(user.Id);

            var histories = HistoryController.GetAllHistoryForUser(user.Id);
            if (!histories.Any())
            {
                Console.WriteLine($"No history found for user {user.UserName}");
            }
            int i = 0;
            
            Console.WriteLine("Date\t Item \t Price");
            foreach (History h in histories)
            {
               Console.WriteLine($"{histories[i].Date}\t{histories[i].ItemName}\t{histories[i].Price}");
                i++;
            }

                //foreach (var history in histories)
                //{
                //    Console.WriteLine($"***{history.Date}***");
                //    Console.WriteLine("--------------------------");
                //    foreach (var itemNumber in history.ItemNumbers)
                //    {
                //        var menuItem = (Menu)menuController.GetMenuItem(itemNumber).ObjectResponse;
                //        Console.WriteLine($"=>{menuItem.ItemName} ({menuItem.Price})");
                

                Console.WriteLine("--------------------------\r\n");
            
            Console.WriteLine("-------History Complete--------");    //***needs to bo back to displayOption(1) instead of asking for user name again********
                                                                     
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

        private static void Output(string message, bool tab = true)
        {
            var tabstr = tab ? "\t" : string.Empty;
            Console.WriteLine($"{tabstr}{message}");
        }

        private static void DisplayOptions(int level)                      //See the options from start of program, void not returning a value
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("  Available Operation Options:   ");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            switch (level)
            {
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
