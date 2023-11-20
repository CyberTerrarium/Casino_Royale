using System.Collections.ObjectModel;

int[,] CreateRulette()
{
    int[,] rulette = new int[2, 37];
    for (int i = 0; i < rulette.GetLength(0); i++)
    {
        for (int j = 0; j < rulette.GetLength(1); j++)
        {
            if (i == 0)
            {
                rulette[i, j] = j;
            }
            else
            {
                if (j == 0) continue;
                if (j % 2 == 0)
                {
                    rulette[i, j] = 1;
                }
                else
                {
                    rulette[i, j] = 2;
                }

            }
        }
    }
    return rulette;
}


int[] startgame(int[,] rulette)
{
    int[] result = new int[2];
    int random = new Random().Next(0, 37);
    result[0] = rulette[0, random];
    result[1] = rulette[1, random];
    return result;
}

void PrintResult(int[] result)
{
    string color;
    if (result[1] == 1)
    {
        color = "Krasnoe";
    }
    else if (result[1] == 2)
    {
        color = "Chernoe";
    }
    else
    {
        color = "Zero";
    }
    System.Console.WriteLine($"Выпало число {result[0]} {color}");
}

int isWinner(int usernum, int[] result)
{
    if (usernum == result[0])
    {
        System.Console.WriteLine("winner winner chicken dinner!");
        return 36;
    }
    else if (usernum - 36 == result[1])
    {
        System.Console.WriteLine("Ставка на цвет сыграла!");
        return 2;
    }
    else
    {
        System.Console.WriteLine("Ваша ставка не сыграла!Ставка уходит казино!");
        return -1;
    }
}

int updateCredit(int isWinner, int stavka, int userCredit)
{
    int result = userCredit + stavka * isWinner;
    System.Console.WriteLine(stavka * isWinner);
    System.Console.WriteLine($"Ваш текущий депозит {result}");
    return result;
}

int[] makeBet()
{
    int userChoice = 0;
    int userBet = 0;
    int bet = 0;
    int[] result = new int[2];

    while (bet < 50)
    {
        System.Console.WriteLine("Введите вашу ставку. Минимальная ставка 50.");
        bet = Convert.ToInt32(Console.ReadLine());
    }
    while (userChoice < 1 || userChoice > 2)
    {
        System.Console.WriteLine($"Нажмите 1, если хотите поставить на число!");
        System.Console.WriteLine($"Нажмите 2, если хотите поставить на цвет!");
        userChoice = Convert.ToInt32(Console.ReadLine());
    }
    if (userChoice == 1)
    {
        while (userBet < 1 || userBet > 36)
        {
            System.Console.WriteLine("Поставьте на число от 1 до 36!");
            userBet = Convert.ToInt32(System.Console.ReadLine());
        }
    }
    else if (userChoice == 2)
    {
        while (userBet < 1 || userBet > 2)
        {
            System.Console.WriteLine("Введите 1, чтобы поставить на красное.");
            System.Console.WriteLine("Введите 2, чтобы поставить на черное.");
            userBet = Convert.ToInt32(System.Console.ReadLine());
        }
    }
    result[0] = userBet;
    result[1] = bet;
    return result;
}

bool checkBalance(int userDeposit)
{
    if (userDeposit < 50)
    {
        System.Console.WriteLine("Недостаточно средств. Пополните баланс!");
        return false;
    }
    else
    {
        return true;
    }
}
int userDeposit = 1000;
int[] userBet = new int[2];
System.Console.WriteLine($"Ваш депозит {userDeposit}");
while (checkBalance(userDeposit))
{
    userBet = makeBet();
    int[,] rulette = CreateRulette();
    int[] resultGame = startgame(rulette);
    PrintResult(resultGame);
    int koefficient = isWinner(userBet[0], resultGame);
    userDeposit = updateCredit(koefficient, userBet[1], userDeposit);
}
System.Console.WriteLine("Вы проиграли! АуфидерзейнЁ!");