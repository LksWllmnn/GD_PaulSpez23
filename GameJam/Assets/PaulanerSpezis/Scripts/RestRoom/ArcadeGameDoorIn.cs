using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeGameDoorIn : OpenDoor
{
    protected override void OpenDoorAction()
    {
        Debug.Log("sth happens here");
    }
}
