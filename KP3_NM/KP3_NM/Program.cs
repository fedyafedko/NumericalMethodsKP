using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace KP3_NM;

class Program
{
    static void Main(string[] args)
    {
        double[,] matrixslar =
        {
            {0.63,-0.76,1.34, 0.37},
            {0.54,0.83,-0.74, -1.27},
            {0.24,-0.44,0.35, 0.55},
            {0.43,-1.21,2.32, -1.41}
        };
        double[] vector = { 1.21, 0.86, 0.25, 1.55 };
        SloveSystem sloveSystem = new SloveSystem();
        sloveSystem.SolveSystem(matrixslar, vector);
        Console.WriteLine("\n"+"Evclid norm and number:");
        Evclid evclid = new Evclid();
        int N = 25;
        // initialize matrix
        double[,] matrix = new double[5,5];
        for(int i = 0; i <matrix.GetLength(0); i++)
        {
            for(int j = 0; j < matrix.GetLength(1); j++) 
            {
                double c = 0.1 * N * (i+1) * (j+1);
                matrix[i, j] = 321 / (Math.Pow(1 + c, 6));
            }
        }
        evclid.Matrix(matrix);
        // initialize vector
        double[] vectorEvc = new double[5];
        for(int i = 0; i< vectorEvc.Length; i++)
        {
            vectorEvc[i] = N;
        }
        // calculate vector norm
        double norm = 0;
        for (int i = 0; i < vectorEvc.Length; i++)
        {
            norm += vectorEvc[i] * vectorEvc[i];
        }
        norm = Math.Sqrt(norm);
        Console.WriteLine("Vector norm: " + norm);
        Console.WriteLine("Task3:");
        Task3 task3 = new Task3();
        double[,] Matrix =
        {
            { 0.95,0.5,-1},
            {0.98,0.7,-1 },
            { 1.125,0.87,-1}
        };
        double[] Vector = { 1.21, 1.96, 5.06 };
        task3.Print(Matrix,Vector);
        double[] vectorSolve = sloveSystem.SolveSystem(Matrix, Vector);
        task3.SloveTask(vectorSolve);
        


    }
    
}