namespace MealsProject.PresentationLayer;
    public class userMenu
{
    public static void returningUserMenu()
    {

        bool validChoice = true;
        
        Console.WriteLine("Welcome back! Please select an option:");
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
                     //       Console.WriteLine("Enter your meal selection:");
                      //      entreeInput = Console.ReadLine();
                     //       if (!string.TryParse(entreeInput, out entree))
                     //       {
                        foreach (string item in entreeList)
                        {
                            Console.WriteLine(item);
                        }
                     
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

                        validChoice = true;
                        break;

                    case 2:
                        //List<string> entreeList = new List<string>();
                        //foreach (string item in entreeList)
                        //{
                        //    Console.WriteLine(item);
                        //}
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