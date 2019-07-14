using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardPlayGames
{
   public class CardOutOfRangeException:Exception
    {
        private Cards deckContents;
        public Cards DeckContents
        {
            get
            {
                return deckContents;
            }
        }
        public CardOutOfRangeException (Cards sourceDeskContents):base("There are only 52 cards in the deck")
        {
            deckContents = sourceDeskContents;
        }
    }
}
