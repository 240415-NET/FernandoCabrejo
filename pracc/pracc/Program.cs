using System;
namespace pracc;




/*
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
        {
            if (i > 1 && arr[i].Length >= 3)   //i is 2 or 3 or 4 and the element is 2 or 4 (but is only 2 which is the 3rd space )
            {
                Console.Write(arr[i] + ",");
            }
        }

    }

}







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