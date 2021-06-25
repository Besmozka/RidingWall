using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private int _force = 5;

    private void OnCollisionEnter(Collision collision)
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (collision.gameObject.tag == "Player")
        {
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(transform.forward * _force, ForceMode.VelocityChange);
        }
    }
}
