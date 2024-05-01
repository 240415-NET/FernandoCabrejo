using System.Data;
using System.Numerics;

namespace testone;

class Program
{
public class Test
  {
        public static int rockGame(int b, int s, int t) 
        {
        int firstrun = 0;
        int secondrun = 0;

        if (b <= 1000)
        {
            firstrun = (b - s);
        }
        else if (b > 0)
        {
            secondrun = ((firstrun - s)-t);
        }
        else{
            Console.WriteLine(secondrun);
        }   
   
        }
    }

public static void Main()
{
      int b = int.Parse(Console.ReadLine());
      int s = int.Parse(Console.ReadLine());
      int t = int.Parse(Console.ReadLine());
      Console.WriteLine(rockGame(b,s,t));

}



}
