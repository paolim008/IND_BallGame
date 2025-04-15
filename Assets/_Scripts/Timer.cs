using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static event EventHandler OnSecondPassed;
    public static event EventHandler OnTimerEnd;
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private int timerCountMax;
    private int timerCount;
    private void Start()
    {
        timerCount = timerCountMax;
        timer.text = timerCount.ToString();
        InvokeRepeating(nameof(DecrementTimer), 1f, 1f);
    }

    private void DecrementTimer()
    {
        timerCount--;
        timer.text = timerCount.ToString();
        OnSecondPassed?.Invoke(this, EventArgs.Empty);
        
        if(timerCount == 0)
            OnTimerEnd?.Invoke(this, EventArgs.Empty);
    }
}
