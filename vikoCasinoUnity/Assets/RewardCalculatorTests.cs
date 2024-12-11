using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Assets.DataAccess.Classes.SlotMacine;

public class RewardCalculatorTests
{
    
    public class MockSymbolMultiplier
    {
        public Sprite symbol;
        public int multiplierForThree;
        public int multiplierForFour;
        public int multiplierForFive;

        public MockSymbolMultiplier(Sprite symbol, int multiplierForThree, int multiplierForFour, int multiplierForFive)
        {
            this.symbol = symbol;
            this.multiplierForThree = multiplierForThree;
            this.multiplierForFour = multiplierForFour;
            this.multiplierForFive = multiplierForFive;
        }
    }

    public class MockRewardCalculator : RewardCalculator
    {
        public void SetSymbolMultipliers(MockSymbolMultiplier[] multipliers)
        {
            symbolMultipliers = new SymbolMultiplier[multipliers.Length];
            for (int i = 0; i < multipliers.Length; i++)
            {
                symbolMultipliers[i] = new SymbolMultiplier
                {
                    symbol = multipliers[i].symbol,
                    multiplierForThree = multipliers[i].multiplierForThree,
                    multiplierForFour = multipliers[i].multiplierForFour,
                    multiplierForFive = multipliers[i].multiplierForFive
                };
            }
        }
    }

    private MockRewardCalculator rewardCalculator;
    private Sprite symbol1;
    private Sprite symbol2;
    private Sprite symbol3;

    [SetUp]
    public void SetUp()
    {
        
        Texture2D texture1 = new Texture2D(100, 100);
        Texture2D texture2 = new Texture2D(100, 100);
        Texture2D texture3 = new Texture2D(100, 100);

        
        symbol1 = Sprite.Create(texture1, new Rect(0, 0, 100, 100), Vector2.zero);
        symbol2 = Sprite.Create(texture2, new Rect(0, 0, 100, 100), Vector2.zero);
        symbol3 = Sprite.Create(texture3, new Rect(0, 0, 100, 100), Vector2.zero);

        
        rewardCalculator = new GameObject().AddComponent<MockRewardCalculator>();
    }

    [Test]
    public void TestCalculateReward_ThreeSymbolsMatched()
    {
        
        var multipliers = new MockSymbolMultiplier[]
        {
            new MockSymbolMultiplier(symbol1, 10, 20, 30), 
            new MockSymbolMultiplier(symbol2, 5, 15, 25)  
        };
        rewardCalculator.SetSymbolMultipliers(multipliers);

        var winningSymbols = new List<Sprite> { symbol1, symbol1, symbol1 }; 
        int betAmount = 100;

        
        int reward = rewardCalculator.CalculateReward(winningSymbols, betAmount);

        
        Assert.AreEqual(1000, reward);
    }

    [Test]
    public void TestCalculateReward_FourSymbolsMatched()
    {
        
        var multipliers = new MockSymbolMultiplier[]
        {
            new MockSymbolMultiplier(symbol1, 10, 20, 30), 
            new MockSymbolMultiplier(symbol2, 5, 15, 25)  
        };
        rewardCalculator.SetSymbolMultipliers(multipliers);

        var winningSymbols = new List<Sprite> { symbol1, symbol1, symbol1, symbol1 };
        int betAmount = 100;

        
        int reward = rewardCalculator.CalculateReward(winningSymbols, betAmount);

        
        Assert.AreEqual(2000, reward);
    }

    [Test]
    public void TestCalculateReward_FiveSymbolsMatched()
    {
        
        var multipliers = new MockSymbolMultiplier[]
        {
            new MockSymbolMultiplier(symbol1, 10, 20, 30), 
            new MockSymbolMultiplier(symbol2, 5, 15, 25)  
        };
        rewardCalculator.SetSymbolMultipliers(multipliers);

        var winningSymbols = new List<Sprite> { symbol1, symbol1, symbol1, symbol1, symbol1 };
        int betAmount = 100;

       
        int reward = rewardCalculator.CalculateReward(winningSymbols, betAmount);

        
        Assert.AreEqual(3000, reward);
    }

    [Test]
    public void TestCalculateReward_NoWinningSymbols()
    {
        
        var multipliers = new MockSymbolMultiplier[]
        {
            new MockSymbolMultiplier(symbol1, 10, 20, 30),
            new MockSymbolMultiplier(symbol2, 5, 15, 25)
        };
        rewardCalculator.SetSymbolMultipliers(multipliers);

        var winningSymbols = new List<Sprite> { symbol3, symbol3, symbol3 }; 
        int betAmount = 100;

       
        int reward = rewardCalculator.CalculateReward(winningSymbols, betAmount);

        
        Assert.AreEqual(0, reward);
    }

}
