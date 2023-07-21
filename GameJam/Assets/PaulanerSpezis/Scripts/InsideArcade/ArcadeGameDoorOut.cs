using UnityEngine;

public class ArcadeGameDoorOut : OpenDoor
{
    [SerializeField] AudioSource m_AudioSource;
    public override void PlayOpenSound()
    {
        m_AudioSource.Play();
    }

    protected override void OpenDoorAction()
    {
        Debug.Log("sth happens here");
    }
}
