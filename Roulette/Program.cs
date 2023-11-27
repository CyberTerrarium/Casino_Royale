using static Roulette;

int userDeposit = 0;
int userBid = 0;


Console.CursorVisible = false;
Console.Clear();
PrintInterfaсeRoulette(File.ReadAllLines(@"RouletteInterface.txt"), userDeposit, userBid);
