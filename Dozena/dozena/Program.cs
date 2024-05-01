using System.Data;
using System.Security.Cryptography;
using System.Transactions;

namespace dozena;

class Program
{
 static void Main(string[] args)
 {
     int[] scores = [97, 92, 81, 60];

     //Define the query expression.
     IEnumerable<int> scoreQuery = 
        from score in scores
        where score > 80
        select score;

     // execute the query.
     foreach (var i in scoreQuery)
     {
        Console.Write(i + " ");
    }
 }
}
//catch (Exception e)
//            {
//                Console.WriteLine($"{e.Message} Please enter either a valid number or q to end transaction");
//            }



/*
   try
    {
    Console.WriteLine("Enter a number: ");

    var num = int.Parse(Console.ReadLine());

    Console.WriteLine($"Square of {num} is {num * num}");
    }
    catch(Exception e) 
    {
        Console.WriteLine($"{e.Message} from here");
    }
    finally
    {
        Console.Write("Re-try with a different number.");
    }

-------------
 public static void Main()
	{
      int[] nums = { 1, 2, 3, 4, 5};
      
      UpdateArray(nums);

      foreach(var item in nums)
      Console.WriteLine(item);
    }

    public static void UpdateArray(int[] arr)
    {
        for(int i = 0; i < arr.Length; i++)

        arr[i] = arr[i] + 10;
    }
--------------

		int i = 0;
        do
        {
            Console.WriteLine("i={0}",i);
            i++;        
        }
        while (i < 20);
--------------
	{
		int i = 0;
        while (true)
        {
            Console.WriteLine("i={0}",i);
        
        if (i > 10)
        break;
        }
    }
}


---------
{
    static void Main(string[] args)
    {
        for(int i = 0; i< 10; i++)
       {
          Console.WriteLine("Value of i: {0}", i);
       }
    }
}
*/