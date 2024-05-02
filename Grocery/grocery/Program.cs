namespace grocery;

class Program
{
    static void Main(string[] args)
    {                                               //first bracket in the Main method starts the program
        string itemsInList = "";                    //declaring and initializing variables itemsInList, enterAdditionalItem, answer
        bool enterAdditionalItem = true;
        string answer = "";
        List<string> groceryList = new List<string>(); //using List instead of array

        Console.WriteLine("Grocery List Menu");        //display first line
        do                                             //start a do-while loop because can enter many items keep asking 
        {

            Console.WriteLine("Enter an item: ");      
            itemsInList = Console.ReadLine();

            groceryList.Add(itemsInList);

            Console.WriteLine("Do you want another item yes or no:");

            answer = Console.ReadLine();

            if (answer.ToLower().Trim() == "yes")     //using an if else loop to handle the yes and no or something else entered
            {
                enterAdditionalItem = true;
            }
            else if (answer.ToLower().Trim() == "no")
            {
                enterAdditionalItem = false;
            }
            else 
            {
                enterAdditionalItem = false;
            }

        } while (enterAdditionalItem == true);

        foreach (string item in groceryList)          //using foreach to loop through the grocery list we created and write every item captured
        {
            Console.WriteLine(item);
        }
    }
}
