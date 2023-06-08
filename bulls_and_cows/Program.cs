using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bulls_and_cows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Быки и коровы";
            Console.WriteLine("Введите цифру для выбора\n");
            Console.WriteLine("\t------------------------");
            Console.WriteLine("\t|    1. Начать игру    |");
            Console.WriteLine("\t------------------------");
            Console.WriteLine("\t|      2. Правила      |");
            Console.WriteLine("\t------------------------\n");
            Console.Write("Выбор: ");
            string choise = Console.ReadLine();
            int[] array = new int[4];
            Random rand = new Random();
            if (choise != "1" & choise != "2")
            {
                Console.WriteLine("ОШИБКА! Нажмите любую клавишу и попробуйте ещё раз");
                Console.ReadKey();
            }
            switch (choise)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("* нажмите на Esc, если хотите вернуться в меню *\n");
                    array[0] = rand.Next(0, 10);
                    switch (array[0])
                    {
                        case 0:
                            array[1] = rand.Next(1, 10);
                            break;
                        case 1:

                            break;
                        case 2:

                            break;
                        case 3:

                            break;
                        case 4:

                            break;
                        case 5:

                            break;
                        case 6:

                            break;
                        case 7:

                            break;
                        case 8:

                            break;
                        case 9:

                            break;
                    }
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("\t\tПРАВИЛА ИГРЫ\n");
                    Console.WriteLine("Компьютер задумывает четыре различные");
                    Console.WriteLine("цифры от 0 до 9. Игрок делает ходы,");
                    Console.WriteLine("чтобы узнать эти цифры и их порядок.\n");
                    Console.WriteLine("Каждый ход состоит из четырёх цифр, 0");
                    Console.WriteLine("может стоять на первом месте.\n");
                    Console.WriteLine("В ответ компьютер показывает число");
                    Console.WriteLine("отгаданных цифр, стоящих на своих");
                    Console.WriteLine("местах (число быков) и число отгаданных");
                    Console.WriteLine("цифр, стоящих не на своих местах (число коров).\n");
                    Console.WriteLine("\t\t   ПРИМЕР\n");
                    Console.WriteLine("Компьютер задумал 0834.\n");
                    Console.WriteLine("Игрок сделал ход 8134.\n");
                    Console.WriteLine("Компьютер ответил: 2 быка (цифры 3 и 4) и");
                    Console.WriteLine("1 корова (цифра 8).");
                    Console.WriteLine("\n\n\nНажмите на любую клавишу, чтобы вернуться в меню...");
                    Console.ReadKey();
                    goto default;
                default:
                    Console.Clear();
                    Console.WriteLine("Введите цифру для выбора\n");
                    Console.WriteLine("\t------------------------");
                    Console.WriteLine("\t|    1. Начать игру    |");
                    Console.WriteLine("\t------------------------");
                    Console.WriteLine("\t|      2. Правила      |");
                    Console.WriteLine("\t------------------------\n");
                    Console.Write("Выбор: ");
                    choise = Console.ReadLine();
                    if (choise == "1")
                        goto case "1";
                    else if (choise == "2")
                        goto case "2";
                    else
                    {
                        Console.WriteLine("ОШИБКА! Нажмите любую клавишу и попробуйте ещё раз");
                        Console.ReadKey();
                        goto default;
                    }
            }
        }
    }
}
