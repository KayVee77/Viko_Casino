using Assets.DataAccess.Classes;
using NUnit.Framework;

[TestFixture]
public class RouletteBetTests
{
    [Test]
    public void Constructor_ShouldInitializePropertiesCorrectly()
    {
        
        var expectedColor = RouletteColors.Red;
        var expectedNumber = 7;

       
        var bet = new RouletteBet(expectedColor, expectedNumber);

        
        Assert.AreEqual(expectedColor, bet.Color, "The Color property should be initialized correctly.");
        Assert.AreEqual(expectedNumber, bet.Number, "The Number property should be initialized correctly.");
    }

    [Test]
    public void DefaultConstructor_ShouldInitializePropertiesToDefaults()
    {
        
        var bet = new RouletteBet();

        
        Assert.AreEqual(default(RouletteColors), bet.Color, "The Color property should be set to its default value.");
        Assert.AreEqual(0, bet.Number, "The Number property should be set to its default value.");
        Assert.AreEqual(0, bet.PayoutMultiplier, "The PayoutMultiplier property should be set to its default value.");
    }

    [Test]
    public void ToString_ShouldReturnFormattedString()
    {
        
        var bet = new RouletteBet(RouletteColors.Black, 10);

        
        var result = bet.ToString();

        
        Assert.AreEqual("10 Black", result, "ToString should return the correct formatted string.");
    }

    [Test]
    public void Equals_ShouldReturnTrueForIdenticalBets()
    {
        
        var bet1 = new RouletteBet(RouletteColors.Red, 15);
        var bet2 = new RouletteBet(RouletteColors.Red, 15);

        
        var result = bet1.Equals(bet2);

        
        Assert.IsTrue(result, "Equals should return true for identical bets.");
    }

    [Test]
    public void Equals_ShouldReturnFalseForDifferentBets()
    {
        
        var bet1 = new RouletteBet(RouletteColors.Red, 15);
        var bet2 = new RouletteBet(RouletteColors.Black, 10);

        
        var result = bet1.Equals(bet2);

        
        Assert.IsFalse(result, "Equals should return false for different bets.");
    }

    [Test]
    public void Equals_ShouldReturnFalseForNull()
    {
        
        var bet = new RouletteBet(RouletteColors.Red, 15);

        
        var result = bet.Equals(null);

        
        Assert.IsFalse(result, "Equals should return false when compared with null.");
    }

    [Test]
    public void GetHashCode_ShouldReturnSameValueForIdenticalBets()
    {
        
        var bet1 = new RouletteBet(RouletteColors.Black, 20);
        var bet2 = new RouletteBet(RouletteColors.Black, 20);

        
        var hash1 = bet1.GetHashCode();
        var hash2 = bet2.GetHashCode();

        
        Assert.AreEqual(hash1, hash2, "GetHashCode should return the same value for identical bets.");
    }

    [Test]
    public void GetHashCode_ShouldReturnDifferentValuesForDifferentBets()
    {
       
        var bet1 = new RouletteBet(RouletteColors.Black, 20);
        var bet2 = new RouletteBet(RouletteColors.Red, 10);

        
        var hash1 = bet1.GetHashCode();
        var hash2 = bet2.GetHashCode();

        
        Assert.AreNotEqual(hash1, hash2, "GetHashCode should return different values for different bets.");
    }
}
