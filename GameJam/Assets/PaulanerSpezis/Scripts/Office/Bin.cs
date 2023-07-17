using UnityEngine;

public class Bin : MonoBehaviour
{
    [SerializeField] Riddle m_Riddle;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Interactable Instant Pyramid")
        {
            m_Riddle.Solved();
        }
    }
}
