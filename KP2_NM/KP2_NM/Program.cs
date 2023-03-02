using System;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using static System.Collections.Specialized.BitVector32;

namespace KP2_NM;

class Program
{
    static void Main(string[] args)
    {
        Func<double, double> f = x => Math.Pow(Math.Tan(x), 2) - (1 + (1 / Math.Sqrt(3))) * Math.Tan(x) + (1 + (1 / Math.Sqrt(3))); // функція, яку використовуємо для методу простої ітерації
        Func<double, double> df = x => ((2 * Math.Sin(x)) / (Math.Pow(Math.Cos(x), 3))) - ((3 + Math.Sqrt(3 / 3 * Math.Pow(Math.Cos(x), 2)))); // похідна функції
        Func<double, double> f1 = x => Math.Pow(Math.Tan(x), 2) - 2 * Math.Tan(x) + 1; // функція, яку використовуємо для методу простої ітерації
        Func<double, double> df1 = x => ((2 * Math.Sin(x)) - (2 * Math.Cos(x)) / Math.Pow(Math.Cos(x), 3));  // похідна функції
        Func<double, double> f2 = x =>Math.Sin(0.5+x)-2*x+0.5;
        Func<double, double> f3 = x => Math.Pow(x,3) + 3 * x + 1;
        double x0 = 1.0; // початкове наближення
        Console.WriteLine("If you want to solve Function f(x) input (0), if g(x) - (1), if p(x) - (2), if q(x) - (3)");
        int input = int.Parse(Console.ReadLine()!);
        Console.WriteLine("input precision");
        double eps = double.Parse(Console.ReadLine()!); ; // точність, з якою шукаємо розв'язок
        int maxIter = 10000; // максимальна кількість ітерацій
        if (input == 0)
        {
            Console.WriteLine("f(x)");
            try
            {
                double x = NewtonMethod.Solve(f, df, x0, eps, maxIter);
                Console.WriteLine($"Розв'язок: {x}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                double x = SimplifiedNewtonMethod.Solve(f, df, x0, eps, maxIter);
                Console.WriteLine($"Розв'язок: {x}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        else if(input == 1 ) 
        {
            Console.WriteLine("g(x)");
            try
            {
                double x = NewtonMethod.Solve(f1, df1, x0, eps, maxIter);
                Console.WriteLine($"Розв'язок: {x}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                double x = SimplifiedNewtonMethod.Solve(f1, df1, x0, eps, maxIter);
                Console.WriteLine($"Розв'язок: {x}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        else if(input == 2 )
        {
            try
            {
                double x = SimpleIterationMethod.Solve(f2, x0, eps, maxIter);
                Console.WriteLine($"Розв'язок: {x}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        else if (input == 3)
        {
            try
            {
                double x = SimpleIterationMethod.Solve(f3, x0, eps, maxIter);
                Console.WriteLine($"Розв'язок: {x}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

