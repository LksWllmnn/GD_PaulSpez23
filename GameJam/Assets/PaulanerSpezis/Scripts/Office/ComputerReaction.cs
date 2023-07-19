using UnityEngine;

public class ComputerReaction : MonoBehaviour
{
    [SerializeField]Bin m_Bin;

    private void Start()
    {
        m_Bin.oRC += HitSthWrong;
        m_Bin.fDC += FiltDestroyed;
    }

    void HitSthWrong(string name)
    {
        Debug.Log("Wtf!, That was my " + name);
    }

    void FiltDestroyed(string name)
    {
        Debug.Log("Very Nice!! No one needs " + name);
    }
}
