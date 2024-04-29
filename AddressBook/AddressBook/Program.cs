using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace AddressBook
{
   class Program
   {
      // List to store 
      static List<Person> People = new List<Person>();

      public static void Main(string[] args)
       {
         Console.WriteLine("Here is the Address Book");

         while (true)
         {
           Console.WriteLine("\nChoose an option:");
           Console.WriteLine("1. Add a person");
           Console.WriteLine("2. List people");
           Console.WriteLine("3. Exit");

           int choice;
           if (int.TryParse(Console.ReadLine(), out choice))
           {
             switch (choice)
             {
                 case 1:
                       AddPerson();
                       break;
                 case 2:
                       ListPeople();
                       break;
                 case 3:
                       Console.WriteLine("Exiting the application. Goodbye!");
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

   //Defining a class named Person
     public class Person
     {
         public string FirstName { get; set;}
         public string LastName { get; set;}
         public string PhoneNumber {get; set;}
         public string[] Addresses {get; set;}  //A string to hold more than 1 address
     }
  //Create a list that is public and static to instantiate person objects
  //   public static List<Person> People = new List<Person>();

     //Method to add people
       static void AddPerson()
       {
         Person person = new Person();
         Console.Write("Enter First Name: ");
         person.FirstName = Console.ReadLine();
         Console.Write("Enter Last Name: ");
         person.LastName = Console.ReadLine();
         Console.Write("Enter Phone Number: ");
         person.PhoneNumber = Console.ReadLine();
         Console.Write("Enter Address 1: ");
         person.Addresses = new string[2];
         person.Addresses[0] = Console.ReadLine();
         Console.Write("Enter Address 2: ");
         person.Addresses[1] = Console.ReadLine();

         People.Add(person);
         Console.WriteLine("Person added successfully!");
    }

//Method to list People:
    private static void ListPeople()
    {
         Console.WriteLine("\nList of People in the Address Book;");
         foreach (var person in People)
           {
             Console.WriteLine($"Name: {person.FirstName} {person.LastName}");
             Console.WriteLine($"Phone Number: {person.PhoneNumber}");
             Console.WriteLine($"Address 1: {person.Addresses[0]}");
             Console.WriteLine($"Address 2: {person.Addresses[1]}");
             Console.WriteLine();
            }
    }
}
}