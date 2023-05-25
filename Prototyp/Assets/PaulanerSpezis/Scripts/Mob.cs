using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    private bool _onWater;
    private Animation _animation;
    private AudioClip _audio;
    private int _line;

    public bool OnWater
    {
        get { return _onWater; }
        set { _onWater = value; }
    }

    public Animation Animation
    {
        get { return _animation; }
        set { _animation = value; }
    }

    public AudioClip Audio
    {
        get { return _audio; }
        set { _audio = value; }
    }

    public int Line
    {
        get { return _line; }
        set { _line = value; }
    }

    public void PlayAnimation()
    {
    }

    public void DiveDown()
    {
    }

    public void DiveUp()
    {
    }

    public virtual void Interact()
    {

    }

}
