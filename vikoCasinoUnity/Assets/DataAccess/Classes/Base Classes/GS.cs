using Assets.DataAccess.Classes.Base_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Classes.Roullete
{
    public class GS<Tbet> where Tbet : Bet
    {
        public List<RouletteUserBets> Bets { get; set; } = new List<RouletteUserBets>();
        public RouletteBet WonBet { get; set; }

        public decimal balanceChange { get; set; }

    }
}
