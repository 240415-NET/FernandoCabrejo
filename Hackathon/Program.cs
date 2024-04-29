
/* Cash Register, when I entered a lesser amount for tendered, gave me the amount needed and it closed.
namespace Week1Team2Hackathon;

class Program
{
    static void Main(string[] args)
    {
        /*
        Goals:
            1 - Prompts the user for some input
            2 - Does something with that input
            3 - Handles any exceptions that may arise during the running of the application (no hard crashing)
            4 - Continues to run until the user quits the application, from within the application (no ctrl+c)
        Program:
            New program created that emulates a cash register transaction
            Prompts for entry of item value or an exit
            Increments numberItems for each successful entry and keeps running subtotal for items
            Upon exit prompt, shows checkout total and prompts for payment
            If needed, provides change owed or additional amount owed by customer
        */
/*
        double checkoutTotal = 0;
        double itemValue = 0;
        int numberItems = 0;
        string userInput;
        bool quit = false;

        do
        {
            try
            {
                Console.WriteLine("Please enter value of the item, enter 'c' to checkout, or 'e' to end transaction");
                userInput = Console.ReadLine().ToLower();
                if ((userInput == "q" || userInput == "c") && numberItems > 0)
                {
                    endTransaction(checkoutTotal,numberItems);
                    quit = true;
                }
                else if ((userInput == "q" || userInput == "c") && numberItems == 0)
                {
                    Console.WriteLine("Transaction cancelled");
                    quit = true;
                }
                else if (userInput == "e")
                {
                    Console.WriteLine("Transaction cancelled");
                    quit = true;
                }
                else
                {
                    itemValue = Convert.ToDouble(userInput);
                    checkoutTotal = RunningTotal(itemValue,checkoutTotal);
                    numberItems = ItterateNumItems(numberItems);
                    if (numberItems > 1)
                    {
                        Console.WriteLine($"Subtotal is ${checkoutTotal}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} Please enter either a valid number or q to end transaction");
            }
        }
        while (quit == false);

    }

    static int ItterateNumItems(int numberItems)
    {
        int num1 = numberItems + 1;
        return num1;
    } 
   
    static double RunningTotal (double itemValue, double total)
    {
        total = total + itemValue;
        total = Math.Truncate(100*total)/100;
        return total;
    }

    static void endTransaction (double checkoutTotal, int numberItems)
    {
        Console.WriteLine($"${Math.Round(checkoutTotal,2)} is owed today for {numberItems} items");
        try
        {
            Console.WriteLine("Please enter amount tendered");
            string checkout = Console.ReadLine().ToLower();
            if (checkout == "e")
            {
                Console.WriteLine("Transaction cancelled");
            }
            else
            {
                double amountTendered = Convert.ToDouble(checkout);
                double balance = Math.Round(amountTendered - checkoutTotal,2);
                if (balance == 0)
                {
                    Console.WriteLine("Thank you, have a great day!");
                }
                else if (balance > 0)
                {
                    Console.WriteLine($"${balance} is owed in change");
                }
                else
                {
                    Console.WriteLine($"An additional ${-(balance)} is needed.");
                }
            }
        }
        catch (System.Exception e)
        {
            Console.WriteLine($"{e.Message} Please enter a valid payment amount");
        }
       
    }
}
*/

/* Extended FizzBuzz, working
using System.Net.Quic;

namespace hackathon1;
// Create a C# console app with the following requirements
// 1. Prompt the user for some input
// 2. Do something with the input
// 3. Handles exceptions
// 4. Continues to run until the user quits the app from within the app
//      (no CTRL + C to exit)

class Program
{
    static void Main(string[] args)
    {
        bool keepGoing= true;
      
        do
        {
        int maxValue = 0;

            Console.WriteLine("Provide a maximum value or Q to quit");
            string userInput = Console.ReadLine().ToUpper();
            if (userInput == "Q")
            {
                keepGoing = false;
            }
            else
            {
                try
                {
                    maxValue = Convert.ToInt32(userInput);
                }
                catch (Exception e)
                {
                    Console.WriteLine("BAD USER (invalid input)");
                }
            }

        for(int i=1; i<=maxValue; i++)
		{
			if (i%3 == 0 && i%5 == 0)
			{
				Console.WriteLine("fizzbuzz");
			}
		else if(i%3 == 0)
			{
			Console.WriteLine("fizz");
			}
		else if (i%5 == 0)
			{
			Console.WriteLine("buzz");
			}
		else 
	    	{
			Console.WriteLine(i);
		    }
		}
        }
        while (keepGoing == true);
	}
}
*/

