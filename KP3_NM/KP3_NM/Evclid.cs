using System;


namespace KP3_NM
{
    class Evclid
    {
        public void Matrix(double[,] matrix)
        {

            // calculate matrix norm
            double norm = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    norm += matrix[i, j] * matrix[i, j];
                }
            }
            norm = Math.Sqrt(norm);
            Console.WriteLine("Matrix norm: " + norm);

            // calculate matrix condition number
            double[,] matrixInverse = new double[matrix.GetLength(0), matrix.GetLength(1)];
            double det = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrixInverse[j, i] = Math.Pow(-1, i + j) * MatrixMinor(matrix, i, j);
                    if (i == 0)
                    {
                        det += matrix[i, j] * matrixInverse[j, i];
                    }
                }
            }
            double conditionNumber = norm * MatrixNorm(matrixInverse);
            Console.WriteLine("Matrix condition number: " + conditionNumber);
        }

        public double MatrixNorm(double[,] matrix)
        {
            double norm = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double rowSum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    rowSum += Math.Abs(matrix[i, j]);
                }
                norm = Math.Max(norm, rowSum);
            }
            return norm;
        }

        public double MatrixMinor(double[,] matrix, int row, int col)
        {
            double[,] minorMatrix = new double[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            int minorRow = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == row) continue;
                int minorCol = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == col) continue;
                    minorMatrix[minorRow, minorCol] = matrix[i, j];
                    minorCol++;
                }
                minorRow++;
            }
            return Determinant(minorMatrix);
        }

        public double Determinant(double[,] matrix)
        {
            double det = 0;
            if (matrix.GetLength(0) == 2)
            {
                det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    det += Math.Pow(-1, j) * matrix[0, j] * MatrixMinor(matrix, 0, j);
                }
            }
            return det;
        }
    }
}
