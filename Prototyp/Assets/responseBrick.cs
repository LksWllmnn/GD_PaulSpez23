using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class responseBrick : MonoBehaviour
{


    [SerializeField] Material norm;
    [SerializeField] Material hover;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ZAxis") this.GetComponent<Renderer>().material = hover;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "ZAxis") this.GetComponent<Renderer>().material = hover;
        
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.name == "ZAxis") this.GetComponent<Renderer>().material = norm;

    }
}
