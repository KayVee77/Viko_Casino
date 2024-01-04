using Assets.DataAccess.Classes.Base_Classes;
using Assets.DataAccess.Interfaces.SlotMacine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCheck : MonoBehaviour, ILineCheck
{
    public RewardCalculator calculator;
    
    private IGetSymbols GetSymbols;

    public GetSymbols getSymbols;

    public ReelController reelController;

    public void Start()
    {
        getSymbols = FindAnyObjectByType<GetSymbols>();
        GetSymbols = new GetSymbols();
        calculator = FindAnyObjectByType<RewardCalculator>();
        reelController = FindAnyObjectByType<ReelController>();
    }
   
    public void CheckInverseVLineWin(int betAmount)
    {
        for (int length = 5; length >= 3; length--)
        {
            List<Sprite> winningSymbols = getSymbols.GetWinningSymbols(Lines.LineType.InverseV, 0, length);
            if (winningSymbols.Count > 0)
            {
                int reward = calculator.CalculateReward(winningSymbols, betAmount);
                Debug.Log($"Win on inverse V-line of length {length} with reward: {reward}");
                Settings.Balance.setAmount(Settings.Balance.getAmount() + reward);
                return;
            }
        }

        Debug.Log("No win on inverse V-line");
    }

    public void CheckVLineWin(int betAmount)
    {
        for (int length = 5; length >= 3; length--)
        {
            List<Sprite> winningSymbols = getSymbols.GetWinningSymbols(Lines.LineType.VShape, 0, length);
            if (winningSymbols.Count > 0)
            {
                int reward = calculator.CalculateReward(winningSymbols, betAmount);
                Debug.Log($"Win on V-line of length {length} with reward: {reward}");
                Settings.Balance.setAmount(Settings.Balance.getAmount() + reward);
                return;
            }
        }

        Debug.Log("No win on V-line");
    }

    public void CheckWin(int lineIndex, int betAmount)
    {
        List<Sprite> winningSymbols = getSymbols.GetWinningSymbols(Lines.LineType.Horizontal, lineIndex);
        if (winningSymbols.Count > 0)
        {
            int reward = calculator.CalculateReward(winningSymbols, betAmount);
            Debug.Log($"Win on horizontal line with reward: {reward}");
            Settings.Balance.setAmount(Settings.Balance.getAmount() + reward);
        }
        else
        {
            Debug.Log("No win on horizontal line");
        }
    }

    public bool IsInverseVWinningLine(Sprite symbol, int length)
    {
        if (length == 5)
        {
            return GetSymbols.GetSymbolAtPosition(reelController.reels[0], 2) == symbol &&
                   GetSymbols.GetSymbolAtPosition(reelController.reels[1], 1) == symbol &&
                   GetSymbols.GetSymbolAtPosition(reelController.reels[2], 0) == symbol &&
                   GetSymbols.GetSymbolAtPosition(reelController.reels[3], 1) == symbol &&
                   GetSymbols.GetSymbolAtPosition(reelController.reels[4], 2) == symbol;
        }
        else if (length == 4)
        {
            return GetSymbols.GetSymbolAtPosition(reelController.reels[0], 2) == symbol &&
                   GetSymbols.GetSymbolAtPosition(reelController.reels[1], 1) == symbol &&
                   GetSymbols.GetSymbolAtPosition(reelController.reels[2], 0) == symbol &&
                   GetSymbols.GetSymbolAtPosition(reelController.reels[3], 1) == symbol;
        }
        else if (length == 3)
        {
            return GetSymbols.GetSymbolAtPosition(reelController.reels[0], 2) == symbol &&
                   GetSymbols.GetSymbolAtPosition(reelController.reels[1], 1) == symbol &&
                   GetSymbols.GetSymbolAtPosition(reelController.reels[2], 0) == symbol;
        }

        return false;
    }

    public bool IsVWinningLine(Sprite symbol, int length)
    {
        if (length < 3 || length > 5) return false;

        int midReel = (reelController.reels.Length - 1) / 2;
        int lastIndex = length - 1;

        for (int i = 0; i < length; i++)
        {
            int reelIndex, position;

            if (i <= midReel)
            {

                reelIndex = i;
                position = i;
            }
            else
            {

                reelIndex = lastIndex - (i - midReel);
                position = lastIndex - i;
            }

            if (GetSymbols.GetSymbolAtPosition(reelController.reels[reelIndex], position) != symbol)
            {
                return false;
            }
        }

        return true;
    }

    public bool IsWinningLine(Sprite symbol, int line)
    {
        int count = 0;
        for (int reel = 0; reel < reelController.reels.Length; reel++)
        {
            Sprite currentSymbol = GetSymbols.GetSymbolAtPosition(reelController.reels[reel], line);
            if (currentSymbol == symbol)
            {
                count++;
            }
            else
            {
                break;
            }
        }

        return count >= 3;
    }
}
