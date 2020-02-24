using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 100;
            bool[] notPrime;
            notPrime = new bool[n+1];         //notPrime[i]为true时，i不是素数
            for (int i=2;i*i<n;i++)
            {
                if(notPrime[i])
                {
                    continue;                 //若i不是素数，则不用i筛
                }
                for(int j=2*i;j<n;j+=i)
                {                   
                    notPrime[j] = true;      //j是i的倍数，则不是素数                   
                }
            }
            for(int i=2;i<n;i++)
            {
                if(!notPrime[i])
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
