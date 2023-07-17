using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleButton : MonoBehaviour
{
    [SerializeField] EnumButton _Direction;
    [SerializeField] RotateRiddle _rotateRiddle;
    [SerializeField] Material _NormMat;
    [SerializeField] Material _PushedMat;
    Renderer _Renderer;

    private void Awake()
    {
        _Renderer = GetComponent<Renderer>();
    }
    public void PushedButton()
    {
        this.transform.Translate(new Vector3(0, -0.005f, 0));
        _Renderer.material = _PushedMat;
        _rotateRiddle.ActivateRotation((int)_Direction);
    }
    public void ReleasedButton()
    {
        this.transform.Translate(new Vector3(0, 0.005f, 0));
        _Renderer.material = _NormMat;
        _rotateRiddle.DeactivateRotation((int)_Direction);
    }
}
