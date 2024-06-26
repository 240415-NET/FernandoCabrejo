using System.Globalization;
using System.Net.Mail;
using System.Runtime.InteropServices.Marshalling;
using System.Linq;
using System.Xml;

namespace prace;

class Program
{
    static void Main(string[] args)
    {
        string[] theArray = new string[] {"Apples", "Bananas", "Cherries"};
        string concatenatedString = string.Join(",", theArray);

        Console.WriteLine($"[{string.Join(", ", theArray)}]");
    }
}
        
        

           /*
        int[] arrayB = new int[10];
        int[] arrayC = new int[10];
        int ctr = 0;
        int i, j, k;

        for (i = 0; i < arrayA.Length; i++)
        {
            ctr = 0;
            for (j = 0; j < i - 1; j++)
            {
                if (arrayA[i] == arrayA[j])
                {
                    ctr++;
                }
            }
        }
        //check for dups
        for (k = i + 1; k < arrayA.Length; k++)
        {
            if (arrayA[i] == arrayA[k])
            {
                ctr++;
            }

            if (arrayA[i] == arrayA[i + 1])
            {
                i++;
            }
        }

        if (ctr == 0)
        {
            Console.Write(arrayA[i]);
        }
    }
   // Console.Write("\n\n");
    }
  

















/* 
    private static int i;

    static void Main(string[] args)
    {
        int[] arrayA = { 6, 7, 8};

        for(int i = 0; i < arrayA.Length; i ++)
        {
         Console.WriteLine(arrayA[i]);
        }

    }
}
*/