using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class LevelsManager : MonoBehaviour
{
    private Level _level;
    private int _animationState;

    private float _delayWall;
    private bool _canCreate;

    [SerializeField]
    private PlayerAnimController _player;
    [SerializeField]
    private PlayerAnimController _playerGhost;
    [SerializeField]
    private GameObject _wallPrefab;
    [SerializeField]
    private Queue<WallController> _wallsArray;

    private BoxCollider _collider;

    public GameObject spawnPoint;


    private void Start()
    {
        _level = new Level();

        _delayWall = 5f;

        _animationState = NextIndexAnimation();
        _playerGhost.NextPose(_animationState);

        _wallsArray = new Queue<WallController>();
        _canCreate = true;
    }

    private void Update()
    {
        if (_canCreate)
        {
            CreateNewWall();
        }
    }

    private void CreateNewWall()
    {
        var wall = Instantiate(_wallPrefab, spawnPoint.transform.position, _wallPrefab.transform.rotation)
            .GetComponent<WallController>();
        _wallsArray.Enqueue(wall);
        _canCreate = false;
    }

    private int NextIndexAnimation()
    {
        return Random.Range(1, 8);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            var wall = _wallsArray.Dequeue();
            wall.StopMove();
            _canCreate = true;
        }
    }
}
