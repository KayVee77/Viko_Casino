using Assets.DataAccess.Classes;
using Assets.DataAccess.Interfaces.Roullete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Repositories.Roullete
{
    public class Combinations : ICombinations
    {
        IRouletteBetDataAccessor data;

        public Combinations(IRouletteBetDataAccessor x)
        {
           this.data = x;
        }

        public List<RouletteBet> Get19to36()
        {
            List<RouletteBet> bets = new List<RouletteBet>();
            for (int i = 19; i <= 36; i++)
            {
                bets.Add(data.GetBetByNumber(i));
            }
            return bets;
        }

        public List<RouletteBet> Get1to18()
        {
            List<RouletteBet> bets = new List<RouletteBet>();
            for (int i = 1; i <= 18; i++)
            {
                bets.Add(data.GetBetByNumber(i));
            }
            return bets;
        }

        public List<RouletteBet> GetEven()
        {
            return GetAllBets().Where(bet => bet.Number % 2 == 0).ToList();
        }

        public List<RouletteBet> GetOdd()
        {
            return GetAllBets().Where(bet => bet.Number % 2 != 0).ToList();
        }

        public List<RouletteBet> GetOnlyRed()
        {
            return GetAllBets().Where(bet => bet.Color == RouletteColors.Red).ToList();
        }

        public List<RouletteBet> GetOnlyBlack()
        {
            return GetAllBets().Where(bet => bet.Color == RouletteColors.Black).ToList();
        }

        private List<RouletteBet> GetAllBets()
        {
            List<RouletteBet> allBets = new List<RouletteBet>();
            for (int i = 1; i <= 36; i++)
            {
                allBets.Add(data.GetBetByNumber(i));
            }
            return allBets;
        }

        public List<RouletteBet> GetFirst12()
        {
            List<RouletteBet> bets = new List<RouletteBet>();
            for (int i = 1; i <= 12; i++)
            {
                bets.Add(data.GetBetByNumber(i));
            }
            return bets;
        }

        public List<RouletteBet> GetSecond12()
        {
            List<RouletteBet> bets = new List<RouletteBet>();
            for (int i = 13; i <= 24; i++)
            {
                bets.Add(data.GetBetByNumber(i));
            }
            return bets;
        }

        public List<RouletteBet> GetThird12()
        {
            List<RouletteBet> bets = new List<RouletteBet>();
            for (int i = 25; i <= 36; i++)
            {
                bets.Add(data.GetBetByNumber(i));
            }
            return bets;
        }

        public List<RouletteBet> GetThirdLine()
        {
            List<RouletteBet> bets = new List<RouletteBet>();
            for (int i = 1; i <= 34; i += 3)
            {
                bets.Add(data.GetBetByNumber(i));
            }
            return bets;
        }

        public List<RouletteBet> GetSecondLine()
        {
            List<RouletteBet> bets = new List<RouletteBet>();
            for (int i = 2; i <= 35; i += 3)
            {
                bets.Add(data.GetBetByNumber(i));
            }
            return bets;
        }

        public List<RouletteBet> GetFirstLine()
        {
            List<RouletteBet> bets = new List<RouletteBet>();
            for (int i = 3; i <= 36; i += 3)
            {
                bets.Add(data.GetBetByNumber(i));
            }
            return bets;
        }

        public List<RouletteBet> GetGreen()
        {
            return new List<RouletteBet> { data.GetBetByNumber(0) };
        }

        public List<RouletteBet> GetSingleNumberBets(string n)
        {
            List<RouletteBet> bets = new List<RouletteBet>();
            for (int i = 0; i <= 36; i++)
            {
                bets.Add(data.GetBetByNumber(i));
            }
            return bets.Where(x=> x.ToString() == n).ToList();
        }
    }
}
