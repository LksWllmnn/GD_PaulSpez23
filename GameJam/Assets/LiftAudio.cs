using System.Collections;
using UnityEngine;

public delegate void DonePlaying(int number);

public class LiftAudio : MonoBehaviour
{
    [SerializeField]AudioSource m_AudioSource;
    public int Count;
    public event DonePlaying dP;
    bool _intervalRunning = false;
    [SerializeField]float m_Interval = 1.2f;
    public int Position;

    public void playAudio()
    {
        if(!_intervalRunning)
        {
            StartCoroutine(ExecuteRepeatedly());
        }
        
    }

    private IEnumerator ExecuteRepeatedly()
    {
        _intervalRunning = true;
        for (int i = 0; i < Count; i++)
        {
            m_AudioSource.Play();
            yield return new WaitForSeconds(m_Interval);
        }
        _intervalRunning = false;
        dP(Position);
    }

}
