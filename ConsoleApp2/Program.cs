using System;
using System.Numerics;

namespace Task
{

    enum  Operation { Sum, Subtraction, Multiplication, Division, Pow, Sqrt}
	class Program
	{

		static int Main()
		{

            Task1();
            Task2();
            Task34();
            Operation operat = Operation.Division;
            Console.WriteLine("DoOperation({1}) = {0:f3} ", DoOperation(operat, 47, 12), operat); 

			return 0;
		}



        //1. Создать массив размерности N, и заполнить его числами от 1 до N.
        //    Вывести элементы массива в обратном порядке.
        static void Task1()
		{
            Console.Write("Введите длину массива: ");
            int.TryParse(Console.ReadLine(), out int N);

            int[] arr = new int[N];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }

            Array.Reverse(arr);

            Console.WriteLine("Массив: ");
            foreach (int i in arr)
                Console.Write($"{i} ");

            Console.WriteLine();
        }



        //2. Заполнить «квадратный» массив произвольной размерности
        //подобным образом:

        static void Task2()
        {

            Console.Write("Размер матрицы: ");
            int.TryParse(Console.ReadLine(), out int N); 
            int[,] matrix = new int[N, N];      //строки, столбцы

            for(int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i - 1 <= j)
                        matrix[i, j] = 1;
                }
            }
            MatrixPrint(matrix, N, N);
        }

        //Заполнить массив размерности M * N спиралью

        static void Task34()
        {
            Console.Write("Размер матрицы M * N:\n Строк = ");
            int.TryParse(Console.ReadLine(), out int M);
            Console.Write(" Столбцов = ");
            int.TryParse(Console.ReadLine(), out int N);
            int[,] matrix = new int[M, N];      //строки, столбцы

            if (M == 1 || N == 1) { Console.WriteLine("Я не могу обработать эту матрицу"); return; }

            int count = 1;
            int a = -1;
            int b = 0;
            do{

                a++; b++;

                for (int i = a; i <= N - b && matrix[a, i] == 0; i++)
                {
                    matrix[a, i] = count;                                               //Right
                    count++;
                }

                for (int i = b; i <= M - b && matrix[i, N - b] == 0; i++)
                {
                    matrix[i, N - b] = count;                                           //Down
                    count++;
                }

                for (int i = N - b - 1; i >= 0 && matrix[M - b, i] == 0; i--)
                {
                    matrix[M - b, i] = count;                                           //Left
                    count++;
                }

                for (int i = M - b - 1; i > 0 && matrix[i, a] == 0; i--)
                {
                    matrix[i, a] = count;                                               //Up
                    count++;
                }


            } while (count <= M * N);

            MatrixPrint(matrix, M, N);

        }

        static void MatrixPrint(int[,] matrix, int M, int N)
        {
            Console.WriteLine("\nМатрица: ");
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(" {0} ", matrix[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }



        //Сделать так, чтобы тип операции определялся с
        //помощью перечислений.
        static double DoOperation(Operation op, double a, double b)
        {
            switch (op)
            {
                case Operation.Sum: 
                    return a + b;
                case Operation.Subtraction:
                    return a - b;
                case Operation.Multiplication:
                    return a * b;
                case Operation.Division:
                    return a / b;
                case Operation.Pow:
                    return a * a;
                case Operation.Sqrt:
                    return Math.Sqrt(Math.Abs(a));
                default: 
                    return 0;
            }
        }

    }
}