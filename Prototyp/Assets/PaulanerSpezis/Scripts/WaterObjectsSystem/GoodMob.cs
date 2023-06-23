using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodMob : Mob
{
    private bool _inUse = false;
    //[SerializeField] Material _normMaterial;
    //[SerializeField] Material _usedMaterial;

    public override void Interact(bool interact)
    {
        if (interact)
        {
            _inUse = true;
            //GetComponent<Renderer>().material = _usedMaterial;
        } else
        {
            _inUse = false;
            //GetComponent<Renderer>().material = _normMaterial;
        }
    }

    public override void CountDown()
    {
        if (!_inUse) _waiting--;
    }
}
