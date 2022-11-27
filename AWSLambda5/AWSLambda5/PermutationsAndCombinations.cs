using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSLambda5
{
    public class PermutationsAndCombinations
    {
        public void swapTwoNumber(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        //string[] listNew = { };
        int index = 0;
        public void prnPermut(int[] list, int k, int m, ref string[] listNew)
        {
            int i;
            string temp = "";
            if (k == m && index < listNew.Length)
            {
                for (i = 0; i <= m; i++)
                {
                    // Console.Write("{0}", list[i]);
                    temp += list[i];
                }
                listNew[index] = temp;
                index++;
                // Console.Write(" ");
            }
            else if (index < listNew.Length)
            {
                for (i = k; i <= m; i++)
                {
                    swapTwoNumber(ref list[k], ref list[i]);
                    prnPermut(list, k + 1, m, ref listNew);
                    swapTwoNumber(ref list[k], ref list[i]);
                }
            }
            else
            {
                return;
            }
        }
    }
}
