using Assets.DataAccess.Classes.Base_Classes;
using Assets.DataAccess.Interfaces.Roullete;
using Assets.DataAccess.Repositories.Roullete;
using Michsky.MUIP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearButtonText : MonoBehaviour
{
    [SerializeField] public List<ButtonManager> buttons;
    IClearButtonUI clearButtonUI;
    IGameSessionManager gameSessionManager;

    public void ClearAllButtonTexts()
    {
        Settings.Balance.setAmount(gameSessionManager.getAllBetsMoney() + Settings.Balance.getAmount());
        clearButtonUI.ClearAllButtonTexts();
    }

    void Start()
    {
        gameSessionManager = new GameSessionManager();
        clearButtonUI = new Assets.DataAccess.Repositories.Roullete.ClearButtonUI(buttons);
        ClearAllButtonTexts();
    }
}
