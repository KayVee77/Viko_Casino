using Assets.DataAccess.Classes.Base_Classes;
using Assets.DataAccess.Interfaces.Roullete;
using Assets.DataAccess.Interfaces.SlotMacine;
using Assets.DataAccess.Repositories.Roullete;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class SlotMachine : MonoBehaviour, ISlotMachine
{
    
    public TextMeshProUGUI input;
    public Bet bet;
    public ReelController reelController;
    private IRemoverInvisibleCharacters remover;
  
    private void Start()
    {
        reelController = FindAnyObjectByType<ReelController>();
        bet = FindAnyObjectByType<Bet>();
        remover = new RemoverInvisibleCharacters();
    }

    
    public void Play()
    {
        var x = input.GetParsedText();
        x = remover.RemoveInvisibleCharacters(x);
        if (Bet.canWeBet == true && bet.BetCheck() != -1 && bet.BetCheck() != 0) {
            Settings.Balance.setAmount(Settings.Balance.getAmount() - decimal.Parse(x));
            reelController.StartSpin();
            Bet.canWeBet = false;
            }
    }
   

}
