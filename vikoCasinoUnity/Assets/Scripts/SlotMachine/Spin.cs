using Assets.DataAccess.Interfaces.SlotMacine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.DataAccess.Interfaces;
using UnityEngine.UI;
using TMPro;

public class Spin : MonoBehaviour, ISpin
{
    //15-8, 13.334-9, 10.915-11, 9.229-13, 8-15
    public float initialSpeed = 5.0f; 
    public float spinTime = 2.0f; 
    public bool isSpinning; 
    public bool firstSpin = true;
    public static bool isAnyReelSpinning = false;
    public ReelController controller;
    


    void Start()
    {
        controller = FindAnyObjectByType<ReelController>();
    }

    public void StartSpinning()
    {
        if (!isSpinning && !isAnyReelSpinning)
        {
            if (firstSpin)
            {
                StartCoroutine(SpinReel());
                firstSpin = false;
            }
            else 
            {
                controller.ResetReels();
                StartCoroutine(SpinReel());
            }
           
        }
    }
    public IEnumerator SpinReel()
    {
       
        isSpinning = true;
        float currentSpeed = initialSpeed;
        float timeSpinning = 0.0f;

        
        while (timeSpinning < spinTime)
        {
            
            currentSpeed = Mathf.Lerp(initialSpeed, 0, timeSpinning / spinTime);
            transform.Translate(Vector3.down * currentSpeed * Time.deltaTime, Space.World);
            timeSpinning += Time.deltaTime;

            yield return null;
        }


        isSpinning = false;
        controller.ReelStopped();
       

    }

    
}
