using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KP3_NM
{
    

    class Task3
    {
        private Dictionary<string, double>? Slove;
        

        public void Print(double[,] Matrix, double[] Vector)
        {
            Console.WriteLine("Matrix for solve an equation");
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for(int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.Write(Matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Vector for solve an equation");
            for(int i = 0; i<Vector.Length; i++)
            {
                Console.Write(Vector[i] + " ");
            }
            Console.WriteLine();
        }
         public void SloveTask(double[] array)
         {
            double a1 = array[0] / 2;
            double a3 = array[1] / (2 * a1);
            double a2 = Math.Sqrt(Math.Pow(a1, 2) + Math.Pow(a3, 2) - array[2]);
            Slove = new Dictionary<string, double>();
            Slove.Add("a1", a1);
            Slove.Add("a2", a2);
            Slove.Add("a3", a3);
            Console.WriteLine("\n" + "Solve Task3");
            foreach (KeyValuePair<string,double> item in Slove)
            {
                Console.WriteLine($"{item.Key}:{item.Value}");
            }
         }
        
        
    }
}
