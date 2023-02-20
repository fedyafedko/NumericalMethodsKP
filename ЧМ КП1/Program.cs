using System;
using System.Reflection.Metadata.Ecma335;

namespace KP1;

class Program
{
    static void Main(string[] args)
    {
        double result;
        Console.WriteLine("If you want to solve Bisection method input (0), if Secant method - (1), if Newton's method - (2)");
        string input = Console.ReadLine()!;
        Console.WriteLine("If you want to solve Function f(x) input (0), if g(x) - (1)");
        string input1 = Console.ReadLine()!;
        MethodBase method;
        MethodBase method2;
        if (input == "0")
        {
            method = new Bisection(0, 2);
            method2 = new Bisection(0, 2);
        }
        else if (input == "1")
        {
            method = new Secant(0, 2);
            method2 = new Secant(0, 2);
        }
        else if (input == "2")
        {
            method = new Newton(0, 2);
            method2 = new Newton(0,2);
        }
        else
        {
            throw new Exception();
        }
        if (input1 == "0")
        {
            Console.WriteLine("Function f(x)");
            result = method.Method(0, 2, Math.Pow(10, -4));
            Console.WriteLine($"Solutions with precision 10^(-4): {result}");
            result = method.Method(0, 2, Math.Pow(10, -5));
            Console.WriteLine($"Solutions with precision 10^(-5): {result}");
            result = method.Method(0, 2, Math.Pow(10, -6));
            Console.WriteLine($"Solutions with precision 10^(-6): {result}");
        }
        else if (input1 == "1") 
        {
            Console.WriteLine("Function g(x)");
            result = method2.Method2(0, 2, Math.Pow(10, -4));
            Console.WriteLine($"Solutions with precision 10^(-4): {result}");
            result = method2.Method2(0, 2, Math.Pow(10, -5));
            Console.WriteLine($"Solutions with precision 10^(-5): {result}");
            result = method2.Method2(0, 2, Math.Pow(10, -6));
            Console.WriteLine($"Solutions with precision 10^(-6): {result}");
        }
        
        
    }
}
