using TMPro;
using UnityEngine;

public delegate void CallWatered();

public class Plant : MonoBehaviour
{
    float _HitByIceCubes = 0;
    [SerializeField]float _NeededHits = 10;
    public event CallWatered cW;
    [SerializeField] TextMeshPro m_TextMeshPro;

    private void Start()
    {
        m_TextMeshPro.text = "0";
    }

    public void AddHit()
    {
        _HitByIceCubes++;
        UpdateCounter();
        if (_HitByIceCubes >= _NeededHits) cW();
    }

    void UpdateCounter()
    {
        m_TextMeshPro.text = _HitByIceCubes.ToString();
    }
}
