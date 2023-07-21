using UnityEngine;

public class ArcadeGameDoorIn : OpenDoor
{
    [SerializeField] AudioSource m_TeleportSound;
    [SerializeField] GameObject m_ArcadeMachine;

    public override void PlayOpenSound()
    {
        m_TeleportSound.Play();
    }

    protected override void OpenDoorAction()
    {
        m_ArcadeMachine.transform.localScale = new Vector3( m_ArcadeMachine.transform.localScale.x + 2f * Time.deltaTime, m_ArcadeMachine.transform.localScale.y + 2f * Time.deltaTime, m_ArcadeMachine.transform.localScale.z + 2f * Time.deltaTime);
    }
}
