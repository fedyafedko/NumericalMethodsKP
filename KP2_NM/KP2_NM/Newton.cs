namespace KP2_NM;

class NewtonMethod 
{
    public static double Solve(Func<double, double> f, Func<double, double> df, double x0, double eps, int maxIter)
    {
        double x = x0; // початкове наближення
        int iter = 0;

        while (iter < maxIter && Math.Abs(f(x)) > eps)
        {
            x = x - f(x) / df(x); // обчислюємо нову точку методом Ньютона
            iter++;
        }

        if (iter >= maxIter)
        {
            throw new Exception("Не вдалося знайти розв'язок з необхідною точністю за максимальну кількість ітерацій.");
        }

        return x; // повертаємо останнє наближення
    }
}
