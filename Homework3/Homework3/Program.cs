using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3_1
{
    //抽象产品角色
    public abstract class Graph
    {
        public double s;
        public abstract void getNumber();
        public abstract double calculateAreas();
        public void show()
        {
            Console.WriteLine("面积为：" + s);
        }
    }

    //具体产品角色--圆形
    class Circle : Graph
    {
        private double r;
        private string str = "";
        public override void getNumber()
        {
            str = Console.ReadLine();
            r = Double.Parse(str);
        }

        public override double calculateAreas()
        {
            s = Math.PI * r * r;
            return s;
        }
    }

    //具体产品角色--正方形
    class Square : Graph
    {
        private double a;
        private string str = "";
        public override double calculateAreas()
        {
            s = a * a;
            return s;
        }

        public override void getNumber()
        {
            str = Console.ReadLine();
            a = Double.Parse(str);
        }
    }

    //具体产品角色--长方形
    class Rectangle : Graph
    {
        private double m, n;
        private string str = "";
        public override double calculateAreas()
        {
            s = m * n;
            return s;
        }

        public override void getNumber()
        {
            str = Console.ReadLine();
            m = Double.Parse(str);
            str = Console.ReadLine();
            n = Double.Parse(str);
        }
    }
    //具体产品角色--三角形
    class Triangle : Graph
    {
        private double x, y, z;
        private string str = "";
        public override double calculateAreas()//利用海伦公式求三角形面积
        {
            double t = (x + y + z) / 2;
            s = Math.Sqrt(t * (t - x) * (t - y) * (t - z));
            return s;
        }

        public override void getNumber()
        {
            str = Console.ReadLine();
            x = Double.Parse(str);
            str = Console.ReadLine();
            y = Double.Parse(str);
            str = Console.ReadLine();
            z = Double.Parse(str);
        }
    }
    class Factory
    {
        public static Graph getGraph(String type)
        {
            Graph graph = null;
            if (String.Equals(type, "Circle"))
            {
                graph = new Circle();
                Console.WriteLine("计算圆形面积，输入半径：");
            }
            else if (type.Equals("Square"))
            {
                graph = new Square();
                Console.WriteLine("计算正方形面积，输入边长：");
            }
            else if (type.Equals("Rectangle"))
            {
                graph = new Rectangle();
                Console.WriteLine("计算长方形面积，分别输入长宽：");
            }
            else if (type.Equals("Triangle"))
            {
                graph = new Triangle();
                Console.WriteLine("计算三角形面积：分别输入三条边长：");
            }
            else
            {
                Console.WriteLine("输入错误");
            }


            return graph;
        }
    }
    class Client
    {
        static void Main(string[] args)
        {
            Graph graph;
            graph = Factory.getGraph("Triangle");
            graph.getNumber();
            graph.calculateAreas();
            graph.show();
        }
    }
}

