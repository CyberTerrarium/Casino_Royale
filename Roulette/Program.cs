using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.VisualBasic;
using System.IO;
using static Roulette;

// MainSet();

// static void MainSet()
// {
//     int userDeposit=0;
//     int userBid=0;
//     Console.CursorVisible = false;
//     // Console.WindowHeight = 15;
//     // Console.WindowWidth = 59;
//     Console.Clear();
//     PrintFilePlayingField(File.ReadAllLines(@"PrintRoulette_v.1.txt"),
//                             0, 0,
//                             ConsoleColor.Red);
//     PrintTextInPositionOnTerminal("Нажмите SPACE для старта или Escape для выхода", 
//                                     0, 7);
//     ConsoleKeyInfo charKeyInteractionWithGame = Console.ReadKey();
//     Console.Clear();
//     StartGameRoulette(File.ReadAllLines(@"RouletteInterface.txt"), charKeyInteractionWithGame);
// }

char[,] arraySymbol = ReadFileTXTAndConvertToChar(File.ReadAllLines(@"RouletteInterface.txt"));
PrintFilePlayingField(arraySymbol);