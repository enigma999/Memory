using MemoryCore;
using static MemoryCore.MemoryCore;

MemoryGame game = new MemoryGame();
string fullLine = "####################";
string patialLine = "#   ##   ##   ##   #";
int rows = 4;
int columns = 4;
string message = "";
while (true)
{
    CardCollection cards = game.GetCards();
    Console.Clear();
    Console.WriteLine(message);
    PrintCardGrid(cards.GetUpperFaces());
    Console.WriteLine("choose a card to flip");
    message = game.FlipCard(Console.ReadLine());
}

void PrintCardGrid(List<char> faces)
{
    int cardIndex = 0;
    for (int row = 0; row < rows; row++)
    {
        Console.WriteLine(fullLine);
        Console.WriteLine(patialLine);
        for (int column = 0; column < columns; column++)
        {
            Console.Write("# " + faces[cardIndex] + " #");
            cardIndex++;
        }
        Console.WriteLine();
        Console.WriteLine(patialLine);
    }

    Console.WriteLine(fullLine);
}