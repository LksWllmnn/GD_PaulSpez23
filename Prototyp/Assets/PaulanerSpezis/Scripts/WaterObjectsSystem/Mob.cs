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

    public float duration = 1f; // Duration of the movement in seconds

    private float elapsedTime = 0f;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    public bool isMoving = false;
    

    #region GetterSetter
    private void Start()
    {
        initialPosition = transform.position;
        targetPosition = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z);
    }
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
        isMoving = true;
        elapsedTime = 0f;
        initialPosition = transform.position;
        targetPosition = new Vector3(initialPosition.x, -0.3f, initialPosition.z);
        }

    public void DiveUp()
    {
        isMoving = true;
        elapsedTime = 0f;
        initialPosition = transform.position;
        targetPosition = new Vector3(initialPosition.x, 0, initialPosition.z);
    }
private void Update()
    {
        if (isMoving)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            Vector3 newPosition = Vector3.Lerp(initialPosition, targetPosition, t);
            transform.position = newPosition;
            if (t >= 1f)
            {
                isMoving = false;
            }
        }
    }
    public virtual void Interact(bool interact)
    {

    }

    public virtual void CountDown()
    {
        _waiting--;
    }

}
