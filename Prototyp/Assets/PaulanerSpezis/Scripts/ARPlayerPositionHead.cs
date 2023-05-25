using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARPlayerPositionHead : MonoBehaviour
{
    [SerializeField] Transform _camTransform;


    // Update is called once per frame
    void Update()
    {
        this.transform.position = _camTransform.position;
        this.transform.rotation = _camTransform.rotation;
    }
}
