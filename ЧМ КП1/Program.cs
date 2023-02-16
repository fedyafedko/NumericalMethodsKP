using System;


namespace KP1;

class Program
{
    static void Main(string[] args)
    {
        double result;
        Console.WriteLine("If you want to solve Bisection method input (0), if Secant method - (1), if Newton's method - (2)");
        string input = Console.ReadLine()!;
        MethodBase method;
        if (input == "0")
        {
            method = new Bisection(0, 2);
        }
        else if (input == "1")
        {
            method = new Secant(0, 2);
        }
        else if (input == "2")
        {
            method = new Newton(0, 2);
        }
        else
        {
            throw new Exception();
        }
        result = method.Method(0, 2, Math.Pow(10, -4));
        Console.WriteLine($"Solutions with precision 10^(-4): {result}");
        result = method.Method(0, 2, Math.Pow(10, -5));
        Console.WriteLine($"Solutions with precision 10^(-5): {result}");
        result = method.Method(0, 2, Math.Pow(10, -6));
        Console.WriteLine($"Solutions with precision 10^(-6): {result}");
    }
}
