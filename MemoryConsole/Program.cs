using MemoryCore;
using static MemoryCore.MemoryCore;

MemoryGame game = new MemoryGame();
string fullLine = "##### ##### ##### #####";
string patialLine = "#   # #   # #   # #   # ";
int rows = 4;
int columns = 4;
string message = "";
while (true)
{
    CardCollection cards = game.GetCards();
    Console.Clear();
    Console.WriteLine(message);
    PrintCardGrid(cards);
    Console.WriteLine("choose a card to flip");
    message = game.FlipCard(Console.ReadLine());
}

void PrintCardGrid(CardCollection cards)
{
    int cardIndex = 0;
    for (int row = 0; row < rows; row++)
    {
        printRow(row, cards);
    }
}

void printRow(int row, CardCollection cards)
{
    Console.WriteLine(fullLine);
    Console.WriteLine(patialLine);
    for (int column = 0; column < columns; column++)
    {
        int cardIndex = row * columns + column;
        Card card = cards.GetCardByIndex(cardIndex);

        Console.Write("# ");
        PrintCardFace(card);
        Console.Write(" # ");
    }

    Console.WriteLine();
    Console.WriteLine(patialLine);
    Console.WriteLine(fullLine);
    Console.WriteLine();
}

void PrintCardFace(Card card)
{
    char face;
    if (card.Open)
    {
        face = card.Value;
    }
    else
    {
        face = card.Name;
    }

    if (card.FoundPair)
    {
        Console.ForegroundColor = ConsoleColor.Green;
    }
    if (card.Open && !card.FoundPair)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
    }
    Console.Write(face);
    Console.ResetColor();
}