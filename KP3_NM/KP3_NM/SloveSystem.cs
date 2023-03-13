using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP3_NM
{
    class SloveSystem
    {
        
        public double[] SolveSystem(double[,] A, double[] b)
        {
            int n = A.GetLength(0);

            // LU-разложение матрицы системы
            double[,] LU = LUDecomposition(A);

            // Вычисление определителя матрицы системы
           
            double det = Determinant(LU);
            // Вычисление обратной матрицы системы
            double[,] AInv = InvertMatrixLU(LU);

            // Решение системы уравнений
            double[] x = new double[n];
            double[] y = new double[n];
            for (int i = 0; i < n; i++)
            {
                double s = 0;
                for (int j = 0; j < i; j++)
                {
                    s += LU[i, j] * y[j];
                }
                y[i] = b[i] - s;
            }
            for (int i = n - 1; i >= 0; i--)
            {
                double s = 0;
                for (int j = i + 1; j < n; j++)
                {
                    s += LU[i, j] * x[j];
                }
                x[i] = (y[i] - s) / LU[i, i];
            }

            Console.WriteLine("Matrix determinant " + det);
            Console.WriteLine("Inverse matrix: ");
            PrintMatrix(AInv);
            Console.WriteLine("System solution: ");
            PrintVector(x);
            return x;
        }
        public static double Determinant(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            double det = 0;

            if (n == 1)
            {
                det = matrix[0, 0];
            }
            else if (n == 2)
            {
                det = matrix[0, 0] * matrix[1, 1] - matrix[1, 0] * matrix[0, 1];
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    double[,] submatrix = new double[n - 1, n - 1];
                    for (int j = 1; j < n; j++)
                    {
                        for (int k = 0; k < n; k++)
                        {
                            if (k < i)
                            {
                                submatrix[j - 1, k] = matrix[j, k];
                            }
                            else if (k > i)
                            {
                                submatrix[j - 1, k - 1] = matrix[j, k];
                            }
                        }
                    }
                    det += Math.Pow(-1, i) * matrix[0, i] * Determinant(submatrix);
                }
            }

            return det;
        }
        public static double[,] InvertMatrixLU(double[,] LU)
        {
            int n = LU.GetLength(0);
            double[,] AInv = new double[n, n];
            double[] e = new double[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    e[j] = (i == j) ? 1 : 0;
                }

                double[] x = SolveLowerTriangularMatrix(LU, e);
                double[] y = SolveUpperTriangularMatrix(LU, x);

                for (int j = 0; j < n; j++)
                {
                    AInv[j, i] = y[j];
                }
            }

            return AInv;
        }

        public static double[] SolveLowerTriangularMatrix(double[,] L, double[] b)
        {
            int n = L.GetLength(0);
            double[] y = new double[n];

            for (int i = 0; i < n; i++)
            {
                double s = 0;
                for (int j = 0; j < i; j++)
                {
                    s += L[i, j] * y[j];
                }
                y[i] = (b[i] - s) / L[i, i];
            }

            return y;
        }

        public static double[] SolveUpperTriangularMatrix(double[,] U, double[] b)
        {
            int n = U.GetLength(0);
            double[] x = new double[n];

            for (int i = 0; i < n; i++)
            {
                double s = 0;
                for (int j = 0; j < i; j++)
                {
                    s += U[i, j] * x[j];
                }
                x[i] = (b[i] - s) / U[i, i];
            }

            return x;
        }
        public static double[,] LUDecomposition(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            double[,] L = new double[n, n];
            double[,] U = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                // Расчет элементов матрицы L
                for (int j = 0; j < i; j++)
                {
                    double s = 0;
                    for (int k = 0; k < j; k++)
                    {
                        s += L[i, k] * U[k, j];
                    }
                    L[i, j] = (matrix[i, j] - s) / U[j, j];
                }
                L[i, i] = 1;

                // Расчет элементов матрицы U
                for (int j = i; j < n; j++)
                {
                    double s = 0;
                    for (int k = 0; k < i; k++)
                    {
                        s += L[i, k] * U[k, j];
                    }
                    U[i, j] = matrix[i, j] - s;
                }
            }

            // Объединение матриц L и U
            double[,] LU = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i <= j)
                    {
                        LU[i, j] = U[i, j];
                        for (int k = 0; k < i; k++)
                        {
                            LU[i, j] -= L[i, k] * U[k, j];
                        }
                    }
                    else
                    {
                        LU[i, j] = L[i, j];
                        for (int k = 0; k < j; k++)
                        {
                            LU[i, j] -= L[i, k] * U[k, j];
                        }
                    }
                }
            }

            return LU;
        }
        static void PrintMatrix(double[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(Math.Round(arr[i, j],2)+" ");
                }
                Console.WriteLine();
            }
        }
        static void PrintVector(double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] +" ");
            }
        }
    }
}
