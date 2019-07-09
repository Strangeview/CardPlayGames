using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardPlayGames
{
    public class Cards:CollectionBase
    {
        public void Add(Card newCard) => List.Add(newCard);
        public void Remove(Card oldCard) => List.Remove(oldCard );
        public  Card this[int cardIndex] //overload indexer
        {
            get
            {
                return (Card)List[cardIndex];
            }
            set
            {
                List[cardIndex] = value;
            }
        }
        ///<summary>
        ///Utility method for copying card instances into another Cards
        ///instance-used in Deck.Shuffle().This implementation assumes that
        ///source and target collections are the same size.
        ///</summary>
        public void CopyTo(Cards targetCards)
        {
            for(int index = 0; index < this.Count; index++)
            {
                targetCards[index] = this[index];
            }
        }
        public bool Contains(Card card) => InnerList.Contains(card);
    }
}
