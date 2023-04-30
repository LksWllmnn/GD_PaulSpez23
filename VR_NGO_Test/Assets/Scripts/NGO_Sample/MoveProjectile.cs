using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    private float _projectileSpeed = 15f;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = transform.forward * _projectileSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collidet");
        Destroy(gameObject);
    }
}
