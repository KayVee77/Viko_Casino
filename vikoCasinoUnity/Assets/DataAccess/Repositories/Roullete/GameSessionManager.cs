using Assets.DataAccess.Classes;
using Assets.DataAccess.Classes.Base_Classes;
using Assets.DataAccess.Classes.Roullete;
using Assets.DataAccess.Interfaces.Roullete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Repositories.Roullete
{
    public class GameSessionManager : IGameSessionManager
    {
        public void DeleteAllBets()
        {
            Settings.GameSession.Bets = new List<RouletteUserBets>();
        }

        public void AddUserBet(RouletteUserBets userBet)
        {
            Settings.GameSession.Bets.Add(userBet);
        }

        public void setWonBet(RouletteBet bet)
        {
            Settings.GameSession.WonBet = bet;
        }

        public decimal getAllBetsMoney()
        {
            int x = 0;
            Settings.GameSession.Bets.ForEach(bet => x += bet.Amount);

            return x;
        }
    }
}
