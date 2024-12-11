using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

public class AutoSpinTests : MonoBehaviour
{
    private class TestAutoSpin : MonoBehaviour
    {
        public Coroutine autoSpinCoroutine;
        public bool isAutoSpinRunning;

        public IEnumerator AutoSpinCoroutine()
        {
            isAutoSpinRunning = true;
            while (true)
            {
                yield return null; 
            }
        }

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
    }

    private TestAutoSpin testAutoSpin;

    [SetUp]
    public void SetUp()
    {
        var testGameObject = new GameObject();
        testAutoSpin = testGameObject.AddComponent<TestAutoSpin>();
    }

    [UnityTest]
    public IEnumerator OnAutoSpinButtonClicked_StartsCoroutine()
    {
        
        testAutoSpin.OnAutoSpinButtonClicked();

        
        yield return null;

        // Assert
        Assert.IsTrue(testAutoSpin.isAutoSpinRunning);
        Assert.IsNotNull(testAutoSpin.autoSpinCoroutine);
    }

    [UnityTest]
    public IEnumerator OnAutoSpinButtonClicked_StopsCoroutine()
    {
        
        testAutoSpin.OnAutoSpinButtonClicked();
        yield return null; 

       
        testAutoSpin.OnAutoSpinButtonClicked();

        
        Assert.IsFalse(testAutoSpin.isAutoSpinRunning);
    }
}
