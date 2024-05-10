namespace MealsProject.PresentationLayer;

    public class MainMenu

    {
        public static void startmenu()
        {
            int mainMenuChoice = 0;
            bool validChoice = true;

            Console.Clear();
            Console.WriteLine("Welcome to the Meal Selection Tracker!");
            Console.WriteLine("Please select an option by entering number:");
            Console.WriteLine("1 New Client?");
            Console.WriteLine("2 Returning client?");
            Console.WriteLine("3 Exit");

            do
            {
                try
                {
                    mainMenuChoice = Convert.ToInt32(Console.ReadLine());

                    switch (mainMenuChoice)
                    {
                        case 1:
                            Console.WriteLine("New Client selected");
                            validChoice = true;

                            break;
                        case 2:
                            Console.WriteLine("Welcome back Client!");
                            validChoice = true;

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
                catch (Exception ex)
                {
                    validChoice = false;
                    Console.WriteLine(ex);
                    Console.WriteLine("\n Please enter a valid number.");
                }
            } while (!validChoice);
        }
    }
