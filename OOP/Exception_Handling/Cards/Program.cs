using System.Text;

namespace Cards
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            List<Card> cards = new();
            for (int i = 0; i < input.Length; i++)
            {
                string[] tokens = input[i].Split();
                string face = tokens[0];
                string suit = tokens[1];
                try
                {
                    cards.Add(new Card(face, suit));
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(string.Join(" ", cards));
        }
    }
    public class Card
    {
        private readonly string[] facesAndSuits
             = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", "S", "H", "D", "C" };


        private Dictionary<string, string> symbols = new()
        {
            {"S","\u2660"},
            {"H","\u2665"},
            {"D", "\u2666"},
            {"C", "\u2663"}
        };

        private string face;
        private string suit;
        private string symbol;
        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
            symbol = symbols[Suit];
        }

        public string Face
        {
            get => face;
            set
            {
                if (!facesAndSuits.Contains(value))
                { throw new ArgumentException("Invalid card!"); }
                face = value;
            }
        }
        public string Suit
        {
            get => suit;
            set
            { if (!facesAndSuits.Contains(value))
                { throw new ArgumentException("Invalid card!"); }
                suit = value; }
        }



        public override string ToString()
        {
            return $"[{Face}{symbol}]";
        }
    }
    
}
//5 C, 10 D, king C, K C, Q heart, Q H