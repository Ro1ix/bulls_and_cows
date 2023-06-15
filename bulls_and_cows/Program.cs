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
            Console.Title = "Игра на логигу: Быки и коровы";
            string choise = "";
            Random rand = new Random();
            string input;
            int bulls;
            int cows;
            int size = 0;
            bool error = false;
            int moves = 0;
            switch (choise)
            {
                default:
                    Console.Clear();
                    Console.WriteLine("\n\t      БЫКИ И КОРОВЫ\n");
                    Console.WriteLine("\tВведите цифру для выбора\n");
                    Console.WriteLine("\t------------------------");
                    Console.WriteLine("\t|    1. Начать игру    |");
                    Console.WriteLine("\t------------------------");
                    Console.WriteLine("\t|  2. Совместная игра  |");
                    Console.WriteLine("\t------------------------");
                    Console.WriteLine("\t|      3. Правила      |");
                    Console.WriteLine("\t------------------------");
                    Console.WriteLine("\t|     Другое. Выйти    |");
                    Console.WriteLine("\t------------------------\n");
                    Console.Write("Выбор: ");
                    choise = Console.ReadLine();
                    if (choise == "1")
                        goto case "1";
                    else if (choise == "2")
                        goto case "2";
                    else if (choise == "3")
                        goto case "3";
                    else Environment.Exit(0);
                    break;
                case "1":
                    error = false;
                    bulls = 0;
                    cows = 0;
                    moves = 0;
                    Console.Clear();
                    Console.WriteLine("* напишите 0, если хотите вернуться в меню *\n");
                    Console.WriteLine("Выберите сложность. Введите размер числа (от 2 до 10)");
                    input = Console.ReadLine();
                    if (input == "0")
                        goto default;
                    switch (input)
                    {
                        case "2": size = 2; break;
                        case "3": size = 3; break;
                        case "4": size = 4; break;
                        case "5": size = 5; break;
                        case "6": size = 6; break;
                        case "7": size = 7; break;
                        case "8": size = 8; break;
                        case "9": size = 9; break;
                        case "10": size = 10; break;
                        default:
                            Console.WriteLine("ОШИБКА! Нажмите любую клавишу и попробуйте ещё раз");
                            Console.ReadKey();
                            error = true;
                            break;
                    }
                    if (error == true)
                        goto case "1";
                    int[] array = new int[size];
                    int[] answer = new int[size];
                    for (int i = 0; i < size; i++)
                    {
                        array[i] = rand.Next(0, 10);
                    }
                    for (int i = 1; i < array.Length; i++)
                    {
                        for (int j = 0; j < array.Length; j++)
                        {
                            if (i == j)
                                continue;
                            if (array[i] == array[j])
                            {
                                array[i] = rand.Next(0, 10);
                                i = 0;
                                j = -1;
                            }
                        }
                    }


                    //Console.WriteLine();
                    //for (int i = 0; i < array.Length; i++)
                    //{
                    //    Console.Write(array[i]);
                    //}
                    //Console.WriteLine("\t (Число выводится для тестирования. В конечном варианте оно будет скрыто от игрока)");


                    Console.WriteLine("\nКомпьютер загадал число");
                    while (bulls < size)
                    {
                        error = false;
                        Console.Write("\nВаш ответ: ");
                        input = Console.ReadLine();
                        if (input == "0")
                            goto default;
                        if (input.Length > array.Length)
                        {
                            Console.WriteLine($"ОШИБКА! Слишком много цифр. Должно быть {size}! Попробуйте ещё раз");
                            continue;
                        }
                        if (input.Length < array.Length)
                        {
                            Console.WriteLine($"ОШИБКА! Слишком мало цифр. Должно быть {size}! Попробуйте ещё раз");
                            continue;
                        }
                        for (int i = 0; i < answer.Length; i++)
                        {
                            switch (input[i])
                            {
                                case '0':
                                    answer[i] = 0;
                                    break;
                                case '1':
                                    answer[i] = 1;
                                    break;
                                case '2':
                                    answer[i] = 2;
                                    break;
                                case '3':
                                    answer[i] = 3;
                                    break;
                                case '4':
                                    answer[i] = 4;
                                    break;
                                case '5':
                                    answer[i] = 5;
                                    break;
                                case '6':
                                    answer[i] = 6;
                                    break;
                                case '7':
                                    answer[i] = 7;
                                    break;
                                case '8':
                                    answer[i] = 8;
                                    break;
                                case '9':
                                    answer[i] = 9;
                                    break;
                                default:
                                    Console.WriteLine("ОШИБКА! Попробуйте ещё раз");
                                    error = true;
                                    break;
                            }
                            if (error == true)
                                break;
                        }
                        if (error == true)
                            continue;
                        for (int i = 1; i < answer.Length; i++)
                        {
                            for (int j = 0; j < answer.Length; j++)
                            {
                                if (i == j)
                                    continue;
                                if (answer[i] == answer[j])
                                {
                                    Console.WriteLine("ОШИБКА! Цифры не должны повторяться. Попробуйте ещё рвз");
                                    error = true;
                                    break;
                                }
                            }
                            if (error == true)
                                break;
                        }
                        if (error == true)
                            continue;
                        bulls = 0;
                        cows = 0;
                        for (int i = 0; i < answer.Length; i++)
                        {
                            if (answer[i] == array[i])
                                bulls++;
                        }
                        for (int i = 0; i < answer.Length; i++)
                        {
                            for (int j = 0; j < answer.Length; j++)
                            {
                                if (i == j)
                                    continue;
                                if (answer[i] == array[j])
                                {
                                    cows++;
                                }
                            }
                        }
                        Console.WriteLine($"Быки: {bulls}   Коровы: {cows}");
                        moves++;
                    }
                    Console.WriteLine("\nВы отгадали число! Поздравляем :)");
                    Console.Write("\nВы затратили на это ");
                    if ((moves % 10 == 1) & (moves % 100 != 11))
                        Console.WriteLine($"{moves} ход");
                    else if ((moves % 10 >= 2) & (moves % 10 <= 4) & 
                        (moves % 100 != 12) & (moves % 100 != 13) & (moves % 100 != 14))
                        Console.WriteLine($"{moves} хода");
                    else Console.WriteLine($"{moves} ходов");
                    Console.WriteLine("\n\t------------------------");
                    Console.WriteLine("\t|    1. Сыграть ещё    |");
                    Console.WriteLine("\t------------------------");
                    Console.WriteLine("\t|  2. Вернуться в меню |");
                    Console.WriteLine("\t------------------------");
                    Console.WriteLine("\t|     Другое. Выйти    |");
                    Console.WriteLine("\t------------------------\n");
                    Console.Write("Выбор: ");
                    choise = Console.ReadLine();
                    if (choise == "1")
                        goto case "1";
                    else if (choise == "2")
                        goto default;
                    else Environment.Exit(0);
                    break;
                case "2":
                    error = false;
                    moves = 0;
                    bulls = 0;
                    cows = 0;
                    Console.Clear();
                    Console.WriteLine("* напишите 0, если хотите вернуться в меню *\n");
                    Console.WriteLine("\tСОВМЕСТНАЯ ИГРА\n");
                    Console.WriteLine("Выберите сложность. Введите размер числа (от 2 до 10)");
                    input = Console.ReadLine();
                    if (input == "0")
                        goto default;
                    switch (input)
                    {
                        case "2": size = 2; break;
                        case "3": size = 3; break;
                        case "4": size = 4; break;
                        case "5": size = 5; break;
                        case "6": size = 6; break;
                        case "7": size = 7; break;
                        case "8": size = 8; break;
                        case "9": size = 9; break;
                        case "10": size = 10; break;
                        default:
                            Console.WriteLine("ОШИБКА! Нажмите любую клавишу и попробуйте ещё раз");
                            Console.ReadKey();
                            error = true;
                            break;
                    }
                    if (error == true)
                        goto case "2";
                    array = new int[size];
                    answer = new int[size];
                    array[size - 1] = -1;
                    while (array[size - 1] == -1)
                    {
                        error = false;
                        Console.Write("\nЗагадайте число: ");
                        input = Console.ReadLine();
                        if (input == "0")
                            goto default;
                        if (input.Length > array.Length)
                        {
                            Console.WriteLine($"ОШИБКА! Слишком много цифр. Должно быть {size}! Попробуйте ещё раз");
                            continue;
                        }
                        if (input.Length < array.Length)
                        {
                            Console.WriteLine($"ОШИБКА! Слишком мало цифр. Должно быть {size}! Попробуйте ещё раз");
                            continue;
                        }
                        for (int i = 0; i < array.Length; i++)
                        {
                            switch (input[i])
                            {
                                case '0':
                                    array[i] = 0;
                                    break;
                                case '1':
                                    array[i] = 1;
                                    break;
                                case '2':
                                    array[i] = 2;
                                    break;
                                case '3':
                                    array[i] = 3;
                                    break;
                                case '4':
                                    array[i] = 4;
                                    break;
                                case '5':
                                    array[i] = 5;
                                    break;
                                case '6':
                                    array[i] = 6;
                                    break;
                                case '7':
                                    array[i] = 7;
                                    break;
                                case '8':
                                    array[i] = 8;
                                    break;
                                case '9':
                                    array[i] = 9;
                                    break;
                                default:
                                    Console.WriteLine("ОШИБКА! Попробуйте ещё раз");
                                    error = true;
                                    break;
                            }
                            if (error == true)
                                break;
                        }
                        if (error == true)
                            continue;
                        for (int i = 1; i < array.Length; i++)
                        {
                            for (int j = 0; j < array.Length; j++)
                            {
                                if (i == j)
                                    continue;
                                if (array[i] == array[j])
                                {
                                    Console.WriteLine("ОШИБКА! Цифры не должны повторяться. Попробуйте ещё рвз");
                                    array[size - 1] = -1;
                                    error = true;
                                    break;
                                }
                            }
                            if (error == true)
                                break;
                        }
                        if (error == true)
                            continue;
                    }
                    Console.Write("\nНажмите любую клавишу, когда игрок будет готов отгадывать...");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("* напишите 0, если хотите вернуться в меню *\n");
                    Console.WriteLine("\tСОВМЕСТНАЯ ИГРА\n");
                    Console.WriteLine($"Сложность: {size}");
                    while (bulls < size)
                    {
                        error = false;
                        Console.Write("\nВаш ответ: ");
                        input = Console.ReadLine();
                        if (input == "0")
                            goto default;
                        if (input.Length > array.Length)
                        {
                            Console.WriteLine($"ОШИБКА! Слишком много цифр. Должно быть {size}! Попробуйте ещё раз");
                            continue;
                        }
                        if (input.Length < array.Length)
                        {
                            Console.WriteLine($"ОШИБКА! Слишком мало цифр. Должно быть {size}! Попробуйте ещё раз");
                            continue;
                        }
                        for (int i = 0; i < answer.Length; i++)
                        {
                            switch (input[i])
                            {
                                case '0':
                                    answer[i] = 0;
                                    break;
                                case '1':
                                    answer[i] = 1;
                                    break;
                                case '2':
                                    answer[i] = 2;
                                    break;
                                case '3':
                                    answer[i] = 3;
                                    break;
                                case '4':
                                    answer[i] = 4;
                                    break;
                                case '5':
                                    answer[i] = 5;
                                    break;
                                case '6':
                                    answer[i] = 6;
                                    break;
                                case '7':
                                    answer[i] = 7;
                                    break;
                                case '8':
                                    answer[i] = 8;
                                    break;
                                case '9':
                                    answer[i] = 9;
                                    break;
                                default:
                                    Console.WriteLine("ОШИБКА! Попробуйте ещё раз");
                                    error = true;
                                    break;
                            }
                            if (error == true)
                                break;
                        }
                        if (error == true)
                            continue;
                        for (int i = 1; i < answer.Length; i++)
                        {
                            for (int j = 0; j < answer.Length; j++)
                            {
                                if (i == j)
                                    continue;
                                if (answer[i] == answer[j])
                                {
                                    Console.WriteLine("ОШИБКА! Цифры не должны повторяться. Попробуйте ещё раз");
                                    error = true;
                                    break;
                                }
                            }
                            if (error == true)
                                break;
                        }
                        if (error == true)
                            continue;
                        bulls = 0;
                        cows = 0;
                        for (int i = 0; i < answer.Length; i++)
                        {
                            if (answer[i] == array[i])
                                bulls++;
                        }
                        for (int i = 0; i < answer.Length; i++)
                        {
                            for (int j = 0; j < answer.Length; j++)
                            {
                                if (i == j)
                                    continue;
                                if (answer[i] == array[j])
                                {
                                    cows++;
                                }
                            }
                        }
                        Console.WriteLine($"Быки: {bulls}   Коровы: {cows}");
                        moves++;
                    }
                    Console.WriteLine("\nВы отгадали число! Поздравляем :)");
                    Console.Write("\nВы затратили на это ");
                    if ((moves % 10 == 1) & (moves % 100 != 11))
                        Console.WriteLine($"{moves} ход");
                    else if ((moves % 10 >= 2) & (moves % 10 <= 4) &
                        (moves % 100 != 12) & (moves % 100 != 13) & (moves % 100 != 14))
                        Console.WriteLine($"{moves} хода");
                    else Console.WriteLine($"{moves} ходов");
                    Console.WriteLine("\n\t------------------------");
                    Console.WriteLine("\t|    1. Сыграть ещё    |");
                    Console.WriteLine("\t------------------------");
                    Console.WriteLine("\t|  2. Вернуться в меню |");
                    Console.WriteLine("\t------------------------");
                    Console.WriteLine("\t|     Другое. Выйти    |");
                    Console.WriteLine("\t------------------------\n");
                    Console.Write("Выбор: ");
                    choise = Console.ReadLine();
                    if (choise == "1")
                        goto case "2";
                    else if (choise == "2")
                        goto default;
                    else Environment.Exit(0);
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("\n\t   ПРАВИЛА ИГРЫ\n");
                    Console.WriteLine("Компьютер задумывает различные");
                    Console.WriteLine("цифры от 0 до 9. Игрок делает ходы,");
                    Console.WriteLine("чтобы узнать эти цифры и их порядок.\n");
                    Console.WriteLine("Каждый ход состоит из набора цифр, 0");
                    Console.WriteLine("может стоять на первом месте.\n");
                    Console.WriteLine("В ответ компьютер показывает число");
                    Console.WriteLine("отгаданных цифр, стоящих на своих");
                    Console.WriteLine("местах (число быков) и число отгаданных");
                    Console.WriteLine("цифр, стоящих не на своих местах (число коров).\n");
                    Console.WriteLine("\t      ПРИМЕР\n");
                    Console.WriteLine("Компьютер задумал 0834.\n");
                    Console.WriteLine("Игрок сделал ход 8134.\n");
                    Console.WriteLine("Компьютер ответил: 2 быка (цифры 3 и 4) и");
                    Console.WriteLine("1 корова (цифра 8).");
                    Console.WriteLine("\n\n\n     ПРАВИЛА ДЛЯ СОВМЕСТНОЙ ИГРЫ\n");
                    Console.WriteLine("Правила те же, за исключением того,");
                    Console.WriteLine("что один из игроков сам загадывает");
                    Console.WriteLine("число, которое должен отгадать второй.");
                    Console.Write("\n\n\nНажмите на любую клавишу, чтобы вернуться в меню...");
                    Console.ReadKey();
                    goto default;
            }
        }
    }
}