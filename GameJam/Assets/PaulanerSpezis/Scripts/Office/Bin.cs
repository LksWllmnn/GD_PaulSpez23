using System.Collections.Generic;
using TMPro;
using UnityEngine;

public delegate void FilthDestroyCaller(string name);
public delegate void ObjectResetCaller(string name);

public class Bin : MonoBehaviour
{
    [SerializeField] Riddle m_Riddle;
    [SerializeField] List<Filth> m_Filth;
    [SerializeField] TextMeshPro m_TextMeshPro;

    public event FilthDestroyCaller fDC;
    public event ObjectResetCaller oRC;

    private void Start()
    {
        m_TextMeshPro.text = "" + m_Filth.Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Stuff>())
        {
            
            if (other.gameObject.GetComponent<Filth>())
            {
                DeleteFilthFromList(other.gameObject);
                fDC(other.name);
            } else if (other.gameObject.GetComponent<NormalStuff>())
            {
                oRC(other.name);
            }
            other.gameObject.GetComponent<Stuff>().HitBin();
        }
    }

    void DeleteFilthFromList(GameObject go)
    {
        for(int i = 0; i < m_Filth.Count; i++)
        {
            if(go.name == m_Filth[i].name)
            {
                m_Filth.Remove(m_Filth[i]);
                break;
            }
        }
        m_TextMeshPro.text = "" + m_Filth.Count;
        if(m_Filth.Count <= 0) m_Riddle.Solved();
    }
}
