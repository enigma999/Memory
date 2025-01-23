namespace MemoryCore;

public class MemoryCore
{
    public class MemoryGame
    {
        private Dictionary<char, char> cards;
        private char[] state;

        public MemoryGame()
        {
            this.state = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p'];

            char[] cardValues = { '1', '2', '3', '4', '5', '1', '2', '3', '4', '5', '6', '7', '6', '7', '8', '8' };

            this.cards = new Dictionary<char, char>();
            for (int i = 0; i < cardValues.Length; i++)
            {
               this.cards.Add((char)(97 + i), cardValues[i]);
            }
        }

        public char[] GetState()
        {
            return state;
        }

        public string FlipCard(char[] state, string input)
        {
            if (input.Length > 1 || input.Length == 0)
            {
                return "only a single character allowed";
            }
            char cardCharacter = input[0];
            if (!state.Contains(cardCharacter))
            {
                return "card doesn't exist, or is already flipped";
            }

            int index = Array.IndexOf(state, cardCharacter);
            state[index] = cards[cardCharacter];
            this.state = state;
            return "you fliped card " + cardCharacter;
        }
    }
}