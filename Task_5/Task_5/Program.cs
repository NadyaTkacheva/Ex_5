using System;

namespace Task_5
{
    class Program
    {/// <summary>
    ///проверка на ввод
    /// </summary>
    /// <returns></returns>
        static int Input()
        {
            int a = 0;
            bool ok;
            do
            {
                try
                {
                    a = Convert.ToInt32(Console.ReadLine());                    
                   
                    ok = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка! Введите целое число ");                    
                    ok = false;
                }
            } while (!ok);
            return a;
        }
        /// <summary>
        /// ввод матрицы пользователем
        /// </summary>
        /// <param name="mas"></param>
        /// <param name="n"></param>
        static void UserWrite(ref int[,] mas, int n)
        {
            int i, j;
            Console.WriteLine("\nВведите " + n * n + " элементов:");
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.WriteLine("Введите {0}.{1} элемент", i + 1, j + 1);
                    mas[i, j] = Input();
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// ввод с помощью ДСЧ
        /// </summary>
        /// <param name="mas"></param>
        /// <param name="n"></param>
        static void Write(ref int[,] mas, int n)
        {
            Random rnd = new Random();
            int i, j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    mas[i, j] = rnd.Next(-10, 10);
                }
            }
        }
        /// <summary>
        /// вывод матрицы
        /// </summary>
        /// <param name="mas"></param>
        /// <param name="n"></param>
        static void Print(int[,] mas, int n)
        {
            int i, j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write(mas[i, j] + "   ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// поиск максимального в выделенном
        /// </summary>
        /// <param name="matr"></param>
        /// <param name="n"></param>
        static void SearchMax(int [,] matr, int n)
        {
            int max = Int32.MinValue, i = 0, j = 0;
            do
            {
                for (i = 0; i < n; i++)
                {
                    for ( j = n - i - 1; j >0; j--)
                    {
                        if (matr[i, j] > max)
                            max = matr[i, j];
                    }
                }
            } while (i + j < n);
            Console.WriteLine(max);
        }

       
        static void Main(string[] args)
        {
            int n = 0, choice = 0;
            Console.Write("Введите размерность матрицы: ");
            n = Input();

            while (n < 2)
            {
                Console.WriteLine("Ошибка ввода! Повторите попытку");
                n = Input();
            }
            int[,] matr = new int[n, n];
            Console.WriteLine("Выберите как заполнить массив, где 1 - Вручную, 2 - Автоматически");
            do
            {
                choice = Input();
                if (choice <= 0 || choice > 2)
                    Console.WriteLine("Ошибка! Введите число в диапазоне от 1 до 2");
            } while (choice <= 0 || choice > 2);

            if (choice == 1)
            {
                UserWrite(ref matr, n);
                Print(matr,  n);
            }
            else
            {
                Write(ref matr, n);
                Print(matr,  n);
            }          
            SearchMax(matr, n);
       
            Console.ReadKey();

        }
    }
}
