using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadMob : Mob
{

    public override void Interact(bool interact)
    {
        if (interact) _waiting = 0;
    }

}
