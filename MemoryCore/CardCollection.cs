namespace MemoryCore;

public class CardCollection
{
    private List<Card> _cards;
    private int _pairsFound = 0;
    public int Count => _cards.Count;
    public int PairsFound { get; set; }
    public int TotalPairs => Count / 2;
    

    public CardCollection()
    {
        _cards = new List<Card>();
    }
    public void AddCard(Card card)
    {
        _cards.Add(card);
    }

    public List<char> GetUpperFaces()
    {
        List<char> faceList = new List<char>();
        foreach (Card card in _cards)
        {
            if (card.Open)
            {
                faceList.Add(card.Value);
            }
            else
            {
                faceList.Add(card.Name);
            }
        }
        return faceList;
    }

    public Card GetCard(char character)
    {
        foreach (Card card in _cards)
        {
            if (card.Name == character)
            {
                return card;
            }
        }
        
        throw new Exception("Card not found");// todo make custom exception;
    }
    
    public Card GetCardByIndex(int index)
    {
        return _cards[index];
    }
}