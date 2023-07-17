using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverStuff : MonoBehaviour
{
    [SerializeField] Material m_Norm;
    [SerializeField] Material m_Hover;
    Renderer m_Renderer;

    private void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    public void Hover()
    {
        m_Renderer.material = m_Hover;
    }

    public void HoverExit()
    {
        m_Renderer.material = m_Norm;
    }
}
