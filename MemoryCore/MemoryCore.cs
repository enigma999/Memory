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
                char cardCharacter = CleanInput(input);
                _cards.FlipCard(cardCharacter);
                Card chosenCard = _cards.GetCard(cardCharacter);
                message = "you fliped card " + cardCharacter + ". ";
                if (_firstChoice == null)
                {
                    _firstChoice = chosenCard;
                }
                else if (_secondchoice == null)
                {
                    _secondchoice = chosenCard;
                }
                else
                {
                    if (_firstChoice == _secondchoice)
                    {
                        _firstChoice.Open = false;
                        _secondchoice.Open = false;
                    }
                    _firstChoice = chosenCard;
                    _secondchoice = null;
                }
            }
            catch (InvalidCardChoiceException e)
            {
                message = e.Message;
            }

            message += "chosen card one: " + _firstChoice + " ";
            message += "chosen card two: " + _secondchoice + " ";
            return message;
        }

        private char CleanInput(string? input)
        {
            if (input is not { Length: 1 })
            {
                throw new InvalidCardChoiceException("only a single character allowed");
            }

            char cardCharacter = input[0];
            if (!CardCharacters.Contains(cardCharacter))
            {
                throw new InvalidCardChoiceException("card doesn't exist, or is already flipped");
            }

            return cardCharacter;
        }
    }
}