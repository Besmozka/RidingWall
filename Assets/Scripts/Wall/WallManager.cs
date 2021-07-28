using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField]
    private LevelsManager _levelsManager;
    [SerializeField]
    private GameObject _wallPrefab;
    [SerializeField]
    private PlayerController _playerGhost;

    private WallController _wall;

    internal void CreateNewWall()
    {
        _levelsManager.NextRound();

        _wall = Instantiate(_wallPrefab, Vector3.zero, _wallPrefab.transform.rotation)
            .GetComponent<WallController>();
        _wall.SetSpeed(_levelsManager.Level.WallSpeed);

        _playerGhost.transform.parent = _wall.gameObject.transform;
    }

    internal void DestroyWall()
    {
        _playerGhost.transform.parent = null;
        Destroy(_wall.gameObject);
    }
}
