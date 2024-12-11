using Assets.DataAccess.Interfaces.SlotMacine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelController : MonoBehaviour, IReelController
{
    private int stoppedReels;
    public GameObject[] reels;
    public Sprite[] symbols;
    private Vector3[] initialPositions;
    protected ILineCheck lineCheck;
    protected IBet betCheck;
    


    public void Start()
    {
        betCheck = FindAnyObjectByType<Bet>();
        lineCheck=  FindAnyObjectByType<LineCheck>();
        foreach (GameObject reel in reels)
        {
            RandomizeReel(reel);
        }
        initialPositions = new Vector3[reels.Length];
        for (int i = 0; i < reels.Length; i++)
        {

            initialPositions[i] = reels[i].transform.position;
        }
    }

    public void StartSpin()
    {
        foreach (GameObject reel in reels)
        {
            reel.GetComponent<Spin>().StartSpinning();
        }
    }
    public void RandomizeReel(GameObject reel)
    {
        foreach (Transform symbol in reel.transform)
        {
            int randomIndex = Random.Range(0, symbols.Length);
            Sprite selectedSprite = symbols[randomIndex];

            Vector3 newPosition = symbol.transform.position;
            newPosition.z = -2;

            symbol.GetComponent<SpriteRenderer>().sprite = selectedSprite;
            symbol.transform.position = newPosition;
        }
    }

    public void ReelStopped()
    {
        stoppedReels++;
        if (stoppedReels == reels.Length)
        {
            lineCheck.CheckWin(0, betCheck.BetCheck());
            lineCheck.CheckWin(1, betCheck.BetCheck());
            lineCheck.CheckWin(2, betCheck.BetCheck());
            lineCheck.CheckVLineWin(betCheck.BetCheck());
            lineCheck.CheckInverseVLineWin(betCheck.BetCheck());
            Spin.isAnyReelSpinning = false;
            Bet.canWeBet = true;
            stoppedReels = 0;

        }
        else
        {
            Spin.isAnyReelSpinning = true;
            Bet.canWeBet = false;
        }
    }

    public void ResetReels()
    {
        for (int i = 0; i < reels.Length; i++)
        {

            reels[i].transform.position = initialPositions[i];

            RandomizeReel(reels[i]);

        }
    }
}
