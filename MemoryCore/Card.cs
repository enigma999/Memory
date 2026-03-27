public class Card
{
    private char _name;
    private char _value;
    private bool _open = false;
    private bool _foundPair = false;

    public char Name { get; set; }
    public char Value { get; set; }
    public bool Open { get; set; }
    public bool FoundPair { get; set; }

    public Card(char name, char value)
    {
        Name = name;
        Value = value;
    }
}