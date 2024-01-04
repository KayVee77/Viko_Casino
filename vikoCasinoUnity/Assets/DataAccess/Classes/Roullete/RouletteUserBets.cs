using Assets.DataAccess.Classes.Base_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Classes.Roullete
{
    public class RouletteUserBets : Bet
    {
        public int Amount { get; }
        public string NameOfBet { get; }

        public RouletteUserBets(string nameofBet, int amount)
        {
                this.NameOfBet = nameofBet;
                this.Amount = amount;
        }

        public override string ToString()
        {
            return NameOfBet;
        }
    }
}
