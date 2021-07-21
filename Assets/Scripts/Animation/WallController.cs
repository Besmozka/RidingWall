using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WallController : MonoBehaviour
{
    internal PlayerController playerGhost;
    private GameObject _spawnPoint;
    private Rigidbody _rigidbody;
    private bool _canMove;
    private float _speed;


    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        playerGhost = GetComponentInChildren<PlayerController>();
        _spawnPoint = GameObject.FindGameObjectWithTag("WallSpawnPoint");

        _canMove = false;
    }

    void Update()
    {
        if (_canMove)
        {
            if (_rigidbody.velocity.magnitude <= _speed)
            {
                _rigidbody.AddForce(-transform.forward * _speed, ForceMode.Force);
            }
        }
    }

    public void SetSpeed(int speed) => _speed = speed;

    public void CanMove()
    {
        _canMove = true;
        transform.Translate(_spawnPoint.transform.position);
    }
}
