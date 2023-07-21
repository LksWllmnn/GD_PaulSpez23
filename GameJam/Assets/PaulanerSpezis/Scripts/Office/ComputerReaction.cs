using System.Collections;
using UnityEngine;

public class ComputerReaction : MonoBehaviour
{
    [SerializeField] Bin m_Bin;
    [SerializeField] AudioSource m_Negative;
    [SerializeField] AudioSource m_Positive;
    [SerializeField] AudioSource m_Start;

    private void Start()
    {
        m_Bin.oRC += HitSthWrong;
        m_Bin.fDC += FiltDestroyed;
        StartCoroutine(StartText());
    }

    void HitSthWrong(string name)
    {
        m_Negative.Play();
    }

    void FiltDestroyed(string name)
    {
        m_Positive.Play();
    }

    protected IEnumerator StartText()
    {
        yield return new WaitForSeconds(1f);
        m_Start.Play();
    }
}
