using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WallController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _speed;


    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_rigidbody.velocity.magnitude <= _speed)
        {
            _rigidbody.AddForce(-transform.forward * _speed, ForceMode.Force);
        }
    }

    public void SetSpeed(float speed) => _speed = speed;
}
