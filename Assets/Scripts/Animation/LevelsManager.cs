
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class LevelsManager : MonoBehaviour
{
    private Level _level;

    private bool _canCreate;

    [SerializeField]
    private GameObject _wallPrefab;
    [SerializeField]
    private PlayerAnimController _player;

    public GameObject spawnPoint;

    internal Level Level { get => _level; set => _level = value; }

    private void Start()
    {
        _player.animation.playAutomatically = false;
        Level = new Level();

        _canCreate = true;
    }

    private void Update()
    {
        if (_canCreate)
        {
            CreateNewWall();
        }

        if (Level.LevelNumber == 10)
        {
            EndRound();
            Level = new Level();
        }
    }

    private void EndRound()
    {

        Debug.Log("EndRound");
    }

    private void CreateNewWall()
    {
        _canCreate = false;
        var wall = Instantiate(_wallPrefab, spawnPoint.transform.position, _wallPrefab.transform.rotation)
            .GetComponent<WallController>();
        wall.SetSpeed(Level.WallSpeed);

        var nextAnimationIndex = Random.Range(0, _player.AnimationCount);
        wall.playerGhost.NextAnimation(nextAnimationIndex);
        _player.NextAnimation(nextAnimationIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            Level.NextLevel();
            Destroy(other.gameObject);
            _canCreate = true;
        }
    }
}
