using System;
using UnityEngine;
using UnityEngine.Events;

public class LevelsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _wallPrefab;

    private Level _level = new Level();

    internal int WallNumber { get; private set; }
    internal Level Level { get => _level; set => _level = value; }


    private WallController CreateNewWall()
    {
        var wall = Instantiate(_wallPrefab, Vector3.zero, _wallPrefab.transform.rotation)
            .GetComponent<WallController>();
        wall.SetSpeed(Level.WallSpeed);
        return wall;
    }

    private void NextStage()
    {
        Level.NextLevel();
        WallNumber = 0;
        if (Level.LevelNumber == 10)
        {
            Level = new Level();
        }
    }

    internal void NextWall()
    {
        WallNumber++;
        if (WallNumber == Level.CountWall)
        {
            NextStage();
        }
        CreateNewWall();
    }
}
