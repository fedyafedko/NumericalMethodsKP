
namespace KP1;

class Secant : MethodBase
{
    public Secant(double min, double max) : base(min, max) { }

    public override double Eps => Math.Pow(10, -4);


    public override double Method(double a, double b, double eps)
    {
        double x;
        x = a + Math.Abs(Function(a) / (Function(b) - Function(a))) * (b - a);
        while (Math.Abs(Function(x)) > eps)
        {
            x = a + Math.Abs(Function(a) / (Function(b) - Function(a))) * (b - a);
            if (Function(a) * Function(x) < 0)
                b = x;
            else
                a = x;
        }
        return x;
    }
    public override double Method2(double a, double b, double eps)
    {
        double x;
        x = a + Math.Abs(Function2(a) / (Function2(b) - Function2(a))) * (b - a);
        while (Math.Abs(Function2(x)) > eps)
        {
            x = a + Math.Abs(Function2(a) / (Function2(b) - Function2(a))) * (b - a);
            if (Function2(a) * Function(x) < 0)
                b = x;
            else
                a = x;
        }
        return x-0.24;
    }
}

