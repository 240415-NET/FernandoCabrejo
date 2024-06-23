using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Channels;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string itemsInList = "";
            List<string> groceryList = new List<string>();
            string answer = "";
            bool moreItems = true;

            Console.WriteLine("Title-Grocery List");
            do
            {

                Console.WriteLine("Enter an item: ");
                itemsInList = Console.ReadLine();
                groceryList.Add(itemsInList);

                Console.WriteLine("Do you want to add another item? yes or no ");
                answer = Console.ReadLine();
                if (answer.ToLower().Trim() == "yes")
                {
                    moreItems = true;
                }
                else if (answer.ToLower().Trim() == "no")
                {
                    moreItems = false;
                }
                else
                {
                    moreItems = false;
                }
            } while (moreItems == true);
            foreach (string item in groceryList)
            {
                Console.WriteLine(item);
            }

        }
    }
}









/*  program I got from search
        static void Main(string[] args)
        {
         for (int i = 1; i <= 100; i++)
          {
            bool fizz = i % 3 == 0;
            bool buzz = i % 5 == 0;

            if (fizz && buzz)
               Console.WriteLine("FizzBuzz");
            else if (fizz)
                Console.WriteLine("Fizz");
            else if (buzz)
                Console.WriteLine("buzz");
            else
                Console.WriteLine(i);
          } 
        }
    }
}


//class Program
//{

//Steve and Tommy are playing a game where they take rocks out of a bag. The bag has a certain number of rocks, and each child can take a certain number of rocks out of the bag. Steve will always go first and then the two children take turns taking rocks out of the bag. It is your job to figure out which child will empty the bag (reduce the number of rocks in the bag to 0), and how many rocks that same child has taken total.

//The rockGame() method takes in 3 arguments in this order:
//b - the total number of rocks in the bag, this will be between 0-1000
//s - the number of rocks Steve will take out every turn, this will be between 0-1000
//t - the number of rocks Tommy will take out every turn, this will be between 0-1000
//After figuring out who empties the bag, you are required to return the total number of rocks that the child who went has total.


/*
//public class Test
//{
//    public static void Main()
 //   {
//        int b=9;
//        int s=2;
 //       int t=3;
 //   }
//}


public class rockGame
{
    int b = 9;
    int s = 2;
    int t = 3;
    int remainingInBag = b;
    int totalSteve = 0;
    int totalTommy = 0;
    int finalForEach = 0;

    while (b > 0)
    {
        remainingInBag = b - s;
        if (remainingInBag > 0)
        {
            totalSteve += s;
            b -= s;
        }
        else
        {
            totalSteve = totalSteve + s + remainingInBag;
            finalForEach = totalSteve;
            break;
        }
        remainingInBag = b - t;
        if (remainingInBag > 0)
        {
            totalTommy += t;
            b -= t;
        }
        else
        {
            totalTommy = totalTommy + t + remainingInBag;
            finalForEach = totalTommy;
            break;
        }
    }
    return finalForEach;
}



//Program I got from search

static void Main(string[] args)
{

    int b = 9;
    int s = 2;
    int t = 3;

    int totalRocks = 9;
    int steveRocks = 0;
    int tommyRocks = 0;


    b -= s;
    b -= t;
    b -= s;
    b -= t;

    // Console.WriteLine($"Tommy reduces the bag to 0, taking {t + 2} rocks.");
    Console.WriteLine(t + 2);
}
}
}

/*
while (totalRocks > 0)
{
    //Steve takes 2 rocks
    totalRocks -= 2;
    steveRocks += 2;

    //Tommy takes 3 rocks
    totalRocks -= 3;
    tommyRocks += 3;
}

if (steveRocks > tommyRocks)
    Console.WriteLine("Steve wins! Total rocks taken by Steve: " + steveRocks);
else if (tommyRocks > steveRocks)
    Console.WriteLine("Tommy wins! Total rocks taken by Tommy: " + tommyRocks);
else
    Console.WriteLine("It's a tie! Both Steve and Tommy took the same number of rocks."); 







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
}
/*
//Given an int array, and it is your job to figure out the minimum value in the int array (there may be duplicates).
//The findMin()method takes in 1 argument:
//* intArray - the int array that will contain ints fro you to check.
// You will need to check all of the values in the array, and return the minimum value in findMin();
static void Main(string[] args)
{

//public static int findMin(int[] intArray)
    //WRITE YOUR CODE HERE
int[] intArray = new int[] {6, 3, 10, 1, 38, 53, 63};

int findMin = intArray[0];

for (int i=0; i < intArray.Length; i++)
{
    if (intArray[i] < findMin)
    {
        findMin = intArray[i];

    }
}
Console.WriteLine($"min is {findMin}");
}
}

// This is an example of a program testing an array inversion
class Program
{
static int[] InvertValues(int[] numbers)
{
int[] inverted = new int[numbers.Length];
for(int i = 0; i < numbers.Length; i++)
{
inverted[i] = -numbers[i];
}
return inverted;

}

static void Main()
{
int[] originalNumbers = {1, 2, 3, 4, 5 };
int[] invertedNumbers = InvertValues(originalNumbers);

Console.WriteLine("Original numbers: " + string.Join(", ", originalNumbers));
Console.WriteLine("Inverted numbers: " + string.Join(", ", invertedNumbers));
}
}
*/