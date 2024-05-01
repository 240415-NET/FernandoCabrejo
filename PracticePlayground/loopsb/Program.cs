namespace loopsb
{
public class Program
{
Public Static Void Main ()
   {
    For (int i=1; i <= 100; i++)
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
        }  
        else 
        {if (i%5 == 0)
           { 
            Console.WriteLine("Div by 5");
           }
        }   
        else
        {
            Console.WriteLine(i);
        }
    }
   }
}
}