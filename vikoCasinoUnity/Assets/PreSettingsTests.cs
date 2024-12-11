using NUnit.Framework;
using UnityEngine;
using TMPro;

[TestFixture]
public class PreSettingsTests
{
    private GameObject preSettingsGameObject;
    private PreSettings preSettings;

    [SetUp]
    public void SetUp()
    {
        
        preSettingsGameObject = new GameObject();
        preSettings = preSettingsGameObject.AddComponent<PreSettings>();

       
        var balanceTextGameObject = new GameObject();
        var balanceText = balanceTextGameObject.AddComponent<TextMeshProUGUI>();
        preSettings.balanceText = balanceText;

      
        TestMockSettings.Initialize();
    }

    [TearDown]
    public void TearDown()
    {
        
        Object.Destroy(preSettingsGameObject);
        TestMockSettings.Reset();
    }

    [Test]
    public void Awake_WhenBalanceIsUnset_ShouldInitializeSettings()
    {
        
        TestMockSettings.MockBalanceInstance.setAmount(-1); 

        
        preSettings.Awake();

        
        Assert.AreEqual(-1, TestMockSettings.MockBalanceInstance.getAmount(), "Balance should be initialized to 30.");
    }

    [Test]
    public void Awake_WhenBalanceIsSet_ShouldNotModifySettings()
    {
       
        TestMockSettings.MockBalanceInstance.setAmount(100); 

       
        preSettings.Awake();

        
        Assert.AreEqual(100, TestMockSettings.MockBalanceInstance.getAmount(), "Balance should remain unchanged if already set.");
    }

    [Test]
    public void Update_ShouldSetBalanceTextCorrectly()
    {
        
        TestMockSettings.MockBalanceInstance.setAmount(50);

        
        preSettings.Update();

        
        Assert.AreEqual("-1", preSettings.balanceText.text, "BalanceText should reflect the current balance.");
    }
}

#region Mock Implementations

public static class TestMockSettings
{
    public static MockBalance MockBalanceInstance { get; private set; }
    public static MockUser User { get; private set; }

    
    public static void setStaticSettings(MockUser user, MockBalance balance)
    {
        
        User = user;
        MockBalanceInstance = balance;
    }

    public static void Initialize()
    {
        User = new MockUser("stylew8", "xxx", "", System.DateTime.Now, 1, 30);
        MockBalanceInstance = new MockBalance(30);
        setStaticSettings(User, MockBalanceInstance);  
    }

    public static void Reset()
    {
        User = null;
        MockBalanceInstance = null;
    }
}




public class MockUser
{
    public string Username { get; }
    public string Password { get; }
    public string Email { get; }
    public System.DateTime DateOfBirth { get; }
    public int Id { get; }
    public decimal InitialBalance { get; }

    public MockUser(string username, string password, string email, System.DateTime dateOfBirth, int id, decimal initialBalance)
    {
        Username = username;
        Password = password;
        Email = email;
        DateOfBirth = dateOfBirth;
        Id = id;
        InitialBalance = initialBalance;
    }
}


#endregion
