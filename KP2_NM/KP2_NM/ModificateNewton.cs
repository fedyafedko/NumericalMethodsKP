
namespace KP2_NM;

class SimplifiedNewtonMethod
{
    public static double Solve(Func<double, double> f, Func<double, double> df, double x0, double eps, int maxIter)
    {
        double x1 = x0;
        int iter = 0;

        while (iter < maxIter)
        {
            double fx = f(x1); // обчислюємо значення функції в точці x1
            double dfx = df(x1); // обчислюємо значення похідної функції в точці x1
            x1 = x1 - fx / dfx; // обчислюємо наступне наближення
            if (Math.Abs(fx) < eps)
            {
                return x1; // повертаємо результат, якщо досягнуто необхідну точність
            }
            iter++;
        }

        throw new Exception("Не вдалося знайти розв'язок з необхідною точністю"); // якщо досягнуто максимальну кількість ітерацій і розв'язок не знайдено з необхідною точністю, викидаємо виключення
    }
}
