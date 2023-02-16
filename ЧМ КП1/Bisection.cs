namespace KP1;

class Bisection : MethodBase
{
    public Bisection(double min, double max) : base(min, max) { }

    public override double Eps => Math.Pow(10, -4);

    public override double Method(double a, double b, double eps)
    {
        double x;
        while (Math.Abs(b - a) > eps)
        {
            x = (a + b) / 2;
            if (Function(a) * Function(x) < 0)
                b = x;
            else
                a = x;
        }
        return (a + b) / 2;
    }
}
