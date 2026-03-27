namespace MemoryCore;

public class CardCollection
{
    private List<Card> _cards;

    public CardCollection()
    {
        _cards = new List<Card>();
    }
    public void AddCard(Card card)
    {
        _cards.Add(card);
    }

    public void FlipCard(char character)
    {
        foreach (Card card in _cards)
        {
            if (card.Name == character)
            {
                card.Open = true;
                break;
            }
        }
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
}