using System.Collections;
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
    bool _flyMotion = false;

    bool done = true;

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
            FlyTimer();
        }
    }

    private void Update()
    {
        /*if(done)
        {
            cW();
            StartCoroutine(FlyTimer());
            //m_Anim.SetTrigger("Watered 0");
            done = false;
        }*/
        if (_flyMotion)
        {
            transform.parent.Translate(new Vector3(0, 0, -8f * Time.deltaTime));
        }
    }

    void UpdateCounter()
    {
        m_TextMeshPro.text = _HitByIceCubes.ToString();
    }

    protected IEnumerator FlyTimer()
    {
        
        yield return new WaitForSeconds(2f);
        m_Anim.SetTrigger("Watered 0");
        yield return new WaitForSeconds(4f);
        _flyMotion = true;
        yield return new WaitForSeconds(6f);
        _flyMotion = false;
    }
}
