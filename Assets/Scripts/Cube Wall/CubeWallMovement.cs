using UnityEngine;

public class CubeWallMovement : MonoBehaviour
{
    public float _speed = 1;


    void Update()
    {
        transform.Translate(transform.forward * _speed * Time.fixedDeltaTime);
    }
}
