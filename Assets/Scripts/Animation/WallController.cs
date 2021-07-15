using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WallController : MonoBehaviour
{
    internal PlayerAnimController playerGhost;
    private Rigidbody _rigidbody;
    private bool _isGrounded;
    private float _speed;


    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        playerGhost = GetComponentInChildren<PlayerAnimController>();
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

    public void SetSpeed(int speed) => _speed = speed;

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
