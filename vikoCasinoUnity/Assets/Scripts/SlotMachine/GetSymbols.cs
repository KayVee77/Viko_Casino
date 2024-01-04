using Assets.DataAccess.Interfaces.SlotMacine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSymbols : MonoBehaviour, IGetSymbols
{
    public ReelController reelController;

    public LineCheck lineCheck;

   

   
    public void Start()
    {
        lineCheck = FindAnyObjectByType<LineCheck>();
        reelController = FindAnyObjectByType<ReelController>();
    }
    public Sprite GetSymbolAtPosition(GameObject reel, int position)
    {
        int maxPosition = 2;

        if (position < 0 || position > maxPosition)
        {
            Debug.LogError("Position for GetSymbolAtPosition is out of range.");
            return null;
        }
        string[] winningSymbolNames = { "last 1", "last 2", "last 3" };

        if (position < 0 || position >= winningSymbolNames.Length)
        {
            Debug.LogError("Position for GetSymbolAtPosition is out of range.");
            return null;
        }


        Transform symbolTransform = reel.transform.Find(winningSymbolNames[position]);
        if (symbolTransform == null)
        {
            Debug.LogError("Could not find a symbol at the specified position: " + position);
            return null;
        }

        SpriteRenderer spriteRenderer = symbolTransform.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            return spriteRenderer.sprite;
        }
        else
        {
            Debug.LogError("SpriteRenderer not found on the symbol at position: " + position);
            return null;
        }
    }

    public List<Sprite> GetWinningSymbols(Lines.LineType lineType, int lineIndex, int length = 0)
    {
        List<Sprite> winningSymbols = new List<Sprite>();

        switch (lineType)
        {
            case Lines.LineType.Horizontal:
                Sprite firstSymbol = GetSymbolAtPosition(reelController.reels[0], lineIndex);
                if (lineCheck.IsWinningLine(firstSymbol, lineIndex))
                {
                    for (int reel = 0; reel < reelController.reels.Length; reel++)
                    {
                        winningSymbols.Add(GetSymbolAtPosition(reelController.reels[reel], lineIndex));
                    }
                }
                break;

            case Lines.LineType.VShape:
                case Lines.LineType.InverseV:
                Sprite symbol = lineType == Lines.LineType.VShape ? GetSymbolAtPosition(reelController.reels[0], 0) : GetSymbolAtPosition(reelController.reels[0], 2);
                bool isWinning = lineType == Lines.LineType.VShape ? lineCheck.IsVWinningLine(symbol, length) : lineCheck.IsInverseVWinningLine(symbol, length);
                if (isWinning)
                {
                    int midReel = (reelController.reels.Length - 1) / 2;
                    int lastIndex = length - 1;

                    for (int i = 0; i < length; i++)
                    {
                        int reelIndex, position;
                        if (lineType == Lines.LineType.VShape)
                        {
                            reelIndex = i <= midReel ? i : lastIndex - (i - midReel);
                            position = i <= midReel ? i : lastIndex - i;
                        }
                        else
                        {
                            reelIndex = i <= midReel ? i : lastIndex - (i - midReel);
                            position = i <= midReel ? 2 - i : 1 + (i - midReel);
                        }
                        winningSymbols.Add(GetSymbolAtPosition(reelController.reels[reelIndex], position));
                    }
                }
                break;
        }

        return winningSymbols;
    }

}
