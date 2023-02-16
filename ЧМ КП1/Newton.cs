
namespace KP1;

class Newton : MethodBase
{
    double x0 = 1.5;
    public Newton(double min, double max) : base(min, max) { }

    public override double Eps => Math.Pow(10,-4);

    public double DerivativeF(double x)
    {
        return -Math.Sin(2*x)-Math.Sin(x)/2;
    }
    public double DerivativeF2(double x)
    {
        return -2*Math.Cos(2 * x) - Math.Cos(x) / 2;
    }

    public double Сoincidence (double x)
    {
        double kx = Function(x) * DerivativeF2(x);
        return kx;
    }
    public override double Method(double a, double b, double eps)
    {
        double x = x0;
        while (Math.Abs(Function(x)) > eps)
        {
            x = x-Function(x)/DerivativeF(x);
            return x;
        }
        throw new NotImplementedException();
    }
}
