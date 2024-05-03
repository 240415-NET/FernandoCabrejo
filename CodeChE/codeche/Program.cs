namespace codeche;

class Program
{

    

    static void Main(string[] args)
    {
        
        int count = int.Parse(Console.ReadLine());
        string[] inputs = Console.ReadLine().Split(' ');
        
        for (int i = 0; i < count; i++)
                
        Console.WriteLine("Output");
    }
}


/*A series of numbers where the odd numbers will be multiplied and the evens will be added, give the total.
1. If run it as-is you get the output as text, the text is going to be replaced with our output
2. Remember, the if-else we have to insert after the int number declaration, use { } after if, before else
3. Need to think the loop first, like if the number is even then add the “number” defined in the int inside the loop
4. Then do the “else” where if the number is not even, will go there and multiply it
5. Then need to worry about changing the WriteLine to write the contents of output with our var we defined?

var numbers = new List<int> {1, 2, 6, 3, 6, 9};  -->idea of input
int[] numbs = new int[] {6, 3, 10, 23, 38, 63, 2}; -->idea of input

1 * 3 * 9 = 27
2 + 6 + 6 = 14

1 + 2 + 6 * 3



static void Main(string[] args)
    {
      
      Console.WriteLine("Enter the number separated by comma");
      string[] arr = Console.ReadLine().Split(",");

      int sum = 0;
      int product = 1;
      for (int i=0; i<arr.Length; i++)
      {
        int num = int.Parse(arr[i]); 
        if(num % 2 ==0) //even
        {
          Console.WriteLine($"number at {i}==>{arr[i]} is even, so summing");
          sum+=num;

        }
        else //odd
        {
          Console.WriteLine($"number at {i}==>{arr[i]} is odd, so multiplying");
          product*=num;
        }
      }

       Console.WriteLine($"Answer is sum={sum} & product={product}. The total is {sum + product} ");
    } 



*/
