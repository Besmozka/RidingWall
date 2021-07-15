using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeWallMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private bool _isGrounded;
    public float _speed;


    void Awake()
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
