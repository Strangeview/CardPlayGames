using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardPlayGames
{
    public class CardEventArgs :EventArgs
    {
        public Card Card { get; set; }
    }
}
