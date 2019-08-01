using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardPlayGames
{
    [Serializable]
    public enum PlayerState
    {
        Inactive,
        Action,
        MustDiscard,
        Winner,
        Loser
    }
}
