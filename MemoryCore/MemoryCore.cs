using MemoryCore.Exceptions;

namespace MemoryCore;

public class MemoryCore
{
    public class MemoryGame
    {
        private CardCollection _cards;
        private Card? _firstChoice;
        private Card? _secondchoice;

        private static readonly char[] CardCharacters =
            ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p'];

        private static readonly char[] CardValues =
            ['1', '2', '3', '4', '5', '1', '2', '3', '4', '5', '6', '7', '6', '7', '8', '8'];

        public MemoryGame()
        {
            SetupCards();
        }

        private void SetupCards()
        {
            _cards = new CardCollection();
            for (int i = 0; i < CardCharacters.Length; i++)
            {
                _cards.AddCard(new Card(CardCharacters[i], CardValues[i]));
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
            if (!CardCharacters.Contains(cardCharacter))
            {
                throw new InvalidCardChoiceException("card doesn't exist");
            }
            Card chosenCard = _cards.GetCard(cardCharacter);
            if (chosenCard.FoundPair)
            {
                throw new InvalidCardChoiceException("Already found pair");
            }

            if (chosenCard == _firstChoice)
            {
                throw new InvalidCardChoiceException("Can not pick the same card twice");
            }
            return chosenCard;
        }
    }
}