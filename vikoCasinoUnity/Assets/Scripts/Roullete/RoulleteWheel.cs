using Assets.DataAccess.Classes;
using Assets.DataAccess.Classes.Base_Classes;
using Assets.DataAccess.Interfaces;
using Assets.DataAccess.Interfaces.Roullete;
using Assets.DataAccess.Repositories;
using Assets.DataAccess.Repositories.Roullete;
using DataAccess.Classes;
using Michsky.MUIP;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RoulleteWheel : MonoBehaviour
{
    // Start is called before the first frame update
    public RouletteGame properties;
    public IBetStrategy betStrategy;
    public IRandomNumberOfTurns random;
    public IGameSessionManager betManager;
    public IWinChecker winChecker;
    public INotificationManager notificationManager;
    public IClearButtonUI clearButton;
    [SerializeField] public Michsky.MUIP.NotificationManager myNotification;
    [SerializeField] public Sprite winIcon;
    [SerializeField] public Sprite loseIcon;
    [SerializeField] public List<ButtonManager> buttons;


    public Text winningText;

    public void Start()
    {
        betStrategy = new RouletteDefaultBetStrategy(new BetDataAccessor());
        random = new RandomNumberOfTurns();
        betManager = new GameSessionManager();
        winChecker = new WinChecker(new Combinations(new BetDataAccessor()));
        notificationManager = new NotificationManager(myNotification, this);
        clearButton = new Assets.DataAccess.Repositories.Roullete.ClearButtonUI(buttons);

        properties = new RouletteGame();

        properties.setCanWeTurn(true);
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && properties.getCanWeTurn())
        {
            StartCoroutine(TurnTheWheel());
        }
    }

    public IEnumerator TurnTheWheel()
    {
        winningText.text = "";

        properties.setCanWeTurn(false);
        Settings.GameSession.CanWeBet = false;

        properties.setNumberOfTurns(random.GetNumberOfTurns());

        properties.setSpeed(0.01f);

        float anglePerTurn = 360f / 37;

        for (int i = 0; i < properties.getNumberOfTurns(); i++)
        {
            transform.Rotate(0, 0, anglePerTurn);

            if (i > Mathf.RoundToInt(properties.getNumberOfTurns() * 0.2f))
            {
                properties.setSpeed(0.02f);
            }
            if (i > Mathf.RoundToInt(properties.getNumberOfTurns() * 0.3f))
            {
                properties.setSpeed(0.03f);
            }
            if (i > Mathf.RoundToInt(properties.getNumberOfTurns() * 0.4f))
            {
                properties.setSpeed(0.05f);
            }
            if (i > Mathf.RoundToInt(properties.getNumberOfTurns() * 0.5f))
            {
                properties.setSpeed(0.07f);
            }
            if (i > Mathf.RoundToInt(properties.getNumberOfTurns() * 0.6f))
            {
                properties.setSpeed(0.09f);
            }
            if (i > Mathf.RoundToInt(properties.getNumberOfTurns() * 0.7f))
            {
                properties.setSpeed(0.11f);
            }
            if (i > Mathf.RoundToInt(properties.getNumberOfTurns() * 0.8f))
            {
                properties.setSpeed(0.13f);
            }
            if (i > Mathf.RoundToInt(properties.getNumberOfTurns() * 0.9f))
            {
                properties.setSpeed(0.15f);
            }


            yield return new WaitForSeconds(properties.getSpeed());
        }

        NormalizeWheelRotation();
        float finalAngle = transform.eulerAngles.z;

        RouletteBet winningBet = betStrategy.DetermineWinningBet(finalAngle);
        Settings.GameSession.WonBet = winningBet;

        winningText.text = winningBet.ToString();

        winChecker.CheckWin();

        Settings.Balance.setAmount(Settings.Balance.getAmount() + Settings.GameSession.balanceChange);

        if (Settings.GameSession.balanceChange > 0)
        {
            notificationManager.ShowNotification("Win", Settings.GameSession.balanceChange + " ˆ",winIcon);
        }
        else if (Settings.GameSession.balanceChange - betManager.getAllBetsMoney() < 0)
        {
            notificationManager.ShowNotification("Lose", Settings.GameSession.balanceChange - betManager.getAllBetsMoney() + " ˆ", loseIcon);
        }


        Settings.GameSession = new Assets.DataAccess.Classes.Roullete.GameSession();
        clearButton.ClearAllButtonTexts();

        properties.setCanWeTurn(true);
    }

    public void NormalizeWheelRotation()
    {
        float currentZ = transform.eulerAngles.z % 360;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, currentZ);
    }
}


