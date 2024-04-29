using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace HoodChores
{
   class Program
   {
      // Using List to store 
      static List<Neighbor> Neighbors = new List<Neighbor>();

      public static void Main(string[] args)
       {
         Console.WriteLine("Welcome to the Neighborhood");

         while (true)
         {
           Console.WriteLine("\nChoose an option:");
           Console.WriteLine("1. Add a person");
           Console.WriteLine("2. List people");
           Console.WriteLine("3. Exit");

         //going on a limb here trying to use a new method for conversion
           int choice;
           if (int.TryParse(Console.ReadLine(), out choice))
           {
             switch (choice)
             {
                 case 1:
                       AddNeighbor();
                       break;
                 case 2:
                       ListNeighbors();
                       break;
                 case 3:
                       Console.WriteLine("Exiting the neighborhood. Goodbye!");
                       return;
                 default:
                       Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                       break;
             }
           }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }

   //Defining a class named Neighbor
     public class Neighbor
     {
         public string FirstName {get; set;}
         public string LastName {get; set;}
         public string PhoneNumber {get; set;}
         public string[] Chores {get; set;}  //A string to hold more than 1 chore
     }

     //Method to add neighbors
       static void AddNeighbor()
       {
         Neighbor neighbor = new Neighbor();
         Console.Write("Enter First Name: ");
         neighbor.FirstName = Console.ReadLine();
         Console.Write("Enter Last Name: ");
         neighbor.LastName = Console.ReadLine();
         Console.Write("Enter Phone Number: ");
         neighbor.PhoneNumber = Console.ReadLine();
         Console.Write("Enter Chore 1: ");
         neighbor.Chores = new string[2];
         neighbor.Chores[0] = Console.ReadLine();
         Console.Write("Enter Chore 2: ");
         neighbor.Chores[1] = Console.ReadLine();

         Neighbors.Add(neighbor);
         Console.WriteLine("Neighbor added successfully!");
         
    }

//Method to list Neighbors
    private static void ListNeighbors()
    {
         Console.WriteLine("\nList of Neighbors participating;");
         foreach (var neighbor in Neighbors)
           {
             Console.WriteLine($"Name: {neighbor.FirstName} {neighbor.LastName}");
             Console.WriteLine($"Phone Number: {neighbor.PhoneNumber}");
             Console.WriteLine($"Chore 1: {neighbor.Chores[0]}");
             Console.WriteLine($"Chore 2: {neighbor.Chores[1]}");
             Console.WriteLine();
            }
    }
}
}