using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class LevelsManager : MonoBehaviour
{
    
    private Level _level;

    private bool _canCreate;

    [SerializeField]
    private GameObject _wallPrefab;
    [SerializeField]
    private PlayerAnimController _player;
    [SerializeField]
    private CubeWallBuilder _cubeWallBuilder;

    public GameObject spawnPoint;

    public UnityAction WallDestroyEvent;
    public UnityAction EndRoundEvent;

    internal int WallNumber { get; private set; }
    internal Level Level { get => _level; set => _level = value; }
    public bool CanCreate { get => _canCreate; private set => _canCreate = value; }


    private void Start()
    {
        _player.animation.playAutomatically = false;
        Level = new Level();

        CanCreate = true;
    }

    private void Update()
    {
        if (CanCreate)
        {
            WallController wall = CreateNewWall();
            SetNextAnimation(wall);
            CanCreate = false;
        }
    }

    private void EndRound()
    {
        EndRoundEvent.Invoke();
    }

    private WallController CreateNewWall()
    {
        var wall = Instantiate(_wallPrefab, spawnPoint.transform.position, _wallPrefab.transform.rotation)
            .GetComponent<WallController>();
        wall.SetSpeed(Level.WallSpeed);
        return wall;
    }

    private void SetNextAnimation(WallController wall)
    {
        var nextAnimationIndex = Random.Range(0, _player.AnimationCount);
        var animationTime = Random.Range(0.5f, 1.5f);
        wall.playerGhost.NextAnimation(nextAnimationIndex, animationTime);
        wall.playerGhost.NextPose();
        _player.NextAnimation(nextAnimationIndex, animationTime);
    }

    public void PlayerPose()
    {
        _player.NextPose();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            WallNumber++;
            if (WallNumber == Level.CountWall)
            {
                Level.NextLevel();
                WallNumber = 0;
            }
            if (Level.LevelNumber == 10)
            {
                EndRound();
                Level = new Level();
            }
            else
            {
                CanCreate = true;
            }

            Destroy(other.gameObject);
            WallDestroyEvent.Invoke();
        }
    }
}
