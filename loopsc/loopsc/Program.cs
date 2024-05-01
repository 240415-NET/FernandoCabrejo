namespace loopsc;

/*
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
*/

public class Program
{
public static void Main ()
   {
    for (int i=1; i <= 100; i++)
    {
        if (i%3 == 0 && i%5 == 0)
        {
            Console.WriteLine("Div by 3 and 5");
        }
        else 
        {if (i%3 == 0)
           {
             Console.WriteLine("Div by 3");
           }
         else 
         {if (i%5 == 0)
           { 
            Console.WriteLine("Div by 5");
           }  
        else
        Console.WriteLine(i);
         }
    }
   }
   }
}
//}

/*
   static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
*/