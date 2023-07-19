using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryGimics : MonoBehaviour
{
    public bool GrabbedPizza = false;
    public bool GrabbedEnergy = false;
    public bool GrabbedRadish = false;

    public void GrabRadish()
    {
        GrabbedRadish = true;
    }
    public void ReleasedRadish()
    {
        GrabbedRadish = false;
    }

    public void GrabPizza()
    {
        GrabbedPizza = true;
    }
    public void ReleasedPizza()
    {
        GrabbedPizza = false;
    }

    public void GrabEnergie()
    {
        GrabbedEnergy = true;
    }
    public void ReleasedEnergie()
    {
        GrabbedEnergy = false;
    }

}
