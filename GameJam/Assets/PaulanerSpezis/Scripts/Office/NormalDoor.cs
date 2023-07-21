using UnityEngine;

public class NormalDoor : OpenDoor
{
    [SerializeField] GameObject DoorPivot;
    [SerializeField] AudioSource m_DoorSound;

    public override void PlayOpenSound()
    {
        m_DoorSound.Play();
    }

    protected override void OpenDoorAction()
    {
            DoorPivot.transform.Rotate(new Vector3(0, 90f * Time.deltaTime, 0), Space.World);
    }
}
