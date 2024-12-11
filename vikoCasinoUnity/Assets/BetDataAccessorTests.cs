using NUnit.Framework;
using Assets.DataAccess.Classes;
using Assets.DataAccess.Repositories.Roullete;
using System;

[TestFixture]
public class BetDataAccessorTests
{
    private BetDataAccessor betDataAccessor;

    [SetUp]
    public void SetUp()
    {
        
        betDataAccessor = new BetDataAccessor();
    }

 

    [Test]
    public void GetBetByNumber_ShouldReturnCorrectBetForRedOdd()
    {
        
        int number = 3; 

        
        RouletteBet bet = betDataAccessor.GetBetByNumber(number);

        
        Assert.AreEqual(RouletteColors.Red, bet.Color, "The color should be Red.");
        Assert.AreEqual(number, bet.Number, "The bet number should be 3.");
    }

    [Test]
    public void GetBetByNumber_ShouldReturnCorrectBetForBlackEven()
    {
        
        int number = 4; 

        
        RouletteBet bet = betDataAccessor.GetBetByNumber(number);

        
        Assert.AreEqual(RouletteColors.Black, bet.Color, "The color should be Black.");
        Assert.AreEqual(number, bet.Number, "The bet number should be 4.");
    }



    [Test]
    public void GetBetByNumber_ShouldReturnCorrectBetForGreen()
    {
        
        int number = 0; 

        
        RouletteBet bet = betDataAccessor.GetBetByNumber(number);

        
        Assert.AreEqual(RouletteColors.Green, bet.Color, "The color should be Green.");
        Assert.AreEqual(number, bet.Number, "The bet number should be 0.");
    }

    [Test]
    public void GetBetByNumber_ShouldReturnCorrectBetForRedRange1To10()
    {
        
        int number = 1; 

        
        RouletteBet bet = betDataAccessor.GetBetByNumber(number);

        
        Assert.AreEqual(RouletteColors.Red, bet.Color, "The color should be Red.");
        Assert.AreEqual(number, bet.Number, "The bet number should be 1.");
    }

    [Test]
    public void GetBetByNumber_ShouldReturnCorrectBetForBlackRange19To28()
    {
        
        int number = 20; 

        
        RouletteBet bet = betDataAccessor.GetBetByNumber(number);

        
        Assert.AreEqual(RouletteColors.Black, bet.Color, "The color should be Black.");
        Assert.AreEqual(number, bet.Number, "The bet number should be 20.");
    }
}

