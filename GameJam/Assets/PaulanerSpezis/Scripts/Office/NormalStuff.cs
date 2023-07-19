using UnityEngine;

public class NormalStuff : Stuff
{
    Vector3 _position;
    Quaternion _orientation;

    private void Start()
    {
        _position = transform.position;
        _orientation = transform.rotation;
    }

    public override void HitBin()
    {
        transform.position = _position;
        transform.rotation = _orientation;
    }
}
