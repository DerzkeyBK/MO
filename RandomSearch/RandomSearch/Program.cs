using System;
using System.Threading;

namespace RandomSearch
{
    public class Method
    {
        public static double Fun(double x, double y)
        {
            double result = 4 * (x - 5) * (x - 5) + (y - 6) * (y - 6);
            return result;
        }


       // public static void Vector(double v)
       //{
       //   Random r = new Random();
       //   v= r.Next(0, 180);
       //}
    }


    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Console.WriteLine("Введите начальные точки");
            double x = Convert.ToDouble(Console.ReadLine());
            double y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите шаг");
            double h = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите погрешность");
            Int16 eps = Convert.ToInt16(Console.ReadLine());
            double x1=0;
            double y1=0;
            while (Math.Abs((Method.Fun(x, y)- Method.Fun(x1, y1))) > eps)
            {
                double rad = r.Next(0, 360) / Math.PI;
                x1 = x +h*Math.Cos(rad);
                y1 = y +h*Math.Sin(rad);
                if(Method.Fun(x,y)> Method.Fun(x1, y1))
                {
                    x = x1;
                    y = y1;
                }
                Console.WriteLine("{0:###.##}  x = {1} y= {2}", Method.Fun(x, y), x, y);
                Thread.Sleep(200);
            }
            Console.WriteLine("_____________________________________________________________");
            Console.WriteLine("Минимум функции = {0:#.##} достигается в точках x = {1:#.##} y= {2:#.##}", Method.Fun(x, y),x,y);

        }
    }
}
