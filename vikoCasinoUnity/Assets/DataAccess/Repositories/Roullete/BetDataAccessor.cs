using Assets.DataAccess.Classes;
using Assets.DataAccess.Interfaces.Roullete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Repositories.Roullete
{
    public class BetDataAccessor : IRouletteBetDataAccessor
    {
        private RouletteBet CreateBet(RouletteColors color, int number)
        {
            return new RouletteBet(color, number);
        }

        public RouletteBet GetBetByNumber(int number)
        {
            RouletteColors color = DetermineColor(number);
            return CreateBet(color, number);
        }

        private RouletteColors DetermineColor(int number)
        {
            if (number == 0) return RouletteColors.Green; 
            else if ((number >= 1 && number <= 10) || (number >= 19 && number <= 28))
            {
                return number % 2 == 0 ? RouletteColors.Black : RouletteColors.Red;
            }
            else
            {
                return number % 2 == 0 ? RouletteColors.Red : RouletteColors.Black;
            }
        }
    }
}
