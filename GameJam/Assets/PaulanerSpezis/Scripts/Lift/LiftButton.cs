using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftButton : MonoBehaviour
{
    [SerializeField] int m_Number;
    [SerializeField] LiftNumbers m_LiftNumbers;
    Renderer m_Renderer;
    [SerializeField] Material m_Material;
    [SerializeField] Material m_HoverMaterial;
    [SerializeField] Material m_PressedMaterial;

    private void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    public void AddNumber()
    {
        transform.Translate(new Vector3(0, -0.05f, 0));
        m_LiftNumbers.AddNumber(m_Number);
        m_Renderer.material = m_PressedMaterial;
    }

    public void ReleaseButton()
    {
        transform.Translate(new Vector3(0, 0.05f, 0));
        m_Renderer.material = m_Material;
    }

    public void HoverButton()
    {
        m_Renderer.material = m_HoverMaterial;
    }

    public void ExitHoverButton()
    {
        m_Renderer.material = m_Material;
    }
}
