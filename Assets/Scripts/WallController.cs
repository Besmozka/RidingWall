using System;
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

    private Vector3 _beginPosition;

    public Action WallInvisible;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _beginPosition = transform.position;
    }

    void Update()
    {
        if (_isGrounded)
        {
            if (_rigidbody.velocity.magnitude <= _speed)
            {
                _rigidbody.AddForce(-transform.forward * _speed, ForceMode.Force);
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

    internal void Back()
    {
        _isGrounded = false;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.position = _beginPosition;
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }

    private void OnBecameInvisible()
    {
        WallInvisible.Invoke();
    }
}
