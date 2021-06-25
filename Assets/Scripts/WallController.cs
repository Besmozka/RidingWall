using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WallController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private bool _isGrounded;
    [SerializeField]
    private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGrounded)
        {
            if (_rigidbody.velocity.magnitude <= 10)
            {
                _rigidbody.AddForce(-transform.forward * _speed, ForceMode.Impulse);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }
}
