using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    [SerializeField] Camera cam;
    public float rayDistance = 10f; // Länge des Rays
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false; // Starte mit dem LineRenderer deaktiviert
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Objekt getroffen
                Debug.Log("Objekt getroffen: " + hit.collider.gameObject.name);
            }

            // Zeige den Ray in der Szene an
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, ray.origin);
            lineRenderer.SetPosition(1, ray.origin + ray.direction * rayDistance);

            // Deaktiviere den LineRenderer nach einer kurzen Verzögerung
            Invoke("DisableLineRenderer", 0.5f);
        }

        
    }

    void DisableLineRenderer()
    {
        lineRenderer.enabled = false;
    }
}
