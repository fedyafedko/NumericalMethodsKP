
namespace KP1;

class Newton : MethodBase
{
    double x0 = 1.5;
    public Newton(double min, double max) : base(min, max) { }

    public override double Eps => Math.Pow(10, -4);

    public double DerivativeF(double x)
    {
        return -2 * Math.Sin(x) * Math.Cos(x) - Math.Sin(x) / 2;
    }
    public double DerivativeF2(double x)
    {
        return 2 * Math.Pow(Math.Sin(x), 2) * (-2 * Math.Pow(Math.Sin(x), 2)) - Math.Cos(x) / 2;
    }
    public override double Method(double a, double b, double eps)
    {
        double x = x0;
        while (Math.Abs(Function(x)) > eps)
        {
            x = x - Function(x) / DerivativeF(x);

        }
        return x;
        throw new NotImplementedException();
    }

    public double Derivative2F(double x)
    {
        return -2 * Math.Sin(x) * Math.Cos(x) - Math.Sin(x) / 3;
    }
    public double Derivative2F2(double x)
    {
        return 2 * Math.Pow(Math.Sin(x), 2) * (-2 * Math.Pow(Math.Sin(x), 2)) - Math.Cos(x) / 3;
    }

    public override double Method2(double a, double b, double eps)
    {
        double x = 1.3;
        while (Math.Abs(Function2(x)) > eps)
        {
            x = x - Function2(x) / Derivative2F2(x);
            return x;
        }

        throw new NotImplementedException();
    }
}
