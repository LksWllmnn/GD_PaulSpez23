using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public delegate void CallOpened();

public class OpenDoor : MonoBehaviour
{
    [SerializeField] GameObject ?DoorPivot;
    //[SerializeField] GameObject NextRoom;
    bool rotateDoor = false;
    bool isOpen = false;
    private float timerDuration = 2f;
    private bool timerRunning = false;
    public event CallOpened cO;

    public void Open()
    {
        rotateDoor = true;
        if (!timerRunning)
        {
            StartCoroutine(TimerCoroutine());
        }
    }

    public void StopOpen()
    {
        rotateDoor = false;
        isOpen = true;
        cO();
        //NextRoom.SetActive(true);
    }



    private void Update()
    {
        OpenDoorAction();
    }

    protected virtual void OpenDoorAction()
    {
        if (rotateDoor && !isOpen)
        {
            DoorPivot.transform.Rotate(new Vector3(0, -90f * Time.deltaTime, 0), Space.World);
        }
    }

    private IEnumerator TimerCoroutine()
    {
        timerRunning = true;
        yield return new WaitForSeconds(timerDuration);
        StopOpen();
        timerRunning = false;
    }
}
