using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float time = 10;
    public bool autoStart = false;

    [Space]
    public UnityEvent onTimeStart;
    public UnityEvent onTimeUp;

    private void Start()
    {
        if (autoStart) StartTimer();
    }

    public void StartTimer()
    {
        StartCoroutine(crStartTimer());
    }

    private IEnumerator crStartTimer()
    {
        if (onTimeStart != null)
            onTimeStart.Invoke();

        yield return new WaitForSeconds(time);

        TimeUp();
    }

    private void TimeUp()
    {
        if (onTimeUp != null)
            onTimeUp.Invoke();
    }

}
