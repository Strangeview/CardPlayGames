using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardPlayGames;

namespace CardPlayGamesClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck myDeck = new Deck();
            myDeck.Shuffle();
            for (int i = 0; i < 52; i++)
            {
                Card tempCard = myDeck.GetCard(i);
                Console.Write(tempCard?.ToString ());
                if (i != 51)
                {
                    Console.Write("%%");

                }
                else
                {
                    Console.WriteLine();
                }
            }
            //Console.ReadKey();
            Console.WriteLine("********************************************************************************************************");
            Card.isAceHigh = true;
            Console.WriteLine("Ace is high");
            Card.useTrumps = true;
            Card.trump = Suit.Club;
            Console.WriteLine("Clubs are trumps");
            Card card1, card2, card3, card4, card5;
            card1 = new Card(Suit.Club,Rank.Five );
            card2 = new Card(Suit.Club ,Rank.Five );
            card3 = new Card(Suit.Club,Rank.Ace );
            card4 = new Card(Suit.Heart ,Rank.Ten);
            card5 = new Card(Suit.Diamond ,Rank.Ace );
            Console.WriteLine($"{card1.ToString ()}=={card2.ToString ()} ? {card1 == card2}");
            Console.WriteLine($"{card1.ToString ()}!={card3.ToString ()} ? {card1 != card3}");
            Console.WriteLine($"{card1.ToString ()}.Equals({card4.ToString ()}) ? {card1.Equals (card4)}");
            Console.WriteLine($"Card.Equals({card3.ToString ()},{card4.ToString ()}) ? {card3.Equals (card4)}");
            Console.WriteLine($"{card1.ToString ()}>{card2.ToString ()} ? {card1 > card2}");
            Console.WriteLine($"{card1.ToString ()}<={card3.ToString ()} ? {card1<=card3}");
            Console.WriteLine($"{card1.ToString ()}>{card4.ToString ()} ? {card1>card4}");
            Console.WriteLine($"{card4.ToString ()}>{card1.ToString ()} ? {card4>card1}");
            Console.WriteLine($"{card5.ToString ()}>{card4.ToString ()} ? {card5>card4}");
            Console.WriteLine($"{card4.ToString ()}>{card5.ToString ()} ? {card4>card5}");
            Console.WriteLine("**********************************************************************************************************");
            Deck deck1 = new Deck();
            try
            {
                Card myCard = deck1.GetCard(60);
            }
            catch(CardOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.DeckContents [0]);
            }
            Console.ReadKey();
        }
    }
}
