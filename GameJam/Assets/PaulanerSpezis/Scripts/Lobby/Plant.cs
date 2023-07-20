using TMPro;
using UnityEngine;

public delegate void CallWatered();

public class Plant : MonoBehaviour
{
    float _HitByIceCubes = 0;
    [SerializeField]float _NeededHits = 10;
    public event CallWatered cW;
    [SerializeField] TextMeshPro m_TextMeshPro;
    [SerializeField] Animator m_Anim;
    bool done = false;

    private void Start()
    {
        m_TextMeshPro.text = "0";
        //m_Anim.SetTrigger(0);
    }

    public void AddHit()
    {
        _HitByIceCubes++;
        UpdateCounter();
        if (_HitByIceCubes >= _NeededHits)
        {
            m_TextMeshPro.enabled = false;
            
            cW();
            m_Anim.SetTrigger("Watered 0");
        }
    }

    void UpdateCounter()
    {
        m_TextMeshPro.text = _HitByIceCubes.ToString();
    }
}
