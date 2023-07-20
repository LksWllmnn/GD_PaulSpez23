using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftDoor : OpenDoor
{
    [SerializeField]GameObject m_LeftWing;
    [SerializeField]GameObject m_RightWing;
    protected override void OpenDoorAction()
    {
        m_LeftWing.transform.Translate(new Vector3(0, 0, 0.5f * Time.deltaTime), Space.World);
        m_RightWing.transform.Translate(new Vector3(0, 0, -0.5f * Time.deltaTime), Space.World);
    }
}
