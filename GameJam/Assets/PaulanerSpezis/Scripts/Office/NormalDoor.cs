using UnityEngine;

public class NormalDoor : OpenDoor
{
    [SerializeField] GameObject DoorPivot;

    protected override void OpenDoorAction()
    {
            DoorPivot.transform.Rotate(new Vector3(0, 90f * Time.deltaTime, 0), Space.World);
    }
}
