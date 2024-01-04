using Assets.DataAccess.Classes;
using Assets.DataAccess.Classes.Base_Classes;
using Assets.DataAccess.Classes.Roullete;
using Assets.DataAccess.Interfaces.Roullete;
using Assets.DataAccess.Repositories.Roullete;
using Michsky.MUIP;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BetButton : MonoBehaviour
{
    [SerializeField]public ButtonManager button;
    [SerializeField] public TextMeshProUGUI input;
    [SerializeField] private Michsky.MUIP.NotificationManager myNotification;

    private IGameSessionManager betManager;
    private RouletteUserBets userBet;
    private INotificationManager notificationManager;
    private IRemoverInvisibleCharacters remover;


    private void Awake()
    {
        remover = new RemoverInvisibleCharacters();
        betManager = new GameSessionManager();
        notificationManager = new NotificationManager(myNotification, this);
    }

    public void OnButtonClick()
    {
        string parsedText = input.GetParsedText();
        string parsedbuttonText = button.buttonText;

        parsedText = remover.RemoveInvisibleCharacters(parsedText).Replace(" ˆ", "");
        parsedbuttonText = remover.RemoveInvisibleCharacters(parsedbuttonText).Replace(" ˆ", "");

        if (!Settings.GameSession.CanWeBet)
        {
            return;
        }
        else if (Settings.Balance.getAmount() < decimal.Parse(parsedText))
        {
            notificationManager.ShowNotification("Error", "You cannot bet more than you have in balance.");
            return;
        }

        if (string.IsNullOrWhiteSpace(parsedText))
        {
            Debug.LogWarning("[OnButtonClick] Parsed text is null or whitespace.");
            return;
        }

        string buttonName = remover.RemoveInvisibleCharacters(button.ToSafeString());

        userBet = new RouletteUserBets(buttonName, int.Parse(parsedText));

        Settings.Balance.setAmount(Settings.Balance.getAmount() - int.Parse(parsedText));
        if (string.IsNullOrWhiteSpace(parsedbuttonText))
        {
            button.buttonText = int.Parse(parsedText) + " ˆ";

            betManager.AddUserBet(userBet);

            button.UpdateUI();
            return;
        }

        betManager.AddUserBet(userBet);

        button.buttonText = (int.Parse(parsedText) + int.Parse(parsedbuttonText)) + " ˆ";

        button.UpdateUI();
    }

}
