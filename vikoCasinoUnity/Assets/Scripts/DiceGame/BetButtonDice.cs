using Assets.DataAccess.Classes.Base_Classes;
using Assets.DataAccess.Interfaces.DiceGame;
using Assets.DataAccess.Interfaces.Roullete;
using Assets.DataAccess.Repositories.Roullete;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BetButtonDice : MonoBehaviour, IBetButtonDice
{
    public TextMeshProUGUI betText;
    public TextMeshProUGUI input;
    public Button button;
    private IRemoverInvisibleCharacters remover;

    void Start()
    {
        remover = new RemoverInvisibleCharacters();
    }

    // Update is called once per frame
    public void OnClick()
    {
        string bet_Text = betText.GetParsedText();
        string input_Text = input.GetParsedText();

        bet_Text = remover.RemoveInvisibleCharacters(bet_Text).Replace(" ˆ","");
        input_Text = remover.RemoveInvisibleCharacters(input_Text).Replace(" ˆ", "");

        if (int.Parse(input_Text) > Settings.Balance.getAmount() || Settings.Balance.getAmount() == 0 || int.Parse(input_Text) == 0)
        {
            return;
        }

        Settings.Balance.setAmount(Settings.Balance.getAmount() - int.Parse(input_Text));

        Settings.DiceGS.UserBets.Add(new Assets.DataAccess.Classes.Dice.DiceUserBets(button.ToSafeString(), int.Parse(input_Text)));

        if (string.IsNullOrWhiteSpace(bet_Text)) 
        {
            betText.text = input_Text + " ˆ";

            return;
        }

        int all = int.Parse(bet_Text) + int.Parse(input_Text);

        betText.text = all.ToString() + " ˆ";
    }
}
