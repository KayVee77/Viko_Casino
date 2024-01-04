using Assets.DataAccess.Classes.Base_Classes;
using Assets.DataAccess.Interfaces.DiceGame;
using Assets.DataAccess.Repositories.Dice;
using Assets.DataAccess.Repositories.Roullete;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerDice : MonoBehaviour, IManagerDice
{
    public Dice dice1;
    public Dice dice2;
    private DiceWinChecker winChecker;
    private DicePayout payout;
    public List<TextMeshProUGUI> bets;
    private BetRemover betRemover;

    private int sum = 0;
    private int dice1Value = 0;
    private int dice2Value = 0;
    private int diceRolled = 0;

    private void Start()
    {
        dice1.OnDiceRolled += (value) => HandleDiceRolled(value, 1);
        dice2.OnDiceRolled += (value) => HandleDiceRolled(value, 2);

        winChecker = new DiceWinChecker();
        payout = new DicePayout();
        betRemover = new BetRemover(bets);
    }

    public void HandleDiceRolled(int diceValue, int diceNumber)
    {
        if (diceNumber == 1)
        {
            dice1Value = diceValue;
        }
        else if (diceNumber == 2)
        {
            dice2Value = diceValue;
        }
        Settings.DiceGS.Dices.Add(new Assets.DataAccess.Classes.Dice.Dices(diceValue));

        sum += diceValue;
        diceRolled++;

        if (diceRolled == 2)
        {
            Debug.Log("Dice 1: " + dice1Value + ", Dice 2: " + dice2Value + ", Sum: " + sum);
            sum = 0;
            diceRolled = 0;
            winChecker.CheckWin();
            payout.PayoutMoney();

            wait();

            Settings.DiceGS = new Assets.DataAccess.Classes.Dice.GameSessionDice();
            betRemover.removeBetText();
        }
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(5);
    }
}
