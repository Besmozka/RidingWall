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


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
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

    internal void StopMove()
    {
        _isGrounded = false;
        _rigidbody.velocity = Vector3.zero;
    }
    internal void BackToOrigin(GameObject origin)
    {
        _rigidbody.position = origin.transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpdate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpdate(collision, false);
    }

    private void IsGroundedUpdate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }
}
