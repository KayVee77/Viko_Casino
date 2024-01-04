using Assets.DataAccess.Classes.Dice;
using Assets.DataAccess.Classes.Roullete;
using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

namespace Assets.DataAccess.Classes.Base_Classes
{
    public static class Settings
    {
        public static User User { get; private set; }
        public static Balance Balance { get; private set; } = new Balance(-1);

        public static GameSession GameSession = new GameSession();
        public static GameSessionDice DiceGS = new GameSessionDice();

        public static void setStaticSettings(User user, Balance balance)
        {
            Settings.User = user;
            Settings.Balance = balance;
        }

       
    }
}
