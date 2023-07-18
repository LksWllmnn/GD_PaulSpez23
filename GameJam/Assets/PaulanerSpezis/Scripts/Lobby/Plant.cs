using UnityEngine;

public delegate void CallWatered();

public class Plant : MonoBehaviour
{
    float _HitByIceCubes = 0;
    [SerializeField]float _NeededHits = 10;
    public event CallWatered cW;

    public void AddHit()
    {
        _HitByIceCubes++;
        if (_HitByIceCubes >= _NeededHits) cW();
    }
}
