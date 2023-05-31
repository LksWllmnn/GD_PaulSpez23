using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    private bool _onWater;
    private Animation _animation;
    private AudioClip _audio;
    private int _line;
    public int _waiting;
    

    #region GetterSetter
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
    public int Waiting
    {
        get { return _waiting; }
        set { _waiting = value; }
    }
    #endregion GetterSetter

    public void PlayAnimation()
    {
    }

    public void DiveDown()
    {
    }

    public void DiveUp()
    {
    }

    public virtual void Interact(bool interact)
    {

    }

    public virtual void CountDown()
    {
        _waiting--;
    }

}
