using System.Collections;
using UnityEngine;

public delegate void CallOpened();

public abstract class OpenDoor : MonoBehaviour
{
    private float timerDuration = 2f;
    bool timerRunning = false;
    public event CallOpened cO;

    bool _opening = false;
    bool _isOpen = false;

    public void Open()
    {
        _opening = true;
        if (!timerRunning)
        {
            StartCoroutine(TimerCoroutine());
        }
        PlayOpenSound();
    }

    public void StopOpen()
    {
        _opening = false;
        _isOpen = true;
        CallOpen();
    }

    public abstract void PlayOpenSound();

    public void CallOpen()
    {
        cO();
    }

    private void Update()
    {
        if(_opening && !_isOpen) OpenDoorAction();
    }

    protected abstract void OpenDoorAction();

    protected IEnumerator TimerCoroutine()
    {
        timerRunning = true;
        yield return new WaitForSeconds(timerDuration);
        StopOpen();
        timerRunning = false;
    }
}
