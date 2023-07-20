using System.Collections;
using UnityEngine;

public class AfterArcade : Riddle
{
    public override event CallSolved CS;

    private void Start()
    {
        StartCoroutine(TimerFunktion());
    }

    public override void Solved()
    {
        CS();
    }

    private IEnumerator TimerFunktion()
    {
        yield return new WaitForSeconds(1f);
        Solved();
    }
}
