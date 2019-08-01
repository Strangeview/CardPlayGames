using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardPlayGames
{
    public class PlayerEventArgs:EventArgs
    {
        public Player Player { get; set; }
        public PlayerState State { get; set; }
    }
}
