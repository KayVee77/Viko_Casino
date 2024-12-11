using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class LineCheckTests
{
    private MockLineCheck _mockLineCheck;
    private MockRewardCalculator _mockRewardCalculator;
    private MockGetSymbols _mockGetSymbols;
    private MockReelController _mockReelController;
    private MockBalance _mockBalance;

    [SetUp]
    public void SetUp()
    {
       
        _mockRewardCalculator = new MockRewardCalculator();
        _mockGetSymbols = new MockGetSymbols();
        _mockReelController = new MockReelController();
        _mockBalance = new MockBalance();

        
        _mockLineCheck = new MockLineCheck
        {
            Calculator = _mockRewardCalculator,
            GetSymbols = _mockGetSymbols,
            ReelController = _mockReelController,
            Balance = _mockBalance
        };
    }

    [Test]
    public void CheckInverseVLineWin_ShouldAwardReward_WhenWinningLineFound()
    {
        
        int betAmount = 100;
        _mockGetSymbols.SetWinningSymbols(new List<object> { new object(), new object() }); 
        _mockRewardCalculator.SetReward(200);

        
        _mockLineCheck.CheckInverseVLineWin(betAmount);


        Assert.AreEqual(200, _mockBalance.GetAmount(), "Expected balance to be updated after winning line.");
    }

    [Test]
    public void CheckInverseVLineWin_ShouldNotAwardReward_WhenNoWinningLineFound()
    {
        
        int betAmount = 100;
        _mockGetSymbols.SetWinningSymbols(new List<object>()); 
        
        _mockLineCheck.CheckInverseVLineWin(betAmount);

        
        Assert.AreEqual(0, _mockBalance.GetAmount(), "Expected balance to remain unchanged when no win.");
    }

    [Test]
    public void CheckVLineWin_ShouldAwardReward_WhenWinningLineFound()
    {
       
        int betAmount = 100;
        _mockGetSymbols.SetWinningSymbols(new List<object> { new object(), new object() });
        _mockRewardCalculator.SetReward(300);

        
        _mockLineCheck.CheckVLineWin(betAmount);

        
        Assert.AreEqual(300, _mockBalance.GetAmount(), "Expected balance to be updated after winning line.");
    }

    [Test]
    public void CheckVLineWin_ShouldNotAwardReward_WhenNoWinningLineFound()
    {
       
        int betAmount = 100;
        _mockGetSymbols.SetWinningSymbols(new List<object>()); 

        
        _mockLineCheck.CheckVLineWin(betAmount);

        
        Assert.AreEqual(0, _mockBalance.GetAmount(), "Expected balance to remain unchanged when no win.");
    }

    [Test]
    public void CheckWin_ShouldAwardReward_WhenWinningLineFound()
    {
        
        int betAmount = 100;
        int lineIndex = 0;
        _mockGetSymbols.SetWinningSymbols(new List<object> { new object(), new object() });
        _mockRewardCalculator.SetReward(400);

        
        _mockLineCheck.CheckWin(lineIndex, betAmount);

        
        Assert.AreEqual(400, _mockBalance.GetAmount(), "Expected balance to be updated after winning horizontal line.");
    }

    [Test]
    public void CheckWin_ShouldNotAwardReward_WhenNoWinningLineFound()
    {
        
        int betAmount = 100;
        int lineIndex = 0;
        _mockGetSymbols.SetWinningSymbols(new List<object>()); 

        
        _mockLineCheck.CheckWin(lineIndex, betAmount);

        
        Assert.AreEqual(0, _mockBalance.GetAmount(), "Expected balance to remain unchanged when no win.");
    }

    

    public class MockLineCheck
    {
        public MockRewardCalculator Calculator { get; set; }
        public MockGetSymbols GetSymbols { get; set; }
        public MockReelController ReelController { get; set; }
        public MockBalance Balance { get; set; }

        public void CheckInverseVLineWin(int betAmount)
        {
            List<object> winningSymbols = GetSymbols.GetWinningSymbols(Lines.LineType.InverseV, 0, 3); 
            if (winningSymbols.Count > 0)
            {
                int reward = Calculator.CalculateReward(winningSymbols, betAmount);
                Balance.SetAmount(Balance.GetAmount() + reward);
            }
        }

        public void CheckVLineWin(int betAmount)
        {
            List<object> winningSymbols = GetSymbols.GetWinningSymbols(Lines.LineType.VShape, 0, 3); 
            if (winningSymbols.Count > 0)
            {
                int reward = Calculator.CalculateReward(winningSymbols, betAmount);
                Balance.SetAmount(Balance.GetAmount() + reward);
            }
        }

        public void CheckWin(int lineIndex, int betAmount)
        {
            List<object> winningSymbols = GetSymbols.GetWinningSymbols(Lines.LineType.Horizontal, lineIndex);
            if (winningSymbols.Count > 0)
            {
                int reward = Calculator.CalculateReward(winningSymbols, betAmount);
                Balance.SetAmount(Balance.GetAmount() + reward);
            }
        }
    }

    public class MockRewardCalculator
    {
        private int _reward;

        public void SetReward(int reward)
        {
            _reward = reward;
        }

        public int CalculateReward(List<object> winningSymbols, int betAmount)
        {
            return _reward;
        }
    }

    public class MockGetSymbols
    {
        private List<object> _winningSymbols;

        
        public void SetWinningSymbols(List<object> winningSymbols)
        {
            _winningSymbols = winningSymbols;
        }

        
        public List<object> GetWinningSymbols(Lines.LineType lineType, int lineIndex, int length = 0)
        {
            return _winningSymbols;  
        }
    }


    public class MockReelController
    {
        
    }

 
    public class MockBalance
    {
        private int _amount;

        public int GetAmount()
        {
            return _amount;
        }

        public void SetAmount(int amount)
        {
            _amount = amount;
        }
    }

    public class Lines
    {
        public enum LineType
        {
            Horizontal,
            VShape,
            InverseV
        }
    }
}
