using System;


namespace KP1;

class Program
{
    static void Main(string[] args)
    {
        double result;
        Bisection bis = new Bisection(0,2);
        result = bis.Method(0, 2, Math.Pow(10, -4));
        Console.WriteLine($"Solutions with precision 10^(-4): {result}");
        result = bis.Method(0, 2, Math.Pow(10, -5));
        Console.WriteLine($"Solutions with precision 10^(-5): {result}");
        result = bis.Method(0, 2, Math.Pow(10, -6));
        Console.WriteLine($"Solutions with precision 10^(-6): {result}");
    }
}
