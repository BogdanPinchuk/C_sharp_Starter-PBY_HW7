using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1
{
    class Program
    {
        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // Введення чисел
            Console.WriteLine("Введіть числа:\n");

            // перевірка правильності вводу
            bool error = true;

            // масив для введених даних
            int[] a = new int[2];

            // введення даних
            for (int i = 0; i < a.Length; i++)
            {
                if (error)
                {
                    Console.Write($"\ta{i} = ");
                    error = int.TryParse(Console.ReadLine(), out a[i]);
                    // аналіз чи можна далі продовжувати 
                    AnaliseOfInputNumber(error);
                }
            }

            if (error)
            {
                // обрання операції розрахунку
                Console.WriteLine("\n\tОберіть операцію розрахунку: +, -, *,  /\n\t");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Add:
                        DoAdd(a[0], a[1]);
                        break;
                    case ConsoleKey.Subtract:
                        DoSub(a[0], a[1]);
                        break;
                    case ConsoleKey.Multiply:
                        DoMul(a[0], a[1]);
                        break;
                    case ConsoleKey.Divide:
                        DoDiv(a[0], a[1]);
                        break;
                    default:
                        Console.WriteLine("\n\tНевірно введена операція!");
                        break;
                }
            }

            if (error)
            {
                // повторення
                DoExitOrRepeat();
            }
        }

        // процедури
        /// <summary>
        /// Сума чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static void DoAdd(int a, int b)
        {
            Console.WriteLine($"\n\tРезультат: {a:N0} + {b:N0} = {a + b:N0};\n");
        }

        /// <summary>
        /// Різниця чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static void DoSub(int a, int b)
        {
            Console.WriteLine($"\n\tРезультат: {a:N0} - {b:N0} = {a - b:N0};\n");
        }

        /// <summary>
        /// Добуток чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static void DoMul(int a, int b)
        {
            Console.WriteLine($"\n\tРезультат: {a:N0} * {b:N0} = {a * b:N0};\n");
        }

        /// <summary>
        /// Частка чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static void DoDiv(int a, int b)
        {
            // перевірка на 0
            double temp = default;

            if (a == 0 && b == 0)
            {
                temp = double.NaN;
            }
            else if (a > 0 && b == 0)
            {
                temp = double.PositiveInfinity;
            }
            else if (a < 0 && b == 0)
            {
                temp = double.NegativeInfinity;
            }
            else
            {
                temp = (double)a / b;
            }

            // вивід
            Console.WriteLine($"\n\tРезультат: {a:N0} / {b:N0} = {temp:N2};\n");
        }

        /// <summary>
        /// Умова коли невірно введені дані
        /// </summary>
        /// <param name="res"></param>
        static void AnaliseOfInputNumber(bool res)
        {
            if (!res)
            {
                Console.WriteLine("\nНевірно введені дані!");
                DoExitOrRepeat();
            }
        }

        /// <summary>
        /// Метод виходу або повторення методу Main()
        /// </summary>
        static void DoExitOrRepeat()
        {
            Console.WriteLine("\nСпробувати ще раз: [т, н]");
            Console.Write("\t");
            var button = Console.ReadKey(true);

            if ((button.KeyChar.ToString().ToLower() == "т") ||
                (button.KeyChar.ToString().ToLower() == "n")) // можливо забули переключити розкладку клавіатури
            {
                Console.Clear();
                Main();
            }
        }
    }
}
