using Assets.DataAccess.Classes.Base_Classes;
using Assets.DataAccess.Interfaces.DiceGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Repositories.Dice
{
    public class DicePayout : IDicePayout
    {
        public void PayoutMoney()
        {
            int sum = 0;

            foreach (var item in Settings.DiceGS.UserBets)
            {
                if (item.NameOfBet == Settings.DiceGS.Won && Settings.DiceGS.Won != "Draw")
                {
                    sum += item.Amount * 2;
                }
                else if (item.NameOfBet == Settings.DiceGS.Won && Settings.DiceGS.Won == "Draw")
                {
                    sum += item.Amount * 7;
                }

            }

            Settings.Balance.setAmount(Settings.Balance.getAmount() + sum);
        }
    }
}
