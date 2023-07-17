using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeGoal : MonoBehaviour
{
    [SerializeField] Riddle m_Riddle;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Ball")
        {
            m_Riddle.Solved();
        }
    }
}
