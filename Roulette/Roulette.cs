using Microsoft.VisualBasic;

public class Roulette
{
    private const int numberOfOut = -999999;


    /// <summary>
    /// Читает файл txt в директори программы и конвертирует с многомерный массив чар
    /// </summary>
    /// <returns>Возвращает многомерныймассив символов</returns>
    public static char[,] ReadFileTXTAndConvertToChar(string[] interfaceStringArray)
    {

        // string[] interfaceStringArray = File.ReadAllLines(@"RouletteInterface.txt");
        char[,] interfaceCharArray = new char[interfaceStringArray.Length, interfaceStringArray[0].ToString().Length];

        int rowIndex = 0, columnIndex;
        foreach (var name in interfaceStringArray)
        {
            columnIndex = 0;
            char[] charName = name.ToCharArray();
            for (int i = 0; i < charName.Length; i++)
            {
                interfaceCharArray[rowIndex, columnIndex] = charName[i];
                columnIndex++;
            }
            rowIndex++;
        }
        return interfaceCharArray;
    }

    /// <summary>
    /// Этот метод выводит string в заданных координатах
    /// </summary>
    /// <param name="text">Передаваемый текст</param>
    /// <param name="coordinateX">Координата Х или номер столбца</param>
    /// <param name="coordinateY">Координата Y или номер строки</param>
    /// <param name="requiredNumber">Число в строке после string в формате $"{text}{requiredNumber}"</param>
    public static void PrintTextInPositionOnTerminal(string text, int coordinateX = 0, int coordinateY = 0, int requiredNumber = numberOfOut)
    {
        System.Console.SetCursorPosition(coordinateX, coordinateY);
        if (requiredNumber == numberOfOut)
        {
            System.Console.WriteLine($"{text}");
        }
        else
        {
            System.Console.WriteLine($"{text}{requiredNumber}");
        }
    }

    /// <summary>
    /// Печатает одномерный массив строк в консоли по строчно
    /// </summary>
    /// <param name="interfaceStringArray">Одномерный массив строк</param>
    /// <param name="coordinateX">Координата печати X, по умолчанию 0</param>
    /// <param name="coordinateY">Координата печати Y, по умолчанию 0</param>
    public static void PrintFilePlayingField(string[] interfaceStringArray, int coordinateX = 0, int coordinateY = 0)
    {
        System.Console.SetCursorPosition(coordinateX, coordinateY);
        for (int i = 0; i < interfaceStringArray.Length; i++)
        {
            System.Console.WriteLine(interfaceStringArray[i]);
        }
    }

    /// <summary>
    /// Выводит в консоль интерфейс
    /// </summary>
    /// <param name="interfaceCharArray">Принимает многомерный массив символов</param>
    public static void PrintInterfaсeRoulette(string[] filePlayingField, int userDeposit, int userBid)
    {
        char[,] interfaceCharArray = ReadFileTXTAndConvertToChar(filePlayingField);
        int userPositionX = 2, userPositionY = 2;
        System.Console.WriteLine("Нажмите пробел для старта: ");
        ConsoleKeyInfo charKeyOutGame = Console.ReadKey(); //Тут надо исправить
        while (charKeyOutGame.Key != ConsoleKey.Escape)
        {
            PrintTextInPositionOnTerminal("Ваш текущий депозит: ", interfaceCharArray.GetLength(1) + 2, 0, userDeposit);
            PrintTextInPositionOnTerminal("Нажмите Esc для выхода из игры", 0, interfaceCharArray.GetLength(0) + 2);
            PrintFilePlayingField(filePlayingField, 0, 0);
            PrintTextInPositionOnTerminal("@", userPositionY, userPositionX);
            ConsoleKeyInfo charKey = Console.ReadKey();
            switch (charKey.Key)
            {
                case ConsoleKey.UpArrow:
                    if (interfaceCharArray[userPositionX - 1, userPositionY] != '#')
                    {
                        userPositionX--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (interfaceCharArray[userPositionX + 1, userPositionY] != '#')
                    {
                        userPositionX++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (interfaceCharArray[userPositionX, userPositionY - 1] != '#')
                    {
                        userPositionY--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (interfaceCharArray[userPositionX, userPositionY + 1] != '#')
                    {
                        userPositionY++;
                    }
                    break;
            }

            charKeyOutGame = charKey;
            Console.Clear();
        }
    }
}
