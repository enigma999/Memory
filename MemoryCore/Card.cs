public class Card
{
    private char _name;
    private char _value;
    private bool _open = false;

    public char Name { get; set; }
    public char Value { get; set; }
    public bool Open { get; set; }

    public Card(char name, char value)
    {
        Name = name;
        Value = value;
    }
}