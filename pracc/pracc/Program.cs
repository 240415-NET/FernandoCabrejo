using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Channels;

namespace pracc;
public static class SecretCodeConverter
{
    public static string CreateSecretCode(string s)
    {
        //string s = "AbCdyx";

        StringBuilder secretCode = new StringBuilder();

        foreach (char c in s.ToUpper())
        {
            if (char.IsLetter(c))
            {
                int code = c - 'A' + 1;
                secretCode.Append(code.ToString("D2"));
            }
            else
            {
                secretCode.Append(c);
            }
        }
        return secretCode.ToString();
    }

    public static void Main()
    {
        string input = "AbCygHg";
        string secretCode = CreateSecretCode(input);
        Console.WriteLine($"Secret Code for '{input}' is: {secretCode}");
    }
}

/*
solution from Copilot
public class SecretCodeConverter
{
    public static string CreateSecretCode(string s)
    {
        //string s = "AbCdyx";

        StringBuilder secretCode = new StringBuilder();

        foreach (char c in s.ToUpper())
        {
            if (char.IsLetter(c))
            {
                int code = c - 'A' + 1;
                secretCode.Append(code.ToString("D2"));
            }
            else
            {
                secretCode.Append(c);
            }
        }
        return secretCode.ToString();
    }

    public static void Main()
    {
        string input = "AbCygHg";
        string secretCode = CreateSecretCode(input);
        Console.WriteLine($"Secret Code for '{input}' is: {secretCode}");
    }
}



/*
//exam question
class Program
{
    static void Main(string[] args)
    {
        List<int> myList = new List<int>() { 2, 3, 4 };

        int calculate = 1;

        for (int i = 0; i < myList.Count; i++) {
            if (myList[i] % 2 != 0) {
                myList[i] = 0;
            }
            calculate = calculate * myList[i];
        }
        Console.WriteLine(calculate);
    }
}




/*
//question from exam
class Program
{
    static int PlusMethod(int x, int y)
    {
        return x + y;
    }

    static double PlusMethod(double x, double y)
    {
        return x + y;
    }
    static void Main(string[] args)
    {
        int myNum1 = PlusMethod(9, 13);
        double myNum2 = PlusMethod(6.2, 4.34);
        Console.WriteLine("Int: " + myNum1);
        Console.WriteLine("Double: " + myNum2);
    }

}


//question from exam
class Program
{
    static void Main(string[] args)
    {
        try
        {
            int[] myNumbers = { 1, 2, 3 };
            Console.WriteLine(myNumbers[3]);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}



//question from exam
class Program
{
    static void Main(string[] args)
    {
        int a = 20;
        int b = 0;
        int c = a / b;
        Console.WriteLine("A = " + a);
        Console.WriteLine("B = " + b);
        Console.WriteLine("C = " + c);

    }

}



//question from exam
class Program
{
    static void Main(string[] args)
    {
        string[] animals = { "dog", "tiger", "dolphin", "alligator", "pollllar bear" };

        for (int i = 0; i < animals.Length; i++)
        {
            for (int j = 0; j < animals[i].Length; j++)
            {
                if (animals[i][j] == 'l')
                {
                    Console.Write(animals[i] + " ");
                }
            }
        }



    }

}




//question from exam
class Program
{
    static void Main(string[] args)
    {
        string[] arr = { "foo", "bar", "foobar", "ba" };
        for (int i = 0; i < arr.Length; i++) //array is up to 3 elements. length is 4
        //Console.WriteLine($"The length of the array is {arr.Length}");
        {
            if (i > 1 && arr[i].Length >= 3)   //i is 2 or 3 or 4 and the element is 2 or 4 (but is only 2 which is the 3rd space )
            {
                Console.Write(arr[i] + ",");
            }
        }

    }

}




/*
//question from exam
class Program
{
    static void Main(string[] args){
        string[] strings = {"apple", "banana", "plum", "strawberry"};
        Console.WriteLine(FindOccurrences(strings));
    }

    static int FindOccurrences(string[] sArray){
        int counter = 0;
        foreach(string str in sArray){
            foreach(char ch in str){
                if (ch == 'a'){
                    counter++;
                }
            }
        }
        return counter;
    }
}





// question from exam
public class ExceptionExample
{
    static void Main(string[] args)

    //public void mayThrowException()
    {
      try {
          riskyCode();  //A
          Console.Write("After A, ");
           }
    catch(Exception e) {
        Console.Write("Uh oh - something went wrong! ");
    } finally {
        Console.Write("Finally block, ");
    }
    Console.Write("continuing...");
    }

    private static void riskyCode()
    {
        throw new NotImplementedException();
    }
}
*/