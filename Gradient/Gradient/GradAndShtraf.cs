using System;
using System.Threading;

namespace Gradient
{
    public class Grad
    {
        public double x;
        public double y;

        public Grad(double a,double b)
        {
            x=a;
            y=b;
        }

        public double Function()
        {
            double f = 11 * Math.Pow((y - x * x), 2)+Math.Pow((1-x),2);
            return f;
        }

        public static double Function(double x, double y)
        {
            double f = 11 * Math.Pow((y - x * x), 2) + Math.Pow((x - 1), 2);
            return f;
        }

        public static double ShFunction(double x, double y)
        {
            double result = x + y - 2;
            return result;
        }

        public static double Check(double x, double y,int r)
        {
            if (Grad.ShFunction(x, y) > 0)
            {
                double result = (1/(x+y-2))* r;
                return result;
            }
            else
            {
                double result = 0;
                return result;
            }
        }

        public double Gdx()
        {
            double dU = -2*x*(-11*x*x+11*y)-22*x*(-x*x+y)+2*x-2;
            return dU;
        }

        public double Gdy()
        {
            double dU =  -22 * x*x  + 22 * y;
            return dU;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите стартовые точки");
            double x = Convert.ToDouble(Console.ReadLine());
            double y = Convert.ToDouble(Console.ReadLine());
            Grad f = new Grad(x, y);
            double eps = 0.0001;
            double h = 0.5;
            Console.WriteLine("Начальное значение функции");
            Console.WriteLine(f.Function());
            double x1 = 0;
            double y1 = 0;
            int r = 1;
            
            while (h > eps)
            {
                Console.WriteLine("Значение функции {0} Значения точек  {1} {2}", f.Function(), f.x, f.y);
                x1 = f.x - f.Gdx() * h;
                y1 = f.y - f.Gdy() * h;
                if (f.Function()-Grad.Check(f.x,f.y,r) > Grad.Function(x1, y1)-Grad.Check(x1,y1,r))
                {
                    f.x = x1;
                    f.y = y1;
                   
                }
                else
                {
                    h = h / 2;
                  
                }
                Thread.Sleep(300);
                r++;
            }

            
            Console.WriteLine("Ответ");
            Console.WriteLine("{0} {1} {2}", f.Function(),f.x,f.y);
            Console.ReadKey();
            //gitcheck
        }
    }
}
