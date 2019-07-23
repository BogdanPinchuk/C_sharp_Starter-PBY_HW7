using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp3
{
    class Program
    {
        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // Введення даних
            Console.Write("\tВведіть ціле число: ");

            // перевірка правильності вводу
            bool error = true;

            // індентифікатори
            int a = default;

            if (error)
            {
                error = int.TryParse(Console.ReadLine(), out a);
                // аналіз чи можна далі продовжувати 
                AnaliseOfInputNumber(error);
            }

            // аналіз числа
            if (error)
            {
                AnaliseOfNumber(a);
            }

            if (error)
            {
                // повторення
                DoExitOrRepeat();
            }
        }

        /// <summary>
        /// Аналіз числа на знак, парність, простоту, і т.д.
        /// </summary>
        /// <param name="a">Число яка аналізується</param>
        static void AnaliseOfNumber(int a)
        {
            // число позитивне чи негативне
            if (a > 0)
            {
                Console.WriteLine($"\n\t- число позитивне;");
            }
            else if (a < 0)
            {
                Console.WriteLine($"\n\t- число від'ємне;");
            }
            else // a = 0
            {
                Console.WriteLine($"\n\t- число ні позитивне ні від'ємне;");
            }

            // число парне чи непарне
            if (a == 0)
            {
                Console.WriteLine($"\n\t- число ні парне ні непарне;");
            }
            else if (a % 2 == 0)
            {
                Console.WriteLine($"\n\t- число парне;");
            }
            else
            {
                Console.WriteLine($"\n\t- число непарне;");
            }

            // чи є число простим
            if (a == 1 || a == 2 || a == 3)
            {
                Console.WriteLine($"\n\t- число просте;");
            }
            else if (a < 1 || a % 2 == 0)
            {
                Console.WriteLine($"\n\t- число не просте;");
            }
            else
            {
                // число просте true - так, false  - ні
                bool temp = true;

                for (int i = 3; i < a; i += 2)
                {
                    temp = (a % i == 0) ? false : true;
                    if (!temp)
                    {
                        break;
                    }
                }

                if (temp)
                {
                    Console.WriteLine($"\n\t- число просте;");
                }
                else
                {
                    Console.WriteLine($"\n\t- число не просте;");
                }
            }

            // чи дылиться на 2, 5, 3, 6, 9
            {
                int[] temp = new int[] { 2, 3, 5, 6, 9 };

                for (int i = 0; i < temp.Length; i++)
                {
                    if (a % temp[i] == 0)
                    {
                        Console.WriteLine($"\n\t- число ділиться на {temp[i]} без остачі;");
                    }
                }
            }
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
