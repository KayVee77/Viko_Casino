using Assets.DataAccess.Classes.Base_Classes;
using Assets.DataAccess.Classes.Dice;
using Assets.DataAccess.Interfaces.DiceGame;
using Assets.DataAccess.Interfaces.Roullete;
using Assets.DataAccess.Interfaces.SlotMacine;
using Assets.DataAccess.Repositories.Dice;
using Assets.DataAccess.Repositories.Roullete;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class DiceButton : MonoBehaviour, IDiceButton
{
    public Dice dice1;
    public Dice dice2;

    private void Start()
    {
    }

    public void OnButtonClick()
    {
        dice1.RollDice();
        dice2.RollDice();
    }
}
