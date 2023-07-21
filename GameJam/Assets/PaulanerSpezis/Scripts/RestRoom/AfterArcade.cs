using System.Collections;
using UnityEngine;

public class AfterArcade : Riddle
{
    public override event CallSolved CS;
    [SerializeField] AudioSource m_AudioSource;

    private void Start()
    {
        StartCoroutine(TimerFunktion());
    }

    public override void Solved()
    {
        CS();
        m_AudioSource.Play();
    }

    private IEnumerator TimerFunktion()
    {
        yield return new WaitForSeconds(1f);
        Solved();
    }
}
