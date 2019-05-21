using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibbonachi
{
    public class Fibbonaci
    {
        public static double Fib(int n)
        {
            int p1 = 0;
            int p2 = 1;
            if (n <= 1) return p1;
            int p;
            for (int j = 2; j < n; j++)
            {
                p = p1;
                p1 = p2;
                p2 = p2 + p;
            }
            return p2;
        }
        public static double Fun(double x)
        {
            double result = 0.1 * (7 + 0) * Math.Pow(x, 3) - (2 + 1) * Math.Pow(x, 2) - 0.1 * (7 + 8) * x - 1;
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите исследуемый отрезок");
            double a = Convert.ToDouble(Console.ReadLine());
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите погрешность");
            double eps= Convert.ToDouble(Console.ReadLine());
            int n = 1;
            while (Fibbonaci.Fib(n) < (b - a) / eps)
            {
                n++;
            }

            double x1=1;
            double x2=1;
            double f1=1;
            double f2=1;
            for (int k = 0; k < n; k++)
            {
                
                
                x1 = a + Fibbonaci.Fib(n - k) / Fibbonaci.Fib(n - k + 2) * (b - a);
                x2 = a + Fibbonaci.Fib(n - k + 1) / Fibbonaci.Fib(n - k + 2) * (b - a);
                f1 = Fibbonaci.Fun(x1);
                f2 = Fibbonaci.Fun(x2);
                if (f1 > f2)
                {
                    b=x2;
                }
                else
                {
                    a = x1;
                }
                
            }
            Console.WriteLine((a + b) / 2);



            Console.ReadKey();
           
        }
    }
}
