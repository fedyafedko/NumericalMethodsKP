using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP2_NM;

class SimpleIterationMethod
{
    public static double Solve(Func<double, double> f, double x0, double eps, int maxIter)
    {
        double x1 = x0;
        int iter = 0;

        while (iter < maxIter)
        {
            x1 = f(x0); // обчислення наступного наближення
            if (Math.Abs(x1 - x0) < eps)
            {
                return x1; // повертаємо результат, якщо досягнуто необхідну точність
            }
            x0 = x1;
            iter++;
        }

        throw new Exception("Не вдалося знайти розв'язок з необхідною точністю"); // якщо досягнуто максимальну кількість ітерацій і розв'язок не знайдено з необхідною точністю, викидаємо виключення
    }
}
