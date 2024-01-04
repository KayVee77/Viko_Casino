using Assets.DataAccess.Classes;
using Assets.DataAccess.Classes.Base_Classes;
using Assets.DataAccess.Classes.Roullete;
using Assets.DataAccess.Interfaces.Roullete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.DataAccess.Repositories.Roullete
{
    public class WinChecker : IWinChecker
    {
        ICombinations combinations;
        IGameSessionManager gameSessionManager;

        public WinChecker(ICombinations x)
        {
            combinations = x;
            gameSessionManager = new GameSessionManager();
        }

        public bool CheckWin()
        {
            bool hasWon = false;


            foreach (var bet in Settings.GameSession.Bets)
            {
                List<RouletteBet> possibleWinningBets = GetPossibleWinningBets(bet);
                if (possibleWinningBets.Contains(Settings.GameSession.WonBet))
                {
                    decimal winAmount = CalculateWinAmount(bet);
                    Settings.GameSession.balanceChange += winAmount;
                    Debug.Log($"Bet won: Type - {bet.ToString()}, Amount Won - {winAmount}");
                    hasWon = true;
                }
                else
                {
                    Debug.Log($"Bet lost: Type - {bet.ToString()}, Amount Lost - {bet.Amount}");
                }
            }

            return hasWon;
        }

        private decimal CalculateWinAmount(RouletteUserBets bet)
        {
            decimal payoutMultiplier = GetPayoutMultiplierForBetType(bet);
            return bet.Amount * payoutMultiplier;
        }

        private List<RouletteBet> GetPossibleWinningBets(RouletteUserBets bet)
        {
            switch (bet.ToString())
            {
                case "First 12":
                    return combinations.GetFirst12();
                case "Second 12":
                    return combinations.GetSecond12();
                case "Third 12":
                    return combinations.GetThird12();
                case "First Line":
                    return combinations.GetFirstLine();
                case "Second Line":
                    return combinations.GetSecondLine();
                case "Third Line":
                    return combinations.GetThirdLine();
                case "1 to 18":
                    return combinations.Get1to18();
                case "19 to 36":
                    return combinations.Get19to36();
                case "Even":
                    return combinations.GetEven();
                case "Odd":
                    return combinations.GetOdd();
                case "Only Red":
                    return combinations.GetOnlyRed();
                case "Only Black":
                    return combinations.GetOnlyBlack();
                case "0 Green":
                    return combinations.GetGreen();
                    default:
                    return combinations.GetSingleNumberBets(bet.NameOfBet);
            }
        }

        private decimal GetPayoutMultiplierForBetType(RouletteUserBets bet)
        {
            switch (bet.ToString())
            {
                case "First 12":
                case "Second 12":
                case "Third 12":
                    return 3;
                case "First Line":
                case "Second Line":
                case "Third Line":
                    return 3;
                case "1 to 18":
                case "19 to 36":
                case "Even":
                case "Odd":
                case "Only Red":
                case "Only Black":
                    return 2;
                case "0 Green":
                    return 35; 
                default:
                    return 35;
            }
        }

    }
}

