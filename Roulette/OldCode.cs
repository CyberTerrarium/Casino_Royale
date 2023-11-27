// using System.Collections.ObjectModel;
// using System.Collections.Generic;
// using System;

// public class OldCode
// {
//     int[,] CreateRulette()
//     {
//         int[,] rulette = new int[2, 37];
//         for (int i = 0; i < rulette.GetLength(0); i++)
//         {
//             for (int j = 0; j < rulette.GetLength(1); j++)
//             {
//                 if (i == 0)
//                 {
//                     rulette[i, j] = j;
//                 }
//                 else
//                 {
//                     if (j == 0) continue;
//                     if (j % 2 == 0)
//                     {
//                         rulette[i, j] = 1;
//                     }
//                     else
//                     {
//                         rulette[i, j] = 2;
//                     }

//                 }
//             }
//         }
//         return rulette;
//     }


//     int[] startgame(int[,] rulette)
//     {
//         int[] result = new int[2];
//         int random = new Random().Next(0, 37);
//         result[0] = rulette[0, random];
//         result[1] = rulette[1, random];
//         return result;
//     }

//     void PrintResult(int[] result)
//     {
//         string color;
//         if (result[1] == 1)
//         {
//             color = "Krasnoe";
//         }
//         else if (result[1] == 2)
//         {
//             color = "Chernoe";
//         }
//         else
//         {
//             color = "Zero";
//         }
//         System.Console.WriteLine($"Выпало число {result[0]} {color}");
//     }

//     int[] isWinner(int[] usernum, int[] result)
//     {
//         int[] win = new int[2];
//         if (usernum[0] == 0 || usernum[1] == 0)
//         {
//             if (usernum[2] == result[0])
//             {
//                 System.Console.WriteLine("winner winner chicken dinner!");
//                 win[0] = 36;
//             }
//             else if (usernum[3] == result[1])
//             {
//                 System.Console.WriteLine("Ставка на цвет сыграла!");
//                 win[1] = 2;
//             }
//             else
//             {
//                 System.Console.WriteLine("Ваша ставка не сыграла!Ставка уходит казино!");
//                 win[0] = -1;
//                 win[1] = -1;
//             }
//         }
//         else
//         {
//             if (usernum[2] == result[0])
//             {
//                 System.Console.WriteLine("winner winner chicken dinner!");
//                 win[0] = 36;
//             }
//             if (usernum[3] == result[1])
//             {
//                 System.Console.WriteLine("Ставка на цвет сыграла!");
//                 win[1] = 2;
//             }
//             else
//             {
//                 System.Console.WriteLine("Ваша ставка не сыграла!Ставка уходит казино!");
//                 win[0] = -1;
//                 win[1] = -1;
//             }
//         }
//         return win;
//     }

//     int updateCredit(int[] isWinner, int stavkaNumber, int stavkaColor, int userCredit)
//     {
//         int result = userCredit + stavkaNumber * isWinner[0] + stavkaColor * isWinner[1];
//         System.Console.WriteLine(stavkaNumber * isWinner[0] + stavkaColor * isWinner[1]);
//         System.Console.WriteLine($"Ваш текущий депозит {result}");
//         return result;
//     }

//     int[] makeBet()
//     {
//         int userChoice = 0;
//         int userBetNumber = 0;
//         int userBetColor = 0;
//         int betMoneyColor = 0;
//         int betMoneyNumber = 0;
//         int[] result = new int[4]; // result[0]-ставка на число, result[1]-ставка на цвет


//         while (userChoice < 1 || userChoice > 3)
//         {
//             System.Console.WriteLine($"Нажмите 1, если хотите поставить на число!");
//             System.Console.WriteLine($"Нажмите 2, если хотите поставить на цвет!");
//             System.Console.WriteLine(("Нажмите 3, если хотите поставить на число и на цвет!"));
//             userChoice = Convert.ToInt32(Console.ReadLine());
//         }
//         if (userChoice == 1)
//         {
//             while (userBetNumber < 1 || userBetNumber > 36)
//             {
//                 System.Console.WriteLine("Поставьте на число от 1 до 36!");
//                 userBetNumber = Convert.ToInt32(System.Console.ReadLine());
//                 while (betMoneyNumber < 50)
//                 {
//                     System.Console.WriteLine("Введите вашу ставку. Минимальная ставка 50.");
//                     betMoneyNumber = Convert.ToInt32(Console.ReadLine());
//                 }
//             }
//         }
//         else if (userChoice == 2)
//         {
//             while (userBetColor < 1 || userBetColor > 2)
//             {
//                 System.Console.WriteLine("Введите 1, чтобы поставить на красное.");
//                 System.Console.WriteLine("Введите 2, чтобы поставить на черное.");
//                 userBetColor = Convert.ToInt32(System.Console.ReadLine());
//                 while (betMoneyColor < 50)
//                 {
//                     System.Console.WriteLine("Введите вашу ставку. Минимальная ставка 50.");
//                     betMoneyColor = Convert.ToInt32(Console.ReadLine());
//                 }
//             }
//         }
//         else if (userChoice == 3)
//         {
//             System.Console.WriteLine("Выберите число для ставки: ");
//             while (userBetNumber < 1 || userBetNumber > 36)
//             {
//                 userBetNumber = Convert.ToInt32(System.Console.ReadLine());
//                 while (betMoneyNumber < 50)
//                 {
//                     System.Console.WriteLine("Введите вашу ставку. Минимальная ставка 50.");
//                     betMoneyNumber = Convert.ToInt32(Console.ReadLine());
//                 }
//             }
//             System.Console.WriteLine("Выберите цвет: 1 - красное, 2 - черное!");
//             while (userBetColor < 1 || userBetColor > 2)
//             {
//                 userBetColor = Convert.ToInt32(System.Console.ReadLine());
//                 while (betMoneyColor < 50)
//                 {
//                     System.Console.WriteLine("Введите вашу ставку. Минимальная ставка 50.");
//                     betMoneyColor = Convert.ToInt32(Console.ReadLine());
//                 }
//             }

//         }
//         result[0] = betMoneyNumber;
//         result[1] = betMoneyColor;
//         result[2] = userBetNumber;
//         result[3] = userBetColor;
//         return result;
//     }

//     bool checkBalance(int userDeposit)
//     {
//         if (userDeposit < 50)
//         {
//             System.Console.WriteLine("Недостаточно средств. Пополните баланс!");
//             return false;
//         }
//         else
//         {
//             return true;
//         }
//     }
//     int userDeposit = 1000;
//     int[] userBet = new int[3];
//     System.Console.WriteLine($"Ваш депозит {userDeposit}");

// while(checkBalance(userDeposit)){
//     userBet = makeBet();
//     int[,] rulette = CreateRulette();
//     int[] resultGame = startgame(rulette);
//     PrintResult(resultGame);
//     int[] koefficient = isWinner(userBet, resultGame);
//     userDeposit = updateCredit(koefficient, userBet[0], userBet[1], userDeposit);
// }
// System.Console.WriteLine("Вы проиграли! АуфидерзейнЁ!");
// }