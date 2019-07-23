using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    class Program
    {
        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // Введення чисел
            Console.WriteLine("Введіть цілі числа:\n");

            // перевірка правильності вводу
            bool error = true;

#if false   // на рівні пройденого
            // індентифікатори
            int a0 = default,
                a1 = default,
                a2 = default;

            if (error)
            {
                // 1-е число
                Console.Write("\ta1 = ");
                error = int.TryParse(Console.ReadLine(), out a0);
                // аналіз чи можна далі продовжувати 
                AnaliseOfInputNumber(error);
            }

            // 2-е число
            if (error)
            {
                Console.Write("\ta2 = ");
                error = int.TryParse(Console.ReadLine(), out a1);
                // аналіз чи можна далі продовжувати 
                AnaliseOfInputNumber(error);
            }

            // 3-є число
            if (error)
            {
                Console.Write("\ta3 = ");
                error = int.TryParse(Console.ReadLine(), out a2);
                // аналіз чи можна далі продовжувати 
                AnaliseOfInputNumber(error);
            }

            // розразунок середньго арифметичного AM
            if (error)
            {
                error = true;
                Console.WriteLine($"\nСереднє арифметичне: {CalculateAM(a0, a1, a2):N2}");
            }
#endif

#if false   // використання масивів
            // масив для введених даних
            int[] a = new int[3];

            // перевірка правильності вводу
            bool error = true;

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

            // розразунок середньго арифметичного AM
            if (error)
            {
                TryCalculateAM(out double am, a);
                Console.WriteLine($"\nСереднє арифметичне: {am:N2}");
            }
#endif

#if true    // використання колекцій
            // масив для введених даних
            List<int> a = new List<int>();

            // введення 3-х даних
            for (int i = 0; i < 3; i++)
            {
                if (error)
                {
                    Console.Write($"\ta{i} = ");
                    error = int.TryParse(Console.ReadLine(), out int temp);
                    // аналіз чи можна далі продовжувати 
                    AnaliseOfInputNumber(error);
                    // додаємо в колекцію
                    a.Add(temp);
                }
            }

            if (error)
            {
                // розразунок середньго арифметичного AM
                TryCalculateAM(out double am, a.ToArray());
                // але можна і зразу скористатися можливостями колекцій
                Console.WriteLine($"\nСереднє арифметичне: {a.Average():N2}");
            }
#endif

            // повторення
            if (error)
            {
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
        /// Розрахунок середнього арифметичного
        /// </summary>
        /// <param name="a0"></param>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        /// <returns></returns>
        static double CalculateAM(int a0, int a1, int a2)
        {
            return (a0 + a1 + a2) / 3.0;
        }

        /// <summary>
        /// Предікат розрахунку середнього арифметичного
        /// </summary>
        /// <returns></returns>
        static bool TryCalculateAM(out double am, params int[] data)
        {
            // результат розрахунку, аналіз чи є вхідні дані
            bool resExit;
            // сума всіх вхідних аргументів
            int sum = 0;

            if (data.Length < 1)
            {
                resExit = false;
                am = double.NaN;
            }
            else
            {
                resExit = true;

                // розрахунок суми
                for (int i = 0; i < data.Length; i++)
                {
                    sum += data[i];
                }

                // розрахунок середнього арифметичного
                am = (double)sum / data.Length;
            }

            return resExit;
        }

    }
}
