using MemoryCore.Exceptions;

namespace MemoryCore;

public class MemoryCore
{
    public class MemoryGame
    {
        private Dictionary<char, char> _cards;
        private char[] _state;
        private int _firstchoice;
        private int _secondchoice;

        private static readonly char[] CardCharacters =
            ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p'];

        public MemoryGame()
        {
            _cards = SetupCards();
            _state = CardCharacters;
            SetupCards();
        }

        private Dictionary<char, char> SetupCards()
        {
            char[] cardValues = ['1', '2', '3', '4', '5', '1', '2', '3', '4', '5', '6', '7', '6', '7', '8', '8'];

            Dictionary<char, char> cards = new Dictionary<char, char>();
            for (int i = 0; i < cardValues.Length; i++)
            {
                cards.Add((char)(97 + i), cardValues[i]);
            }

            return cards;
        }

        public char[] GetState()
        {
            return _state;
        }

        public string FlipCard(char[] state, string? input)
        {
            string message;
            try
            {
                char cardCharacter = CleanImput(input);
                int index = Array.IndexOf(state, cardCharacter);
                state[index] = _cards[cardCharacter];
                _state = state;
                message = "you fliped card " + cardCharacter;
            }
            catch (InvalidCardChoiceException e)
            {
                message = e.Message;
            }

            return message;
        }

        public char CleanImput(string input)
        {
            if (input.Length != 1)
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