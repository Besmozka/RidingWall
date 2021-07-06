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

    public GameObject spawnPoint;


    private void Start()
    {
        _level = new Level();

        _delayWall = 5f;

        _animationState = NextIndexAnimation();
        _playerGhost.NextPose(_animationState);

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
        Instantiate(_wallPrefab, spawnPoint.transform.position, _wallPrefab.transform.rotation);
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
            _level.NextLevel();
            Destroy(other.gameObject);
            _canCreate = true;
        }
    }
}
