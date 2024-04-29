using System.ComponentModel;
using System.Text.Json.Serialization.Metadata;

namespace IntroClass;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter an integer: ");
        String input = Console.ReadLine();
        

        Dog pancake = new Dog();

       //Here we call an instance method - this method needs an object of type dog to be called.
       pancake.Bark();

       Dog.DefineDog();
    }

    
}
