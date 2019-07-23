using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp2
{
    class Program
    {
        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // перевірка правильності вводу
            bool error = true;

            // індентифікатори
            double money = default,
                exchenge = default;

            if (error)
            {
                // Введення даних
                Console.Write("\tВведіть свої кошти: ");
                error = double.TryParse(Console.ReadLine().Replace(".", ","), out money);
                // аналіз чи можна далі продовжувати 
                AnaliseOfInputNumber(error);
            }

            if (error)
            {
                Console.Write("\n\tВведіть курс валют: ");
                error = double.TryParse(Console.ReadLine().Replace(".", ","), out exchenge);
                // аналіз чи можна далі продовжувати 
                AnaliseOfInputNumber(error);
            }

            if (error)
            {
                // результат
                ConvertValute(money, exchenge);
                //Console.WriteLine($"\n\tКонвертована валюта: {money * exchenge:N2}");
            }


            if (error)
            {
                // повторення
                DoExitOrRepeat();
            }
        }

        /// <summary>
        /// Конвертація валюти
        /// </summary>
        /// <param name="money"></param>
        /// <param name="exchenge"></param>
        static void ConvertValute(double money, double exchenge)
        {
            Console.WriteLine($"\n\tКонвертована валюта: {money * exchenge:N2}");
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
