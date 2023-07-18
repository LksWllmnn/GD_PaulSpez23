using System.Collections;
using UnityEngine;

public class DispenserButton : MonoBehaviour
{
    [SerializeField] GameObject IceCube;
    Renderer m_Renderer;
    [SerializeField] WaterPlant m_Riddle;
    [SerializeField] Material m_Material;
    [SerializeField] Material m_HoverMaterial;
    [SerializeField] Material m_PressedMaterial;
    [SerializeField] Transform m_Release;

    bool intervalRunning = false;
    int iterations = 10;
    float interval = 0.5f;

    private void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    public void StartInterval()
    {
        if (!intervalRunning)
        {
            StartCoroutine(ExecuteRepeatedly());
        }
    }

    public void ClickButton()
    {
        transform.Translate(new Vector3(0, -0.05f, 0));
        m_Renderer.material = m_PressedMaterial;
        StartInterval();
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

    private IEnumerator ExecuteRepeatedly()
    {
        intervalRunning = true;
        for (int i = 0; i < iterations; i++)
        {
            GameObject go = Instantiate(IceCube, m_Release.position, m_Release.rotation);
            go.GetComponent<IceCube>().Riddle = m_Riddle;
            yield return new WaitForSeconds(interval);
        }
        intervalRunning = false;
    }
}
