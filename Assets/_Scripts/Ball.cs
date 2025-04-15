using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    private Rigidbody ballRb;
    [SerializeField] private Vector2Int forceChangeMaxRange;
    private int forceChangeCount;
    private int forceChangeCountMax;
    private void Start()
    {
        Timer.OnSecondPassed += Timer_OnSecondPassed;
    
        ballRb = GetComponent<Rigidbody>();
        forceChangeCountMax = Random.Range(forceChangeMaxRange.x, forceChangeMaxRange.y);
        forceChangeCount = 0;
    }

    private void OnDestroy()
    {
        Timer.OnSecondPassed -= Timer_OnSecondPassed;
    }

    private void Timer_OnSecondPassed(object sender, EventArgs e)
    {
        forceChangeCount++;
        if (forceChangeCount == forceChangeCountMax)
        {
            //ForceChange
            Vector3 forceVector = Random.insideUnitCircle;
            forceVector *= 2f;
            forceVector.z = forceVector.y;
            forceVector.y = 0;
            
            ballRb.AddForce(forceVector, ForceMode.Force);
            ballRb.AddForce(forceVector, ForceMode.VelocityChange);
            Debug.Log("FORCE CHANGED: " + forceVector);
            
            //RerollForceChangeCount
            forceChangeCountMax = Random.Range(forceChangeMaxRange.x, forceChangeMaxRange.y+1);
            Debug.Log("Max = " + forceChangeCountMax);
            forceChangeCount = 0;
        }
    }
}
