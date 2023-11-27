using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Roulette;

int userDeposit = 0;
int userBid = 0;
Console.CursorVisible = false;
// Console.WindowHeight = 50;
// Console.WindowWidth = 70;
Console.Clear();
PrintFilePlayingField(File.ReadAllLines(@"PrintRoulette_v.1.txt"));
PrintTextInPositionOnTerminal("Нажмите SPACE для старта или Escape для выхода", 0, 10);
ConsoleKeyInfo charKeyOutGame = Console.ReadKey();
Console.Clear();
StartInterfaсeRoulette(File.ReadAllLines(@"RouletteInterface.txt"), charKeyOutGame, userDeposit, userBid);
