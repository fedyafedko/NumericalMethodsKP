namespace KP1;

internal abstract class MethodBase
{
    protected (double min, double max) _bounds;

    public MethodBase(double min, double max)
    {
        if (min > max)
            throw new ArgumentException(nameof(min));

        _bounds = (min, max);
    }

    public abstract double Eps { get; }


    public abstract double Method(double a, double b, double eps);
    public abstract double Method2(double a, double b, double eps);

    public virtual double Function(double a)
    {
        return Math.Pow(Math.Cos(a), 2) + (0.5 * Math.Cos(a)) + 1 / 18;
    }
    public virtual double Function2(double a)
    {
        return Math.Pow(Math.Cos(a), 2) + (1 / 3 * Math.Cos(a)) + 1 / 36;
    }
}
