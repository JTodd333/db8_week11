namespace BlackJack.Models
{
    public class BlackJackClass
    {
        public Hand Player1 { get; set; }
        public Hand House { get; set; }
        public string DeckId { get; set; }
        public Hand Winner
        {
            get
            {
                if (Player1.HandTotal > House.HandTotal)
                {
                    return Player1;
                }
                else
                {
                    return House;
                }
            }
        }
    }

    public class Hand
    {
        public string Username { get; set; }
        public List<Card> Cards { get; set; }
        public int HandTotal
        {
            get
            {
                int total = 0;
                foreach (Card c in Cards)
                {
                    c.NumberValue += total;
                }
                return total;
            }
        }
        public Hand()
        {
            Cards = new List<Card>();
            int total = 0;
            foreach (Card c in Cards)
            {
                c.NumberValue += total;
            }
        }
    }

    public class Card
    {
        public string Suit { get; set; }
        public int NumberValue { get; set; }
        public string Image { get; set; }
    }


}
