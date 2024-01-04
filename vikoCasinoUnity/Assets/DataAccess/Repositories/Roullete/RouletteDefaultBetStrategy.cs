using Assets.DataAccess.Classes;
using Assets.DataAccess.Interfaces;
using Assets.DataAccess.Interfaces.Roullete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.DataAccess.Repositories
{
    public class RouletteDefaultBetStrategy : IBetStrategy
    {
        IRouletteBetDataAccessor strategy;
        private readonly int[] wheelNumbers = {
            0, 32, 15, 19, 4, 21, 2, 25, 17, 34, 6, 27, 13, 36, 11, 30, 8, 23, 10, 5, 24, 16, 33, 1, 20, 14, 31, 9, 22, 18, 29, 7, 28, 12, 35, 3, 26
         };

        public RouletteDefaultBetStrategy(IRouletteBetDataAccessor strategyAccessor)
        {
            this.strategy = strategyAccessor;
        }

        public RouletteBet DetermineWinningBet(float angle)
        {
            float anglePerTurn = 360f / wheelNumbers.Length;
            int segment = Mathf.FloorToInt(angle / anglePerTurn) % wheelNumbers.Length;

            int number = ConvertSegmentToNumber(segment);

            return strategy.GetBetByNumber(number);
        }

        private int ConvertSegmentToNumber(int segment)
        {
            if (segment >= 0 && segment < wheelNumbers.Length)
            {
                return wheelNumbers[segment];
            }
            else
            {
                return -1;
            }
        }
    }
}
