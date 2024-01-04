using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Classes.Dice
{
    public class DiceUserBets
    {
        public string NameOfBet { get; set; }
        public int Amount { get; set; }

        public override string ToString()
        {
            return this.NameOfBet;
        }
        public DiceUserBets(string nameOfBet, int amount)
        {
            this.NameOfBet = nameOfBet;
            this.Amount = amount;
        }
    }
}
