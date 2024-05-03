using System.Runtime.CompilerServices;
using System.Transactions;

namespace gpractice;

class Program
{
    static void Main(string[] args)
    {
        String answer = "";
        List<string> groceryList = new List<string>();

        Console.WriteLine("Grocery List");


        Console.WriteLine("Enter an item: ");
        
        answer = Console.ReadLine();


}
//write the title and write the question "Enter an item:", leave a few blank lines
//define a way to capture the entry, then add string variable set to "" to hold the answer and 
//assign the new variable to the entry capture
//define 1 List to keep the entered values
//use the variable declared to read the entry
//Add the entry to the list declared to hold the items entered
//figure out a d
//the "while" goes after } 
//add a new variable of type bool and set it to true to use it in the loop 
//after the "while" evaluate the bool var to be true
//after adding the item to the list, ask if want to enter another item yes or no
//declare a new variable to hold the answer, set to ""
//add the new var answer to read the entry
//set up an if-else after the answer to check the contents
//evaluate answer if yes and use ToLower() and Trim()
//then evaluate the boolean, assign true and put it in between { }
//now else if and evaluate to no and use ToLower() and Trim()
//then set the boolean to false and put in in between { }
//write the final "else" to evaluate the boolean in between { }
//then set the boolean to false for anyting that is not yes or no
//now to display the entries, after the "while" write foreach use the suggestion
//change var to string and collecion for list already declared
//Write the item and put it in between { }