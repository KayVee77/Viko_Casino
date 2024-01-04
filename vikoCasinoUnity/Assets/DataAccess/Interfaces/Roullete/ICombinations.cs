using Assets.DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Interfaces.Roullete
{
    public interface ICombinations
    {
        public List<RouletteBet> GetFirst12();
        public List<RouletteBet> GetSecond12();
        public List<RouletteBet> GetThird12();
        public List<RouletteBet> GetFirstLine();
        public List<RouletteBet> GetSecondLine();
        public List<RouletteBet> GetThirdLine();
        public List<RouletteBet> Get1to18();
        public List<RouletteBet> Get19to36();
        public List<RouletteBet> GetEven();
        public List<RouletteBet> GetOdd();
        public List<RouletteBet> GetOnlyRed();
        public List<RouletteBet> GetOnlyBlack();
        public List<RouletteBet> GetGreen();
        public List<RouletteBet> GetSingleNumberBets(string nameOfBet);

    }
}
