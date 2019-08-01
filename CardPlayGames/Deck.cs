using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardPlayGames
{
    public delegate void LastCardDrawnHandler(Deck currentDeck);
    public class Deck:ICloneable
    {
        //private Card[] cards;
        public event LastCardDrawnHandler LastCardDrawn;
        private Cards cards = new Cards();

        public Deck()
        {
            // cards = new Card[52];

            /*for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    //cards[suitVal * 13 + rankVal - 1] = new Card((Suit)suitVal, (Rank)rankVal);
                    cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                }
            }*/
            InsertAllCards();
        }
        protected  Deck(Cards newCards)
        {
            cards = newCards;
        }
        public int CardsInDeck
        {
            get { return cards.Count; }
        }
        public Deck(bool isAceHigh) : this()
        {
            Card.isAceHigh = isAceHigh;
        }
        public Deck(bool useTrumps,Suit trump) : this()
        {
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }
        public Deck(bool isAceHigh,bool useTrumps,Suit trump):this()
        {
            Card.isAceHigh = isAceHigh;
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }
        public Card GetCard(int cardNum)
        {
           if(cardNum>=0&&cardNum <= 51)
           {
                if ((cardNum == 51 && (LastCardDrawn != null)))
                {
                    LastCardDrawn(this);
                }
                return cards[cardNum];
            }
           else
           {
                //throw (new System.ArgumentOutOfRangeException("cardNum", cardNum, "Value must be between 0 and 51 ."));
                throw new CardOutOfRangeException(cards.Clone() as Cards);
           }
        }

        public void Shuffle()
        {
            //Card[] newDeck = new Card[52];
            Cards newDeck = new Cards();
            bool[] assigned = new bool[cards.Count];
            Random sourceGen = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                //int destCard = 0;
                int sourceCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    //destCard = sourceGen.Next(52);
                    sourceCard = sourceGen.Next(cards.Count);
                    if (assigned[sourceCard] == false)
                    {
                        foundCard = true;
                    }
                    //cards[i] = newDeck[destCard];
                }
                assigned[sourceCard] = true;
                //newDeck[sourceCard] = cards[i];
                //cards[i] = newDeck[destCard];
                newDeck.Add(cards[sourceCard ]);
            }
            // newDeck.CopyTo(cards, 0);
            newDeck.CopyTo(cards);
        }
        public void ReshuffleDiscarded(List<Card> cardsInPlay)
        {
            InsertAllCards(cardsInPlay);
            Shuffle();

        }
        public Card Draw()
        {
            if (cards.Count == 0) return null;
            var card = cards[0];
            cards.RemoveAt(0);
            return card;

        }
        public Card SelectCardOfSpecificSuit(Suit suit)
        {
            Card selectedCard = cards.FirstOrDefault(card => card?.suit == suit);
            if (selectedCard == null) return Draw();
            cards.Remove(selectedCard);
            return selectedCard;
        }
        public object Clone()
        {
            Deck newDeck = new Deck(cards.Clone() as Cards);
            return newDeck;
        }
        private void InserAllCards()
        {
            for(int suitVal = 0; suitVal < 4; suitVal++)
            {
                for(int rankVal = 1; rankVal < 14; rankVal++)
                {
                    cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                }
            }
        }
        private void InsertAllCards(List<Card> except)
        {
            for(int suitVal = 0; suitVal < 4; suitVal++)
            {
                for(int rankVal = 1; rankVal < 14; rankVal++)
                {
                    var card = new Card((Suit)suitVal, (Rank)rankVal);
                    if (except?.Contains(card) ?? false) continue;
                    cards.Add(card);
                }
            }
        }

    }
}