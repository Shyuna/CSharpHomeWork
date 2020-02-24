using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string s = "";
                Console.WriteLine("请输入一个正整数:");
                s = Console.ReadLine();
                int num = 0;
                num = Int32.Parse(s);
                bool flag = true;
                for (int i = 2; i <= num; i++)
                {
                    if (num % i != 0)                   //i是num的因数
                    {
                        continue;
                    }
                    for (int j = 2; j < i; j++)        //判断i是否是素数
                    {
                        if (i % j == 0)
                        {
                            flag = false;               //i不是素数
                            break;
                        }
                    }
                    if (flag)                          //i是素数，则输出
                    {
                        Console.WriteLine(i);
                    }
                    flag = true;                        //恢复flag，用于下次判断
                }
            }
            catch (Exception m)
            {
                Console.WriteLine("输入不是整数！");      //输入不是整数，提示
            }
        }
    }
}
