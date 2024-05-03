using System.Globalization;

namespace atarray;

class Program
{
    static void Main(string[] args)
    {
    int[] numbs = new int[] {6, 3, 10, 23, 38, 63, 2}; 
    
    for (int i=0; i < numbs.Length; i++)
    {
      
    }

    Console.WriteLine("output");
    }
}



















/*
--------------------
    int k = numbs.Length; //K identifies the number of the internal items in the array
    int min = numbs[0]; //this is an index starting at the zero space for evaluation
    int max = numbs[0];

{
        if (numbs[i] < min)
        {
          min = numbs[i];
        }
    }
   // return min;


--------------

What I did in the test:
Using System;
public class Test{
    public static int findMin(int[] intArray){
        //write your code here
        int findMin = intArray[0]; //get the first space

        for (int i=1; i < intArray.Length; i++)
        {
            if (intArray[i] < findMin)
           {
           findMin = intArray[i];
           }
        }

        Console.WriteLine($"Min value: findMin[i]);
  }
  //DO NOT TOUCH THE CODE BELOW 
  public static void Main(){
    string[] inputArray = Console.ReadLine().Replace("[","").Replace("]","").Split(",");
    int[] intArray = new int[inputArray.Length];
    for(int i=0;i<intArray.Length;i++){
    intArray[i]=Int32.Parse(inputArray[i]);
    }
    Console.WriteLine(findMin(intArray));
    }      
  

  ------------------------------------
  My issue was the output line, I didn't know how to show the results, from Dave see is using Return and so far I think is 
  using the output from the code not to touch. */