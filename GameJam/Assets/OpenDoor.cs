using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]GameObject DoorPivot;
    [SerializeField] GameObject NextRoom;
    bool rotateDoor = false;
    bool isOpen = false;
    private float timerDuration = 2f;
    private bool timerRunning = false;

    public void Open()
    {
        rotateDoor = true;
        if (!timerRunning)
        {
            StartCoroutine(TimerCoroutine());
        }
        Debug.Log("Clicked");
    }

    public void StopOpen()
    {
        rotateDoor = false;
        isOpen = true;
        Debug.Log("Door Stop");
        NextRoom.SetActive(true);

    }



    private void Update()
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
