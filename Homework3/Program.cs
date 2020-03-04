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
            string s = "";
            Console.WriteLine("请输入要生成形状的数量：");
            int cont = -1;
            bool flag = true;
            while (flag)
            {
                try
                {
                    s = Console.ReadLine();
                    flag = false;
                    cont = Int32.Parse(s);
                }
                catch (FormatException)
                {
                    flag = true;
                    Console.WriteLine("输入不是数字，请重新输入：");
                    continue;
                }
                if(cont <= 0)
                {
                    Console.WriteLine("输入不是正数，请重新输入：");
                    flag = true;
                }
            }
            double totalArea = 0;
            for(int i=0;i<cont;i++)
            {
                string str = "";
                Console.WriteLine($"请在Rectangle,Square,Circle,Triangle中选择将要生成的第{i+1}个形状：");
                str=Console.ReadLine();
                Factory someFactory = new Factory(str);
                while (!someFactory.IsLegal())
                {
                    Console.WriteLine("输入不是Rectangle,Square,Circle,Triangle四个形状之一，请重新输入：");
                    str = Console.ReadLine();
                    someFactory = new Factory(str);
                }
                flag = true;
                Shape oneShape=someFactory.CreatRandShape();
                while(flag)
                {
                    Console.WriteLine("输入rand随机生成形状,输入creat按照给定数据生成形状：");
                    str = Console.ReadLine();
                    if (str == "rand")
                    {
                        flag = false;
                        oneShape=someFactory.CreatRandShape();
                    }
                    else if(str=="creat")
                    {
                        flag = false;
                        oneShape = someFactory.CreatShape();
                    }
                    else
                    {
                        Console.WriteLine("输入不是rand,creat之一，请重新输入。");
                    }
                }
                Console.Write($"第{i+1}个形状是");
                oneShape.PrintDetail();
                Console.WriteLine($"这个形状的面积为：{oneShape.GetArea()}" );
                totalArea += oneShape.GetArea();
            }
            Console.WriteLine($"上面{cont}个形状的面积和为：{totalArea}" );
            Console.Read();
        }
        abstract public class Shape
        {
            public abstract double GetArea();
            public abstract bool IsLegal();
            public abstract void PrintDetail();
        }
        class Rectangle : Shape
        {
            private double width;
            private double height;
            public double Width
            {
                get => width;
                set => width = value;
            }
            public double Height
            {
                get => height;
                set => height = value;
            }
            public Rectangle(double width,double height)
            {
                this.width = width;
                this.height = height;
            }
            override public double GetArea()
            {
                return this.IsLegal()?width * height:-1;
            }
            override public bool IsLegal()
            {
                return (width > 0 && height > 0);
            }
            override public void PrintDetail()
            {
                Console.WriteLine($"长方形。宽为：{this.width}，高为：{this.height}");
            }
        }
        class Circle : Shape
        {
            private double radius;
            private bool isCircle;
            public double Radius
            {
                get => radius;
                set => radius = value;
            }
            public Circle(double radius,bool isCircle)
            {
                this.radius = radius;
                isCircle =true;
            }
            override public double GetArea()
            {
                return this.IsLegal() ? radius * radius*3.14 : -1;
            }
            override public bool IsLegal()
            {
                return (radius > 0 );
            }
            override public void PrintDetail()
            {
                Console.WriteLine($"圆。半径为：{this.radius}");
            }
        }
        class Square : Shape
        {
            private double side;
            public double Side
            {
                get => side;
                set => side = value;
            }
            public Square(double side)
            {
                this.side = side;
            }
            override public double GetArea()
            {
                return this.IsLegal()?side * side:-1;
            }
            override public bool IsLegal()
            {
                return (side > 0);
            }
            override public void PrintDetail()
            {
                Console.WriteLine($"正方形。边长为：{this.side}");
            }
        }
        class Triangle : Shape
        {
            protected double side1;
            protected double side2;
            protected double side3;
            public double Side1
            {
                get => side1;
                set => side1 = value;
            }
            public double Side2
            {
                get => side2;
                set => side2 = value;
            }
            public double Side3
            {
                get => side3;
                set => side3 = value;
            }
            public Triangle(double side1, double side2,double side3)
            {
                this.side1 = side1;
                this.side2 = side2;
                this.side3 = side3;
            }
            override public double GetArea()
            {
                if (!this.IsLegal())
                {
                    return -1;
                }
                double p = (side1 + side2 + side3) / 2;
                return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
            }
            override public bool IsLegal()
            {
             return (side1 > 0 && side2 > 0 && side3 > 0
                    && (side2 + side3 > side1) 
                    && (side1 + side3 > side2) 
                    && (side1 + side2 > side3));
            }
            override public void PrintDetail()
            {
                Console.WriteLine($"三角形。边长一为：{this.side1}，边长二为：{this.side2}，边长三为：{this.side3}");
            }
        }
        class Factory
        {
            private string productionShape;
            public Factory(string productionShape)
            {
                this.productionShape = productionShape;
            }
            public string ProdShape
            {
                get => productionShape;
                set => productionShape = value;
            }
            public bool IsLegal()
            {
                return (productionShape == "Rectangle" 
                    || productionShape == "Square" 
                    || productionShape == "Circle" 
                    || productionShape == "Triangle");
            }
            public Shape CreatRandShape()
            {
                if(productionShape == "Rectangle")
                {
                    double randWidth = new Random(Guid.NewGuid().GetHashCode()).Next(1, 100);
                    double randHight = new Random(Guid.NewGuid().GetHashCode()).Next(1, 100);
                    Shape randRectangle = new Rectangle(randWidth, randHight);
                    return randRectangle;
                }
                else if(productionShape == "Square")
                {
                    double randSide = new Random(Guid.NewGuid().GetHashCode()).Next(1, 100);
                    Shape randSquare = new Square(randSide);
                    return randSquare;
                }
                else if(productionShape == "Circle")
                {
                    double randRadius = new Random(Guid.NewGuid().GetHashCode()).Next(1, 100);
                    Shape randCircle = new Circle(randRadius, true);
                    return randCircle;
                }
                else
                {
                    double randSide1 = new Random(Guid.NewGuid().GetHashCode()).Next(1, 100);
                    double randSide2 = new Random(Guid.NewGuid().GetHashCode()).Next(1, 100);
                    double randSide3 = new Random(Guid.NewGuid().GetHashCode()).Next(1, 100);
                    Shape randTriangle = new Triangle(randSide1, randSide2, randSide3);
                    while (!(randTriangle.IsLegal()))
                    {
                        randSide1 = new Random(Guid.NewGuid().GetHashCode()).Next(1, 100);
                        randSide2 = new Random(Guid.NewGuid().GetHashCode()).Next(1, 100);
                        randSide3 = new Random(Guid.NewGuid().GetHashCode()).Next(1, 100);
                        randTriangle = new Triangle(randSide1, randSide2, randSide3);     
                    }
                    return randTriangle;
                }
            }
            public Shape CreatShape()
            {
                if (productionShape == "Rectangle")
                {
                    string s = "";
                    Console.WriteLine("请输入长方形的宽：");
                    double someWidth=-1;
                    bool flag = true;
                    while (flag)
                    {
                        try
                        {
                            s = Console.ReadLine();
                            flag = false;
                            someWidth = Double.Parse(s);
                        }
                        catch (FormatException)
                        {
                            flag = true;
                            Console.WriteLine("输入不是数字，请重新输入长方形的宽：");
                            continue;
                        }
                        if(someWidth <= 0)
                        {
                            Console.WriteLine("输入小于0，请重新输入长方形的宽：");
                            flag = true;
                        }
                    }
                    Console.WriteLine("请输入长方形的高：");
                    double someHeight = -1;
                    flag = true;
                    while (flag)
                    {
                        try
                        {
                            s = Console.ReadLine();
                            flag = false;
                            someHeight = Double.Parse(s);
                        }
                        catch (FormatException)
                        {
                            flag = true;
                            Console.WriteLine("输入不是数字，请重新输入长方形的高：");
                            continue;
                        }
                        if (someHeight <= 0)
                        {
                            Console.WriteLine("输入不是正数，请重新输入长方形的高：");
                            flag = true;
                        }
                    }
                    Shape someRectangle = new Rectangle(someWidth, someHeight);
                    return someRectangle;
                }
                else if (productionShape == "Square")
                {
                    string s = "";
                    Console.WriteLine("请输入正方形的边长：");
                    double someSide = -1;
                    bool flag = true;
                    while (flag)
                    {
                        try
                        {
                            s = Console.ReadLine();
                            flag = false;
                            someSide = Double.Parse(s);
                        }
                        catch (FormatException)
                        {
                            flag = true;
                            Console.WriteLine("输入不是数字，请重新输入正方形的边长：");
                            continue;
                        }
                        if(someSide <= 0)
                        {
                            Console.WriteLine("输入不是正数，请重新输入正方形的边长：");
                            flag = true;
                        }
                    }
 
                    Shape someSquare = new Square(someSide);
                    return someSquare;
                }
                else if (productionShape == "Circle")
                {
                    string s = "";
                    Console.WriteLine("请输入圆的半径：");
                    double someRadius = -1;
                    bool flag = true;
                    while (flag)
                    {
                        try
                        {
                            s = Console.ReadLine();
                            flag = false;
                            someRadius = Double.Parse(s);
                        }
                        catch (FormatException)
                        {
                            flag = true;
                            Console.WriteLine("输入不是数字，请重新输入圆的半径：");
                            continue;
                        }
                        if (someRadius <= 0)
                        {
                            Console.WriteLine("输入不是正数，请重新输入圆的半径：");
                            flag = true;
                        }
                    }
                    Shape someCircle = new Circle(someRadius, true);
                    return someCircle;
                }
                else
                {
                    Shape someTriangle;
                    do{                       
                        string s = "";
                        Console.WriteLine("请输入三角形的边一：");
                        double someSide1 = -1;
                        bool flag = true;
                        while (flag)
                        {
                            try
                            {
                                s = Console.ReadLine();
                                flag = false;
                                someSide1 = Double.Parse(s);
                            }
                            catch (FormatException)
                            {
                                flag = true;
                                Console.WriteLine("输入不是数字，请重新输入：");
                                continue;
                            }
                            if (someSide1 <= 0)
                            {
                                Console.WriteLine("输入不是正数，请重新输入：");
                                flag = true;
                            }
                        }
                        Console.WriteLine("请输入三角形的边二：");
                        double someSide2 = -1;
                        flag = true;
                        while (flag)
                        {
                            try
                            {
                                s = Console.ReadLine();
                                flag = false;
                                someSide2 = Double.Parse(s);
                            }
                            catch (FormatException)
                            {
                                flag = true;
                                Console.WriteLine("输入不是数字，请重新输入：");
                                continue;
                            }
                            if (someSide2 <= 0)
                            {
                                Console.WriteLine("输入不是正数，请重新输入：");
                                flag = true;
                            }
                        }
                        Console.WriteLine("请输入三角形的边三：");
                        double someSide3 = -1;
                        flag = true;
                        while (flag)
                        {
                            try
                            {
                                s = Console.ReadLine();
                                flag = false;
                                someSide3 = Double.Parse(s);
                            }
                            catch (FormatException)
                            {
                                flag = true;
                                Console.WriteLine("输入不是数字，请重新输入：");
                                continue;
                            }
                            if (someSide3 <= 0)
                            {
                                Console.WriteLine("输入不是正数，请重新输入：");
                                flag = true;
                            }
                        }
                        someTriangle = new Triangle(someSide1, someSide2, someSide3);
                        if(!someTriangle.IsLegal())
                        {
                            Console.WriteLine("输入的数据不能组成三角形，请重新输入：");
                        }
                    } while (!someTriangle.IsLegal());
                    return someTriangle;
                }
            }
        }
    }
}
