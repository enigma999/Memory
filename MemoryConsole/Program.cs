char[] initialState = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't'];
char[] state = initialState;
while (true)
{
    Console.Clear();
    PrintCardGrid();
    Console.WriteLine("choose a card to flip");
    Console.Read();
}

void PrintCardGrid()
{
    Console.WriteLine("#########################");
    Console.WriteLine("#   ##   ##   ##   ##   #");
    Console.WriteLine("# " + state[0] + " ## " + state[1] + " ## " + state[2] + " ## " + state[3] + " ## " + state[4] + " #");
    Console.WriteLine("#   ##   ##   ##   ##   #");
    Console.WriteLine("#########################");
    Console.WriteLine("#   ##   ##   ##   ##   #");
    Console.WriteLine("# " + state[5] + " ## " + state[6] + " ## " + state[7] + " ## " + state[8] + " ## " + state[9] + " #");
    Console.WriteLine("#   ##   ##   ##   ##   #");
    Console.WriteLine("#########################");
    Console.WriteLine("#   ##   ##   ##   ##   #");
    Console.WriteLine("# " + state[10] + " ## " + state[11] + " ## " + state[12] + " ## " + state[13] + " ## " + state[14] + " #");
    Console.WriteLine("#   ##   ##   ##   ##   #");
    Console.WriteLine("#########################");
    Console.WriteLine("#   ##   ##   ##   ##   #");
    Console.WriteLine("# " + state[15] + " ## " + state[16] + " ## " + state[17] + " ## " + state[18] + " ## " + state[19] + " #");
    Console.WriteLine("#   ##   ##   ##   ##   #");
    Console.WriteLine("#########################");
}

