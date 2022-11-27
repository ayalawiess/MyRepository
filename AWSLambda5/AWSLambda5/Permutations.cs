using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AWSLambda5
{
    public class Permutations
    {
        PermutationsAndCombinations test = new PermutationsAndCombinations();

        public string PermutationsMain(int mis,int m)
        {
           
            int[] arr1 = new int[mis];
            for (int i = 0; i < mis; i++)
            {
                arr1[i] = i + 1;
            }
            string[] listNew = new string[m];
            test.prnPermut(arr1, 0,mis - 1, ref listNew);
            // Console.Write(listNew[m - 1].ToString() + "\n\n");
            return listNew[m - 1].ToString();
        }
    }
}
