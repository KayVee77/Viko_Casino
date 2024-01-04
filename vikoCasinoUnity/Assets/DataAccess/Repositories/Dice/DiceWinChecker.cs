using Assets.DataAccess.Classes.Base_Classes;
using Assets.DataAccess.Interfaces.DiceGame;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Repositories.Dice
{
    public class DiceWinChecker : IDiceWinChecker
    {
        public void CheckWin()
        {
            // Settings.DiceGS.UserBets
            // Settings.DiceGS.Dices

            if (Settings.DiceGS.Dices[0].Number > Settings.DiceGS.Dices[1].Number)
            {
                Settings.DiceGS.Won = "1st Dice win";
            }
            else if (Settings.DiceGS.Dices[0].Number < Settings.DiceGS.Dices[1].Number)
            {
                Settings.DiceGS.Won = "2nd Dice win";
            }
            else 
            {
                Settings.DiceGS.Won = "Draw";
            }
        }
    }
}
