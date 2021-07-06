using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class LevelsManager : MonoBehaviour
{
    private Level _level;
    public int animationState;

    private float _delayWall;
    private bool _canCreate;

    [SerializeField]
    private GameObject _wallPrefab;

    public GameObject spawnPoint;


    private void Start()
    {
        _level = new Level();

        _delayWall = 5f;

        animationState = NextIndexAnimation();

        _canCreate = true;
    }

    private void Update()
    {
        if (_canCreate)
        {
            CreateNewWall();
        }

        if (_level.LevelNumber == 10)
        {
            EndRound();
            _level = new Level();
        }
    }

    private void EndRound()
    {
        throw new System.NotImplementedException();
    }

    private void CreateNewWall()
    {
        _canCreate = false;
        animationState = NextIndexAnimation();
        var wall = Instantiate(_wallPrefab, spawnPoint.transform.position, _wallPrefab.transform.rotation)
            .GetComponent<WallController>();
        wall.playerGhost.NextPose(animationState);
        wall.SetSpeed(_level.WallSpeed);        
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
