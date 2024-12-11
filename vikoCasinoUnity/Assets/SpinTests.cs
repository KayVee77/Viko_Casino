using NUnit.Framework;
using UnityEngine;
using System.Collections;

public class SpinTests
{
    public class MockReelController : ReelController
    {
        public int reelStopCount = 0;

 
    }

    public class MockSpin : Spin
    {
        public bool IsSpinning => isSpinning; 

        public void TestStartCoroutine(IEnumerator routine)
        {
            StartCoroutine(routine); 
        }
    }

    private MockSpin spin;
    private MockReelController mockController;

    [SetUp]
    public void SetUp()
    {
        GameObject mockObject = new GameObject();

        mockController = mockObject.AddComponent<MockReelController>();
        spin = mockObject.AddComponent<MockSpin>();
        spin.controller = mockController;
    }



    [Test]
    public void TestStartSpinning_FirstSpin()
    {
        
        spin.firstSpin = true;

       
        spin.StartSpinning();

        
        Assert.IsTrue(spin.IsSpinning, "The first spin should start spinning correctly.");
    }

   

    [Test]
    public void TestMultipleSpinsWithoutStopping()
    {
        
        spin.StartSpinning();

      
        spin.StartSpinning();

        
        Assert.IsTrue(spin.IsSpinning, "A second spin should not start while the first spin is still in progress.");
    }
}
