using Assets.DataAccess.Interfaces.DiceGame;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour, IDice
{

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    public event Action<int> OnDiceRolled;
    System.Random rnd = new System.Random();
    


    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
    }

   
    public void RollDice()
    {
        StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
        int randomDiceSide = 0;
        int finalSide = 0;

        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = rnd.Next(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            rend.transform.position = new Vector3(rend.transform.position.x, rend.transform.position.y, -2);
            yield return new WaitForSeconds(0.05f);
        }

        finalSide = randomDiceSide + 1;
        OnDiceRolled?.Invoke(finalSide);
    }
}


