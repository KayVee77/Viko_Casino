using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using System.Collections;

[TestFixture]
public class DiceTests
{
    private Dice dice;
    private GameObject diceGameObject;
    private SpriteRenderer mockSpriteRenderer;

    
    [SetUp]
    public void SetUp()
    {
        
        diceGameObject = new GameObject();
        mockSpriteRenderer = diceGameObject.AddComponent<SpriteRenderer>();

        
        dice = diceGameObject.AddComponent<Dice>();
    }

    [TearDown]
    public void TearDown()
    {
        
        GameObject.Destroy(diceGameObject);
    }



    [UnityTest]
    public IEnumerator RollDice_ChangesSpriteMultipleTimes()
    {
        
        Sprite[] testSprites = new Sprite[6]; 
        for (int i = 0; i < 6; i++)
        {
            
            Texture2D dummyTexture = new Texture2D(100, 100);
            testSprites[i] = Sprite.Create(dummyTexture, new Rect(0, 0, 100, 100), new Vector2(0.5f, 0.5f));
        }

        
        dice.diceSides = testSprites;

        int initialSpriteIndex = mockSpriteRenderer.sprite == null ? -1 : Array.IndexOf(testSprites, mockSpriteRenderer.sprite);

        
        dice.RollDice();

        
        yield return new WaitForSeconds(1f); 

        int newSpriteIndex = Array.IndexOf(testSprites, mockSpriteRenderer.sprite);

        
        Assert.AreNotEqual(initialSpriteIndex, newSpriteIndex, "Sprite should change after rolling.");
    }


}
