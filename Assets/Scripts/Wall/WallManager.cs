using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField]
    private LevelsManager _levelsManager;
    [SerializeField]
    private GameObject _wallPrefab;
    [SerializeField]
    private GameObject _wallSpawnPoint;
    [SerializeField]
    private PlayerController _playerGhost;

    private WallController _wall;

    private Vector3 _offsetGhostPosition = new Vector3(0, -0.5f, 0);

    internal void CreateNewWall()
    {
        _levelsManager.NextRound();

        _wall = Instantiate(_wallPrefab, _wallSpawnPoint.transform.position, _wallPrefab.transform.rotation)
            .GetComponent<WallController>();
        _wall.SetSpeed(_levelsManager.Level.WallSpeed);

        _playerGhost.transform.parent = _wall.gameObject.transform;
        _playerGhost.transform.position = _wall.transform.position + _offsetGhostPosition;
    }

    internal void DestroyWall()
    {
        _playerGhost.transform.parent = null;
        Destroy(_wall.gameObject);
    }
}
