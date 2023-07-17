using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlant : Riddle
{
    public override event CallSolved CS;

    public override void Solved()
    {
        CS();
    }

    
}
