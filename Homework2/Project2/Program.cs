using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string s = "";
                Console.WriteLine("请输入数组元素个数：");
                s = Console.ReadLine();
                int cont;
                cont = Int32.Parse(s);
                int[] num;
                num = new int[cont];
                Console.WriteLine("请依次输入数组元素值（用回车符隔开）：");
                for (int i = 0; i < cont; i++)
                {
                    s = Console.ReadLine();
                    num[i] = Int32.Parse(s);
                }

                int maxNum =0;
                int minNum =0;
                int sum = 0;
                for(int i=0;i<cont;i++)
                {
                    sum += num[i];
                    if(num[i]>num[maxNum])
                    {
                        maxNum = i;
                    }
                    if(num[i]<num[minNum])
                    {
                        minNum = i;
                    }
                }
                Console.WriteLine("最大值是：" + num[maxNum]);
                Console.WriteLine("最小值是：" + num[minNum]);
                Console.WriteLine("总和是：" + sum);
                Console.WriteLine("平均值是：" + (double)sum/cont);
            }
            catch (Exception m)
            {
                Console.WriteLine("输入不是整数！");      //输入不是整数，提示
            }
        }
    }
}
