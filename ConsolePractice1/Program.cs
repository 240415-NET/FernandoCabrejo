
/* program from Michael Horn, working
namespace thursdayProgram;
class Program
{
    static void Main(string[] args)
    {
      for (int i = 1; i < 101; i++)
      {
        switch(true)
        {  
       case true when (i % 3 == 0) && (i % 5 == 0):
           Console.WriteLine("fizzbuzz");
           break;
        case true when i % 3 == 0:
           Console.WriteLine("fizz");
           break;
        case true when i % 5 == 0:
           Console.WriteLine("buzz");
           break;
        default:
           Console.WriteLine(i);
           break;
        }
      }
    }
}
*/

/* program from Omar Flores, working
namespace thursdayProgram;
class Program
{
    static void Main(string[] args)
    {
      for (int i = 1; i < 101; i++)
      {
        switch((i%3==0,i%5==0))
        {  
       case (true,true):
           Console.WriteLine("fizzbuzz");
           break;
        case (true,false):
           Console.WriteLine("fizz");
           break;
        case (false,true):
           Console.WriteLine("buzz");
           break;
        default:
           Console.WriteLine(i);
           break;
        }
      }
    }
}
*/

/*program from the team, working
namespace thursdayProgram;
class Program
{
    static void Main(string[] args)
    {
        int i = 1;

       while (i <= 100)
       {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("fizzbuzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("fizz");
            }       
            else if (i % 5 == 0)
            {
                Console.WriteLine("buzz");
            }
            else
            {
                Console.WriteLine(i);
            }
            i++;
       }
    }
}
*/

//program from group x, working
public class Program
{
    public static void Main()
    {
       int fizzBuzzNum = 100;
       for (int i = 1; i <= fizzBuzzNum; i++)
     //if divisible by 5 & 3 returns Fizzbuzz
     {
        if (i % 3 == 0 && i % 5 == 0)
        {
            Console.WriteLine("FizzBuzz");
        }
      //if divisible by 5 returns (Fizzbuzz");
        else
        {
            if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
        //if divisible by 3 returns Fizz
        else
         {
           if (i % 3 == 0)
           {
              Console.WriteLine(":Fizz");
           }
           //Print Number
           else
               Console.WriteLine(i);
         }
        }
     }
    }
}

/*
Public Class Main
{
   Public Static Void Main ()
   {
    For (int i=1; i <= 100; i++)
    {
        if (i%3 == 0 && i%5 == 0)
        {
            Console.WriteLine("Div by 3 and 5");
        }
        else if (i%3 == 0)
        {
            Console.WriteLine("Div by 3");
        }
        else if (i%5 == 0)
        {
            Console.WriteLine("Div by 5");
        }
        else
        {
            Console.WriteLine(i);
        }
    }
   }
}
*/