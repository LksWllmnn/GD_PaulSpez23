using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForGameCapability : MonoBehaviour
{
    [SerializeField] StoryGimics m_StroyGimics;
    [SerializeField] GameObject CubeRiddle;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("sth hit me");
        if(other.name == "Complete XR Origin Set Up")
        {
            if(m_StroyGimics.GrabbedEnergy && m_StroyGimics.GrabbedPizza)
            {
                CubeRiddle.SetActive(true);
            } else if(m_StroyGimics.GrabbedRadish)
            {
                Debug.Log("Ih Radish!!");
            }
        }
    }
}
