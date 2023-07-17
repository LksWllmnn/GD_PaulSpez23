using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    [SerializeField] OpenDoor Door;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Interactable Instant Pyramid")
        {
            Door.Open();
        }
    }
}
