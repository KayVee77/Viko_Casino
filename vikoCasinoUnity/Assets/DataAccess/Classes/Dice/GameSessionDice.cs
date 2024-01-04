using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Classes.Dice
{
    public class GameSessionDice
    {
        public List<DiceUserBets> UserBets { get; set; }= new List<DiceUserBets>();
        public List<Dices> Dices { get; set; } = new List<Dices>();

        public string Won { get; set; }
    }
}
