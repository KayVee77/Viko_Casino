using Assets.DataAccess.Interfaces.Roullete;
using DataAccess.Classes;
using NUnit.Framework;
using TMPro;

[TestFixture]
public class BetTests
{
    private Bet _bet;
    private MockTextMeshProUGUI _mockBetText;
    private MockRemoverInvisibleCharacters _mockRemover;
    private MockBalance _mockBalance;

    [SetUp]
    public void SetUp()
    {
        
        _mockBetText = new MockTextMeshProUGUI();
        _mockRemover = new MockRemoverInvisibleCharacters();
        _mockBalance = new MockBalance();

        _bet = new Bet
        {
            bet = _mockBetText  
        };

        
        _bet.GetType().GetField("remover", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(_bet, _mockRemover);
    }

    [Test]
    public void BetCheck_ShouldReturnMinusOne_WhenBetTextIsEmpty()
    {
        
        _mockBetText.SetText("");
        _mockRemover.SetRemoveInvisibleCharacters("");

        
        int result = _bet.BetCheck();

        
        Assert.AreEqual(-1, result);
    }

    [Test]
    public void BetCheck_ShouldReturnMinusOne_WhenBetAmountExceedsBalance()
    {
        
        _mockBetText.SetText("500");
        _mockRemover.SetRemoveInvisibleCharacters("500");
        _mockBalance.SetAmount(300);  

        
        int result = _bet.BetCheck();

        
        Assert.AreEqual(-1, result);
    }



    

    public class MockTextMeshProUGUI : TextMeshProUGUI
    {
        private string _text;

        public void SetText(string text)
        {
            _text = text;
        }

        public override string GetParsedText()
        {
            return _text;
        }
    }

    public class MockRemoverInvisibleCharacters : IRemoverInvisibleCharacters
    {
        private string _removedText;

        public void SetRemoveInvisibleCharacters(string text)
        {
            _removedText = text;
        }

        public string RemoveInvisibleCharacters(string input)
        {
            return _removedText;
        }
    }

    public class MockBalance
    {
        private int _amount;

        public void SetAmount(int amount)
        {
            _amount = amount;
        }

        public int getAmount()
        {
            return _amount;
        }
    }
}
