using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            int num1 = 0;    //第一个操作数
            int num2 = 0;    //第二个操作数
            char op = ' ';   //运算符
            bool flag = false;      //当输入合法时，置flag为true
            bool isLoop = false;      //当开始第二次循环时，置isLoop为true

            while(flag==false)       //当输入不合法时，循环要求重新输入
            {
                if(isLoop==false)     //第一次循环的提示语句与第二次及之后循环的提示语句不同
                {
                    Console.WriteLine("请输入第一个操作数（整数）：");
                    s = Console.ReadLine();
                    flag = int.TryParse(s, out num1);       //输入是整数时，flag置true
                    isLoop = true;   //置isLoop为true，说明之后不再是第一次输入了，
                                     //提示语句会变化为"输入不是整数，请重新输入第一个操作数："
                }
                else
                {
                    Console.WriteLine("输入不是整数，请重新输入第一个操作数：");
                    s = Console.ReadLine();
                    flag = int.TryParse(s, out num1);
                }            
            }
            num1 = Int32.Parse(s);
            flag = false;    //恢复flag和isLoop,用于运算符和第二个操作数输入的合法性判断
            isLoop = false;

            while (flag == false)    //与输入第一个操作数时，同样方式判断输入合法性
            {
                if (isLoop == false)
                {
                    Console.WriteLine("请输入运算符 + - * / 其中之一：");
                    s = Console.ReadLine();
                    flag = char.TryParse(s, out op);      //确定输入是一个字符
                    if(flag==true)
                    {
                        op = char.Parse(s);
                        if(op!='+'&&op!='-'&&op!='*'&&op!='/')   //确定输入是+ - * / 之一
                        {
                            flag = false;
                        }
                    }
                    isLoop = true;
                }
                else
                {
                    Console.WriteLine("输入不是 + - * / 之一，请重新输入运算符：");
                    s = Console.ReadLine();
                    flag = char.TryParse(s, out op);
                    if (flag == true)
                    {
                        op = char.Parse(s);
                        if (op != '+' && op != '-' && op != '*' && op != '/')
                        {
                            flag = false;
                        }
                    }
                }
            }
            op = char.Parse(s);
            flag = false;
            isLoop = false;

            while (flag == false)    //与输入第一个操作数时，同样方式判断输入合法性
            {
                if (isLoop == false)
                {
                    Console.WriteLine("请输入第二个操作数（整数）：");
                    s = Console.ReadLine();
                    flag = int.TryParse(s, out num2);
                    isLoop = true;
                }
                else
                {
                    Console.WriteLine("输入不是整数，请重新输入第二个操作数：");
                    s = Console.ReadLine();
                    flag = int.TryParse(s, out num2);
                }
            }
            num2 = Int32.Parse(s);
            
            if (op == '+')      //根据运算符op的不同，进行不同的运算
            {
                Console.WriteLine($"计算得: {num1}{op}{num2}={num1+num2}");
            }
            else if (op == '-')
            {
                Console.WriteLine($"计算得: {num1}{op}{num2}={num1 - num2}");
            }
            else if (op == '*')
            {
                Console.WriteLine($"计算得: {num1}{op}{num2}={num1 * num2}");
            }
            else
            {
                if(num2==0)
                {
                    Console.WriteLine($"计算: {num1}{op}{num2}, 零不能作除数！");
                }
                else
                {
                    Console.WriteLine($"计算得: {num1}{op}{num2}={(double)num1 / num2}");
                }               
            }           
            Console.ReadKey();
        }
    }
}
