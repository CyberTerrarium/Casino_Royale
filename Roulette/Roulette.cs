using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using Microsoft.VisualBasic;
using System.IO;

public class Roulette
{
    private const int numberOfOut = -999999;


    private static int GetMaxLengthOfLine(string[] lines)
    {
        int maxLength = lines[0].Length;
        foreach (var line in lines)
            if (line.Length > maxLength)
                maxLength = line.Length;
        return maxLength;
    }

    /// <summary>
    /// Читает файл txt в директори программы и конвертирует с многомерный массив чар
    /// </summary>
    /// <returns>Возвращает многомерныймассив символов</returns>
    public static char[,] ReadFileTXTAndConvertToChar(string[] interfaceStringArray)
    {
        char[,] interfaceCharArray = new char[GetMaxLengthOfLine(interfaceStringArray), interfaceStringArray.Length];
        for (int x = 0; x < interfaceCharArray.GetLength(0); x++)
            for (int y = 0; y < interfaceCharArray.GetLength(1); y++)
                interfaceCharArray[x, y] = interfaceStringArray[y][x];
        return interfaceCharArray;
    }

    /// <summary>
    /// Этот метод выводит string в заданных координатах
    /// </summary>
    /// <param name="text">Передаваемый текст</param>
    /// <param name="coordinateX">Координата Х или номер столбца</param>
    /// <param name="coordinateY">Координата Y или номер строки</param>
    /// <param name="requiredNumber">Число в строке после string в формате $"{text}{requiredNumber}"</param>
    public static void PrintTextInPositionOnTerminal(string text,
                                            int coordinateX = 0, int coordinateY = 0,
                                            int requiredNumber = numberOfOut,
                                            ConsoleColor newForegroundColor = ConsoleColor.White,
                                            ConsoleColor newBackgroundColor = ConsoleColor.Black)
    {
        ConsoleColor defautForegroundColor = Console.ForegroundColor;
        ConsoleColor defautBackgroundColor = Console.BackgroundColor;
        Console.ForegroundColor = newForegroundColor;
        Console.BackgroundColor = newBackgroundColor;
        System.Console.SetCursorPosition(coordinateX, coordinateY);
        if (requiredNumber == numberOfOut) System.Console.WriteLine($"{text}");
        else System.Console.WriteLine($"{text}{requiredNumber}");

        Console.ForegroundColor = defautForegroundColor;
        Console.BackgroundColor = defautBackgroundColor;
    }

    /// <summary>
    /// Печатает одномерный массив строк в консоли по строчно
    /// </summary>
    /// <param name="interfaceStringArray">Одномерный массив строк</param>
    /// <param name="coordinateX">Координата печати X, по умолчанию 0</param>
    /// <param name="coordinateY">Координата печати Y, по умолчанию 0</param>
    public static void PrintFilePlayingField(string[] interfaceStringArray,
                                            int coordinateX = 0, int coordinateY = 0,
                                            ConsoleColor newForegroundColor = ConsoleColor.White,
                                            ConsoleColor newBackgroundColor = ConsoleColor.Black)
    {
        ConsoleColor defautForegroundColor = Console.ForegroundColor;
        ConsoleColor defautBackgroundColor = Console.BackgroundColor;
        Console.ForegroundColor = newForegroundColor;
        Console.BackgroundColor = newBackgroundColor;
        System.Console.SetCursorPosition(coordinateX, coordinateY);
        for (int i = 0; i < interfaceStringArray.Length; i++)
        {
            System.Console.WriteLine(interfaceStringArray[i]);
        }
        Console.ForegroundColor = defautForegroundColor;
        Console.BackgroundColor = defautBackgroundColor;
    }

