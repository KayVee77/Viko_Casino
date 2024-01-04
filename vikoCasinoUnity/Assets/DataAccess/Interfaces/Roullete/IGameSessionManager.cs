using Assets.DataAccess.Classes;
using Assets.DataAccess.Classes.Roullete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Interfaces.Roullete
{
    public interface IGameSessionManager
    {
        public void AddUserBet(RouletteUserBets userBet);

        public void DeleteAllBets();
        public void setWonBet(RouletteBet bet);
        public decimal getAllBetsMoney();
    }
}
