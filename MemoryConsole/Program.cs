using static MemoryCore.MemoryCore;

MemoryGame game = new MemoryGame();


char[] state;
string message = "";
while(true)
{
    state = game.GetState();
    Console.Clear();
    Console.WriteLine(message);
    PrintCardGrid();
    Console.WriteLine("choose a card to flip");
    message = game.FlipCard(state,Console.ReadLine());
}

void PrintCardGrid()
{
    Console.WriteLine("####################");
    Console.WriteLine("#   ##   ##   ##   #");
    Console.WriteLine("# " + state[0] + " ## " + state[1] + " ## " + state[2] + " ## " + state[3] + " #");
    Console.WriteLine("#   ##   ##   ##   #");
    Console.WriteLine("####################");
    Console.WriteLine("#   ##   ##   ##   #");
    Console.WriteLine("# " + state[4] + " ## " + state[5] + " ## " + state[6] + " ## " + state[7] + " #");
    Console.WriteLine("#   ##   ##   ##   #");
    Console.WriteLine("####################");
    Console.WriteLine("#   ##   ##   ##   #");
    Console.WriteLine("# " + state[8] + " ## " + state[9] + " ## " + state[10] + " ## " + state[11] + " #");
    Console.WriteLine("#   ##   ##   ##   #");
    Console.WriteLine("####################");
    Console.WriteLine("#   ##   ##   ##   #");
    Console.WriteLine("# " + state[12] + " ## " + state[13] + " ## " + state[14] + " ## " + state[15] + " #");
    Console.WriteLine("#   ##   ##   ##   #");
    Console.WriteLine("####################");
}