    public static void PrintFilePlayingField(char[,] interfaceCharArray,
                                            int coordinateX = 0, int coordinateY = 0,
                                            ConsoleColor newForegroundColor = ConsoleColor.White,
                                            ConsoleColor newBackgroundColor = ConsoleColor.Black)
    {
        ConsoleColor defautForegroundColor = Console.ForegroundColor;
        ConsoleColor defautBackgroundColor = Console.BackgroundColor;
        Console.ForegroundColor = newForegroundColor;
        Console.BackgroundColor = newBackgroundColor;
        System.Console.SetCursorPosition(coordinateX, coordinateY);
        for (int y = 0; y < interfaceCharArray.GetLength(1); y++)
        {
            for (int x = 0; x < interfaceCharArray.GetLength(0); x++)
            {
                System.Console.Write(interfaceCharArray[x,y]);
            }
            System.Console.Write("\n");
        }
        Console.ForegroundColor = defautForegroundColor;
        Console.BackgroundColor = defautBackgroundColor;
    }


    /// <summary>
    /// Принимает нажатую клавишу и перемешает игрока по карте с не возможностью выйти за пределы карты
    /// </summary>
    /// <param name="interfaceCharArray">Карта интерфэйса</param>
    /// <param name="userPositionX">позиция по x</param>
    /// <param name="userPositionY">позиция по y</param>
    /// <param name="charKey">какая клавиша нажата</param>
    /// <param name="symbolOfMapBorders">Символ границы карты</param>
    public static void PlayerPositionManagement(ref char[,] interfaceCharArray,
                                                ref int userPositionX, ref int userPositionY,
                                                ref ConsoleKeyInfo charKey,
                                                char symbolOfMapBorders)
    {
        switch (charKey.Key)
        {
            case ConsoleKey.LeftArrow:
                if (interfaceCharArray[userPositionX - 1, userPositionY] != symbolOfMapBorders)
                {
                    userPositionX--;
                }
                break;
            case ConsoleKey.RightArrow:
                if (interfaceCharArray[userPositionX + 1, userPositionY] != symbolOfMapBorders)
                {
                    userPositionX++;
                }
                break;
            case ConsoleKey.UpArrow:
                if (interfaceCharArray[userPositionX, userPositionY - 1] != symbolOfMapBorders)
                {
                    userPositionY--;
                }
                break;
            case ConsoleKey.DownArrow:
                if (interfaceCharArray[userPositionX, userPositionY + 1] != symbolOfMapBorders)
                {
                    userPositionY++;
                }
                break;
        }
    }


    /// <summary>
    /// Выводит в консоль интерфейс
    /// </summary>
    /// <param name="filePlayingField">Графика интерфэйся</param>
    /// <param name="charKeyOutGame">Клавиша с любым значением, если ESC то выход из приложения</param>
    public static void StartGameRoulette(string[] filePlayingField,
                                            ConsoleKeyInfo charKeyOutGame)
    {
        int userDeposit = 100000;
        int userBid;
        // Какой-тоМетод(out параметр = userBid)   Тогда не надо инициализировать userBid
        int userPositionX = 2, userPositionY = 3;

        char[,] interfaceCharArray = ReadFileTXTAndConvertToChar(filePlayingField);
        while (charKeyOutGame.Key != ConsoleKey.Escape)
        {
            PrintTextInPositionOnTerminal("Ваш текущий депозит: ", interfaceCharArray.GetLength(0) + 2, 0, userDeposit);
            PrintTextInPositionOnTerminal("Нажмите Escape для выхода из игры", 0, interfaceCharArray.GetLength(1) + 2);
            PrintFilePlayingField(filePlayingField, 0, 0);
            PrintTextInPositionOnTerminal("@", userPositionX, userPositionY);
            ConsoleKeyInfo charKey = Console.ReadKey();
            if (charKey.Key != ConsoleKey.Enter)
            {
                PlayerPositionManagement(ref interfaceCharArray,
                                            ref userPositionX, ref userPositionY,
                                            ref charKey,
                                            '#');
            }
            else
            {

            }
            charKeyOutGame = charKey;
            Console.Clear();
        }
    }
}
