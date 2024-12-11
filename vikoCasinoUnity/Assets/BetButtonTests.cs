using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Linq;
using Assets.DataAccess.Classes.Roullete;
using Assets.DataAccess.Classes;
using Michsky.MUIP;

[TestFixture]
public class BetButtonTests
{
    private GameObject betButtonGameObject;
    private BetButton betButton;

    private MockButtonManager mockButtonManager;
    private MockNotificationManager mockNotificationManager;
    private MockRemoverInvisibleCharacters mockRemover;
    private MockGameSessionManager mockGameSessionManager;

    [SetUp]
    public void SetUp()
    {
        
        betButtonGameObject = new GameObject();
        betButton = betButtonGameObject.AddComponent<BetButton>();

        
        var buttonGameObject = new GameObject();
        mockButtonManager = buttonGameObject.AddComponent<MockButtonManager>();

        
        betButton.button = mockButtonManager;

        mockNotificationManager = new MockNotificationManager();
        mockRemover = new MockRemoverInvisibleCharacters();
        mockGameSessionManager = new MockGameSessionManager();

        
        betButton.input = new GameObject().AddComponent<TextMeshProUGUI>();
        betButton.input.text = "10 ˆ";

        
        typeof(BetButton).GetField("remover", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(betButton, mockRemover);
        typeof(BetButton).GetField("betManager", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(betButton, mockGameSessionManager);
        typeof(BetButton).GetField("notificationManager", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(betButton, mockNotificationManager);

        
        typeof(BetButton).GetField("myNotification", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(betButton, new MockNotificationUI());

        
        MockSettings.GameSession = new MockGameSession();
        MockSettings.Balance = new MockBalance(100);
    }

    [TearDown]
    public void TearDown()
    {
        GameObject.Destroy(betButtonGameObject);
    }

    [Test]
    public void OnButtonClick_WhenBalanceIsInsufficient_ShowsNotification()
    {
        
        MockSettings.Balance.setAmount(5); 
        betButton.input.text = "10 ˆ";

        
        betButton.OnButtonClick();

       
        Assert.AreEqual("Error", mockNotificationManager.LastTitle);
        Assert.AreEqual("You cannot bet more than you have in balance.", mockNotificationManager.LastMessage);
    }

    [Test]
    public void OnButtonClick_WhenValidBet_AddsBetAndUpdatesBalance()
    {
        
        MockSettings.Balance.setAmount(100);
        betButton.input.text = "10 ˆ";

        
        betButton.OnButtonClick();

        
        Assert.AreEqual(90, MockSettings.Balance.getAmount(), "The balance should be reduced by the bet amount.");
        Assert.AreEqual(1, mockGameSessionManager.UserBets.Count, "A valid bet should be added to the UserBets list.");
        Assert.AreEqual(10, mockGameSessionManager.UserBets[0].Amount, "Bet amount should match the input value.");
    }

    [Test]
    public void OnButtonClick_WhenButtonTextIsNotEmpty_AppendsBetValue()
    {
        
        MockSettings.Balance.setAmount(100);
        betButton.input.text = "10 ˆ";
        mockButtonManager.buttonText = "20 ˆ";

        
        betButton.OnButtonClick();

        
        Assert.AreEqual("30 ˆ", mockButtonManager.buttonText, "The button text should reflect the updated total bet.");
    }
}

#region Custom Mock Implementations

public class MockButtonManager : ButtonManager
{
    public string buttonText;

    
}

public class MockNotificationUI : Michsky.MUIP.NotificationManager
{
    
}

public class MockNotificationManager : Assets.DataAccess.Interfaces.Roullete.INotificationManager
{
    public string LastTitle { get; private set; }
    public string LastMessage { get; private set; }

    public void ShowNotification(string title, string message)
    {
        LastTitle = title;
        LastMessage = message;
    }

    public void ShowNotification(string title, string desc, Sprite sprite)
    {
        throw new System.NotImplementedException();
    }
}

public class MockRemoverInvisibleCharacters : Assets.DataAccess.Interfaces.Roullete.IRemoverInvisibleCharacters
{
    public string RemoveInvisibleCharacters(string text)
    {
        
        return new string(text.Where(char.IsDigit).ToArray());
    }
}

public class MockGameSessionManager : Assets.DataAccess.Interfaces.Roullete.IGameSessionManager
{
    public List<RouletteUserBets> UserBets { get; private set; } = new List<RouletteUserBets>();

    public void AddUserBet(RouletteUserBets userBet)
    {
        UserBets.Add(userBet);
    }

    public void DeleteAllBets()
    {
        UserBets.Clear();
    }

    public decimal getAllBetsMoney()
    {
        return UserBets.Sum(bet => bet.Amount);
    }

    public void setWonBet(RouletteBet bet)
    {
        
    }
}

public class MockGameSession
{
    public bool CanWeBet { get; set; } = true;
}

public class MockBalance
{
    private decimal amount;

    public MockBalance(decimal initialAmount)
    {
        amount = initialAmount;
    }

    public decimal getAmount()
    {
        return amount;
    }

    public void setAmount(decimal value)
    {
        amount = value;
    }
}

public static class MockSettings
{
    public static MockGameSession GameSession { get; set; }
    public static MockBalance Balance { get; set; }
}

#endregion