/* Census, working but when typing any lower case letter after Would you like to answer this question again? doesn't do exception
﻿namespace RossWheatley;
/*
In this Hackathon we want to create a C# console application with the following requirments.

1 - Prompts the user for some input
2 - Does something with that input
3 - Handles any exceptions that may arise during the running of the application (no hard crashing)
4 - Continues to run until the user quits the application, from within the application (no ctrl+c)

We also want to make sure this code is visible to all of us! Have someone share their screen and 
type for the group, making sure that they are inside of their personal repo on this organization. 

We want to then push this code up before we leave today. I will compile links to their repo's and 
make a teams post with links to the different groups' work for future reference. 
*/

// Census program, works but when typing lower case y it quits
// Census Survey
// "how many people are in your house?"
/*
class Program
{
    static void Main(string[] args)
    {
        bool repeat;
        string userInput = "";

        int householdCount = 0;

        do
        {
            do
            {
                Console.WriteLine("How many people live in your house?");
                repeat = false;
                try
                {
                    householdCount = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                    Console.WriteLine("Make sure you enter an integer!");
                    repeat = true;
                }
                // Do something with user's input
                repeat = HandleHouseholdSize(householdCount);

            } while (repeat);

            Console.WriteLine("Would you like to answer this question again? (Y/N)");
            userInput = Console.ReadLine();
        } while (RepeatProgram(userInput));
    }

    private static bool RepeatProgram(string userInput)
    {
        if (userInput == "Y")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Handles user's household size, comments on the household size, and rejects unacceptable input
    private static bool HandleHouseholdSize(int i)
    {
        if (i < 1)
        {
            Console.WriteLine("Hmmmm... That doesn't seem right.");
            return true;
        }
        else if (i >= 1 && i < 5)
        {
            Console.WriteLine("Thank you.");
            return false;
        }
        else if (i >= 5 && i < 10)
        {
            Console.WriteLine("Oh, that's a pretty big family.");
            return false;
        }
        else if (i >= 10 && i <= 100)
        {
            Console.WriteLine("Wow...");
            return false;
        }
        else if (i > 100)
        {
            Console.WriteLine("You cannot enter a value greater than 100.");
            return true;
        }
        return false;
    }
}
*/
// Sarcasm program, working
﻿namespace FirstFridayGroupProject;

class Program
{
    static void Main()
    {
        bool exitProgram = false;
        int myAge = 0;
        string myAgeStr;
        do
        {
            //Console.Clear();
            Console.WriteLine("Please select what you would like to do");
            Console.WriteLine("1. First Option");
            Console.WriteLine("2. Exit Program");
            try
            {
                int menuSelection = Convert.ToInt32(Console.ReadLine());
                switch(menuSelection)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Congratulations on properly selecting a menu option!");
                        do
                        {
                            Console.WriteLine("How old are you?");
                             myAgeStr = Console.ReadLine();
                             if(Int32.TryParse(myAgeStr, out myAge))
                            {  
                                Console.WriteLine($"So noted.  You are {myAge} years old.");
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                                Console.Clear();
                            }else
                            {
                                Console.WriteLine($"{myAgeStr} wasn't a valid whole number. Try again");
                            }
                        }while(!Int32.TryParse(myAgeStr, out myAge));
                        break;
                    case 2:
                        exitProgram = true;
                        break;  
                    default:
                        Console.WriteLine("That wasn't an option. Try again.");
                        break;

                }
            }
            catch (Exception e)
            {
                bool didUserRespCorrectly = false;
                Console.WriteLine($"{e.Message}");
                Console.WriteLine("Please enter a valid whole number.");
                do
                {
                    Console.WriteLine("Do you want to try again? (y/n)");
                    string userResp = Console.ReadLine();
                    if(String.IsNullOrEmpty(userResp) || (userResp.ToUpper() != "Y" && userResp.ToUpper() != "N"))
                    {
                        Console.WriteLine("You have to give me either a y or n response");
                    }else if (userResp.ToUpper() == "N")
                    {
                        exitProgram = true;
                        didUserRespCorrectly = true;
                    }else
                    {
                        Console.Clear();
                        didUserRespCorrectly = true;
                    }

                }while(didUserRespCorrectly == false);
                
            }
        }while(exitProgram==false);
    }
}

