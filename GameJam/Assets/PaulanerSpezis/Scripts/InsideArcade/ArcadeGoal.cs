using UnityEngine;

public class ArcadeGoal : MonoBehaviour
{
    [SerializeField] Riddle m_Riddle;
    
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("hi there");
        if(other.name == "Ball")
        {
            m_Riddle.Solved();
        }
    }
}
