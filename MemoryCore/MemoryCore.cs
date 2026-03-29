using MemoryCore.Exceptions;

namespace MemoryCore;

public class MemoryCore
{
    public class MemoryGame
    {
        private CardCollection _cards;
        private Card? _firstChoice;
        private Card? _secondchoice;
        private static readonly char StartingCharacter = 'a';
        private static readonly int CardCount = 16;
        private static readonly Random Random = new Random();

        public MemoryGame()
        {
            SetupCards();
        }

        private void SetupCards()
        {
            _cards = new CardCollection();
            char Character = StartingCharacter;
            char[] cardValues = GenerateCardValues(CardCount);
            Shuffle(cardValues);
            for (int i = 0; i < CardCount; i++)
            {
                
                _cards.AddCard(new Card(Character, cardValues[i]));
                Character++;
            }
        }
        
        private char[] GenerateCardValues(int cardCount)
        {
            if (cardCount % 2 != 0 && cardCount < 20)
                throw new ArgumentException("Card count must be even and produce no more than 10 pairs.");

            char[] values = new char[cardCount];

            int pairCount = cardCount / 2;
            char current = '0';

            int index = 0;
            for (int i = 0; i < pairCount; i++)
            {
                values[index++] = current;
                values[index++] = current;
                current++;
            }

            return values;
        }
        
        private void Shuffle(char[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = Random.Next(i + 1);
                (array[i], array[j]) = (array[j], array[i]);
            }
        }

        public CardCollection GetCards()
        {
            return _cards;
        }

        public string FlipCard(string? input)
        {
            string message;
            try
            {
                Card chosenCard = CleanInput(input);
                chosenCard.Flip();
                message = "you fliped card " + chosenCard.Name + ". ";
                if (_firstChoice == null)
                {
                    _firstChoice = chosenCard;
                }
                else if (_secondchoice == null)
                {
                    _secondchoice = chosenCard;
                    if (_firstChoice.Value == _secondchoice.Value)
                    {
                        _firstChoice.FoundPair = true;
                        _secondchoice.FoundPair = true;
                        message += " match found!!!";
                        _cards.PairsFound++;
                        if (_cards.TotalPairs == _cards.PairsFound)
                        {
                            message += " all cards found!!!";
                        }
                    }
                    else
                    {
                        message += " no match";
                    }
                }
                else
                {

                    if (_firstChoice.Value != _secondchoice.Value)
                    {
                        _firstChoice.Flip();
                        _secondchoice.Flip();
                    }
                    _firstChoice = chosenCard;
                    _secondchoice = null;
                }
            }
            catch (InvalidCardChoiceException e)
            {
                message = e.Message;
            }
            
            return message;
        }

        private Card CleanInput(string? input)
        {
            if (input is not { Length: 1 })
            {
                throw new InvalidCardChoiceException("only a single character allowed");
            }

            char cardCharacter = input[0];
            Card chosenCard = _cards.GetCard(cardCharacter);
            if (chosenCard.FoundPair)
            {
                throw new InvalidCardChoiceException("Already found pair");
            }

            if (chosenCard == _firstChoice && _secondchoice == null)
            {
                throw new InvalidCardChoiceException("Can not pick the same card twice");
            }
            return chosenCard;
        }
    }
}