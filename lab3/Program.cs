using System.Numerics;

namespace lab3
{
    // usrednij 5 wynikow
    // mierzenie czasu z parallel obejmuje tez tworzenie watkow

    internal class Program
    {
        static void Main(string[] args)
        {
            int measurements = 5;
            int watki = 10;
            Matrix matrix = new Matrix();


            Console.WriteLine("MACIERZ 100\n");
            for(int i=0; i<measurements; ++i)
            {
                int[,] mtx1 = matrix.generateMatrix(100);
                int[,] mtx2 = matrix.generateMatrix(100);
                matrix.multiply(mtx1, mtx2, watki, true);
            }

            //matrix.printMatrix(mtx1);
            //matrix.printMatrix(mtx2);


        }
    }
}
