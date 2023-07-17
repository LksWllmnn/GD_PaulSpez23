using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRiddle : MonoBehaviour
{

    public float moveSpeed = 5f;     
    public float rotationSpeed = 100f;

    private bool _upActive = false;
    private bool _downActive = false;
    private bool _leftActive = false;
    private bool _rightActive = false;

    
    public void ActivateRotation(int direction)
    {
        switch (direction)
        {
            case 0: _upActive = true; break;
            case 1: _downActive = true; break;
            case 2: _leftActive = true; break;
            case 3: _rightActive = true; break;
        }
    }

    public void DeactivateRotation(int direction)
    {
        switch (direction)
        {
            case 0: _upActive = false; break;
            case 1: _downActive = false; break;
            case 2: _leftActive = false; break;
            case 3: _rightActive = false; break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Bewegung nach vorne und hinten
        if (_upActive)
        {
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        }
        else if (_downActive)
        {
            transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
        }

        // Rotation nach links und rechts
        if (_leftActive)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        else if (_rightActive)
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }
    }
}
