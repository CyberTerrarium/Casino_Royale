void ShowRules()
{
    Console.WriteLine("\nДобро пожаловать в игру \"Рулетка\"!\nПожалуйста, ознакомьтес с правилами игры:");
    Console.WriteLine("Вы можете поставить как отдельную ставку на выбранное вами число или цвет, так и одновременно и на число, и на цвет");
    Console.WriteLine("Если сыграла ставка на число - ваша ставка умножается на 36, если на цвет - ставка умножается на 2");
    Console.WriteLine("При одновременной ставке на число и цвет, коэффициент при победе рассчитывается отдельно для ставки на число и цвет");
    Console.WriteLine("Присаживайтесь поудобнее. И да начнется игра! И пусть удача будет на вашей стороне!\n");
    Console.WriteLine("Нажмите любую клавишу для продолжения");
    Console.ReadKey();
}

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
    System.Console.WriteLine($"\nВыпало число {result[0]} {color}");
}

int[] isWinner(int[] usernum, int[] result)
{
    int[] win = new int[2];
    win[0] = -1;
    win[1] = -1;
    if (usernum[0] != 0)
    {
        System.Console.WriteLine($"Вы поставили на число {usernum[2]}, размер ставки: {usernum[0]}");
    }
    if (usernum[1] != 0)
    {
        string color = "";
        if (usernum[3] == 1)
        {
            color = "Красное";
        }
        if (usernum[3] == 2)
        {
            color = "Черное";
        }
        System.Console.WriteLine($"Вы поставили на цвет {color}, размер ставки: {usernum[1]}");
    }
    if (usernum[2] == result[0])
    {

        System.Console.WriteLine("Ставка на число сыграла!");
        win[0] = 36;
    }
    else if (usernum[3] == result[1])
    {
        System.Console.WriteLine("Ставка на цвет сыграла!");
        win[1] = 2;
    }
    else
    {
        System.Console.WriteLine("Ваша ставка не сыграла! Ставка уходит казино!");
    }
    return win;
}

int updateCredit(int[] isWinner, int stavkaNumber, int stavkaColor, int userCredit)
{
    int result = userCredit + stavkaNumber * isWinner[0] + stavkaColor * isWinner[1];
    System.Console.WriteLine(stavkaNumber * isWinner[0] + stavkaColor * isWinner[1]);
    System.Console.WriteLine($"\nВаш текущий депозит {result}");
    return result;
}

void printIncorrectChoise()
{
    Console.WriteLine("Выбор некорректен");
}

int betOnNumber()
{
    int numberBet = -1;
    while (numberBet < 0 || numberBet > 36)
    {
        System.Console.WriteLine("Поставьте на число от 0 до 36!");
        numberBet = Convert.ToInt32(System.Console.ReadLine());
        if (numberBet < 0 || numberBet > 36) printIncorrectChoise();
    }
    return numberBet;
}

int betOnColor()
{
    int colorBet = 0;
    while (colorBet < 1 || colorBet > 2)
    {
        System.Console.WriteLine("Введите 1, чтобы поставить на красное.");
        System.Console.WriteLine("Введите 2, чтобы поставить на черное.");
        colorBet = Convert.ToInt32(System.Console.ReadLine());
        if (colorBet < 1 || colorBet > 2) printIncorrectChoise();
    }
    return colorBet;
}


int BetMoney(int deposit)
{
    int bet = 0;
    while (bet < 50 || bet > deposit)
    {
        System.Console.WriteLine("Введите вашу ставку. Минимальная ставка 50.");
        bet = Convert.ToInt32(Console.ReadLine());
        if (bet < 50 || bet > deposit) printIncorrectChoise();
    }
    return bet;
}

int[] makeBet(int deposit)
{
    int userChoice = 0;
    int userBetNumber = -1;
    int userBetColor = -1;
    int betMoneyColor = 0;
    int betMoneyNumber = 0;
    int[] result = new int[4]; // result[0]-ставка на число, result[1]-ставка на цвет


    while (userChoice < 1 || userChoice > 3)
    {
        System.Console.WriteLine("Нажмите 1, если хотите поставить на число!");
        System.Console.WriteLine("Нажмите 2, если хотите поставить на цвет!");
        System.Console.WriteLine("Нажмите 3, если хотите поставить на число и на цвет!");
        userChoice = Convert.ToInt32(Console.ReadLine());
        if (userChoice < 1 || userChoice > 3) printIncorrectChoise();
    }
    if (userChoice == 1)
    {
        userBetNumber = betOnNumber();
        betMoneyNumber = BetMoney(deposit);
    }

    else if (userChoice == 2)
    {
        userBetColor = betOnColor();
        betMoneyColor = BetMoney(deposit);

    }
    else if (userChoice == 3)
    {
        userBetNumber = betOnNumber();
        betMoneyNumber = BetMoney(deposit - betMoneyColor);
        if ((deposit - betMoneyNumber) >= 50)
        {
            userBetColor = betOnColor();
            betMoneyColor = BetMoney(deposit - betMoneyNumber);
        }

    }
    result[0] = betMoneyNumber;
    result[1] = betMoneyColor;
    result[2] = userBetNumber;
    result[3] = userBetColor;
    return result;
}

bool checkBalance(int userDeposit)
{
    if (userDeposit < 50)
    {
        System.Console.WriteLine("\nМинимальная ставка 50. У вас недостаточно средств. Пополните баланс!");
        return false;
    }
    else
    {
        return true;
    }
}
int userDeposit = 1000;
int[] userBet = new int[3];
ShowRules();
System.Console.WriteLine($"Ваш депозит {userDeposit}");
while (checkBalance(userDeposit))
{
    userBet = makeBet(userDeposit);
    int[,] rulette = CreateRulette();
    int[] resultGame = startgame(rulette);
    PrintResult(resultGame);
    int[] koefficient = isWinner(userBet, resultGame);
    userDeposit = updateCredit(koefficient, userBet[0], userBet[1], userDeposit);
}
System.Console.WriteLine("\nВы проиграли! АуфидерзейнЁ!");
