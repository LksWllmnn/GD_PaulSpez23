using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftDoor : OpenDoor
{
    protected override void OpenDoorAction()
    {
        Debug.Log("Sth happens here");
    }
}
