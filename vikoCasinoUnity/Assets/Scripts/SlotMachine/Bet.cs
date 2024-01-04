using Assets.DataAccess.Classes.Base_Classes;
using Assets.DataAccess.Interfaces.Roullete;
using Assets.DataAccess.Interfaces.SlotMacine;
using Assets.DataAccess.Repositories.Roullete;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Bet : MonoBehaviour, IBet
{
    public TextMeshProUGUI bet;
    public static bool canWeBet = true;
    private IRemoverInvisibleCharacters remover;

    private void Start()
    {
        remover = new RemoverInvisibleCharacters();
    }

    public int BetCheck()
    {
            var x = bet.GetParsedText();
            x = remover.RemoveInvisibleCharacters(x);
        if (string.IsNullOrEmpty(x)) return -1;

            if (int.Parse(x) > Settings.Balance.getAmount())
            {
                return -1;
            }
            else
            {
                return int.Parse(x);
            }
        
    }
    
}
