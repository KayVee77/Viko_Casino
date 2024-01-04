using Assets.DataAccess.Classes.SlotMacine;
using Assets.DataAccess.Interfaces.SlotMacine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardCalculator : MonoBehaviour, ICalculateReward
{
    public SymbolMultiplier[] symbolMultipliers;
    public int CalculateReward(List<Sprite> winningSymbols, int betAmount)
    {
        Dictionary<Sprite, int> symbolCounts = new Dictionary<Sprite, int>();
        int totalReward = 0;


        foreach (var symbol in winningSymbols)
        {
            if (symbolCounts.ContainsKey(symbol))
            {
                symbolCounts[symbol]++;
            }
            else
            {
                symbolCounts[symbol] = 1;
            }
        }


        foreach (var symbolCount in symbolCounts)
        {
            foreach (var symbolMultiplier in symbolMultipliers)
            {
                if (symbolCount.Key == symbolMultiplier.symbol)
                {
                    int multiplier = 0;
                    switch (symbolCount.Value)
                    {
                        case 3:
                            multiplier = symbolMultiplier.multiplierForThree;
                            break;
                        case 4:
                            multiplier = symbolMultiplier.multiplierForFour;
                            break;
                        case 5:
                            multiplier = symbolMultiplier.multiplierForFive;
                            break;
                    }

                    totalReward += multiplier * betAmount;
                    break;
                }
            }
        }

        return totalReward;
    }
}
