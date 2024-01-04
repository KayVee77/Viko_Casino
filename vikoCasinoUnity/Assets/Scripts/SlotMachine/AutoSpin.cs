using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.DataAccess.Interfaces;
using Assets.DataAccess.Interfaces.SlotMacine;

public class AutoSpin : MonoBehaviour, IAutoSpin
{
    private bool isAutoSpinRunning = false;
    private Coroutine autoSpinCoroutine = null;
    public SlotMachine slotMachine;

    public void OnAutoSpinButtonClicked()
    {
        if (!isAutoSpinRunning)
        {
          
            autoSpinCoroutine = StartCoroutine(AutoSpinCoroutine());
        }
        else
        {
            
            if (autoSpinCoroutine != null)
            {
                StopCoroutine(autoSpinCoroutine);
            }
            isAutoSpinRunning = false;
        }
    }
    IEnumerator AutoSpinCoroutine()
    {
        isAutoSpinRunning = true;
        while (isAutoSpinRunning)
        {
            slotMachine.Play(); 
            yield return new WaitForSeconds(3); 
        }
    }

}
