using System;
using System.Data;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using Microsoft.VisualBasic;

 public class Test
{
 public static void Main(){

        int b = 9;

        int s = 2;

        int t = 3;

        Console.WriteLine(rockGame(b,s,t));
 }
    public static int rockGame(int b, int s, int t)
 {
 //Write your code here
  int remaining = b;
  int totalt = 0;
  int totals = 0;
  int final = 0;

 while  (b>0)  //while there are rocks in the bag
  {
     remaining = b - s; //first time Steve takes 2 rocks, value of remaining = 7, second remaining is 2

     if (remaining > 0)
     {
         totals += s;  //first time put 2 in total for Steve, second put 2 

         b -= s;  //first reduce the number of rocks in the bag to 7, second is reduced to 2
     }
     else         //only when remaining is <=0
     {
         totals = totals + s + remaining;  //first total for Steve = 2 + 2 + 7 ?, second is 4
         
         final = totals;  //first final = 2 ?, second is 4

         break;  //come out
     }

     remaining = b - t;  // Tommy takes 3 rocks, remaining is 4 = 7-3, second Tommy can only take 2

     if (remaining > 0) 
     {
         totalt += t;  // First total for Tommy is 3, second is 5

         b -= t;  // first rocks in the bag is 4, second is 0
     }

     else

    {
        totalt = totalt + t + remaining;  //first total Tommy = 3, second is 3 + 3 -1

        final = totalt; //first Final for Tommy is 3, second is 5

        break;
    }
  }
     return final;

 }
}

/*
Steve and Tommy are playing a game where they take rocks out of a bag. The bag has a certain number of rocks, and each child can take a certain number of rocks out of the bag. Steve will always go first and then the two children take turns taking rocks out of the bag. It is your job to figure out which child will empty the bag (reduce the number of rocks in the bag to 0), and how many rocks that same child has taken total.

The rockGame() method takes in 3 arguments in this order:
b - the total number of rocks in the bag, this will be between 0-1000
s - the number of rocks Steve will take out every turn, this will be between 0-1000
t - the number of rocks Tommy will take out every turn, this will be between 0-1000
After figuring out who empties the bag, you are required to return the total number of rocks that the child who went has total.
 
 
Example Input:	Example Output:
9
2
3	             5
Explanation:
First turn Steve takes out 2 rocks and Tommy takes out 3 rocks, leaving 4 left in the bag.
Second turn Steve takes out 2 rocks and Tommy goes to take out 3 rocks, but since there are only 2 left he only takes 2, emptying the bag.
Since Tommy emptied the bag to 0 rocks, the resulting number of rocks he has total is 5.

This is what I did:
using System;
public class Test{

    public static int rockGame(int b, int s, int t){

        //WRITE YOUR CODE HERE

      int firstrun = 0;

      int secondrun = 0;

      if (b <= 1000)

       { 

          firstrun = (b - s);

       }

       else if (b > 0)

       {

          secondrun = ((firstrun - s) - t);

       }

       else  

        {

        Console.WriteLine(secondrun);

        }

    }


    //DO NOT TOUCH THE CODE BELOW

    public static void Main(){

        int b = int.Parse(Console.ReadLine());

        int s = int.Parse(Console.ReadLine());

        int t = int.Parse(Console.ReadLine());

        Console.WriteLine(rockGame(b,s,t));

    }

}

//Errors I got: not all code paths return a value and the name 'rockGame' does not exist in the current context
*/