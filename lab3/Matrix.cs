using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace lab3
{
    class Matrix
    {

        public int[,] generateMatrix(int size)
        {
            Random random = new Random();

            int[,] matrix = new int[size, size];

            for(int i=0; i<size; ++i)
            {   
                for(int j=0; j<size; j++)
                {
                    matrix[i, j] = random.Next(0, 10);

                }
            }

            return matrix;
        }

        public int[,] multiply(int[,] matrix1, int[,] matrix2, int maxParallelDegree, bool timeMeasure)
        {
            int size1 = matrix1.GetLength(0);
            int size2 = matrix2.GetLength(0);

            if(size1 != size2)
            {
                Console.WriteLine("Rozny rozmiar macierzy!");
            }

            int[,] finalMatrix = new int[size1,size1];

            ParallelOptions opt = new ParallelOptions()
            {
                MaxDegreeOfParallelism = maxParallelDegree
            };

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            Parallel.For(0, size1, opt, i =>
            {
                for (int j = 0; j < size1; ++j)
                {
                    for (int k = 0; k < size1; ++k)
                    {
                        finalMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            });
            stopwatch.Stop();

            long elapsedTimeMs = stopwatch.ElapsedMilliseconds;

            if (timeMeasure)
                Console.WriteLine(elapsedTimeMs);

            return finalMatrix;
        }



        public void printMatrix(int[,] matrix)
        {
            int size = matrix.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
            }
        }
    }

