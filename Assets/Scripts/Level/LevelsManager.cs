using System;
using UnityEngine;
using UnityEngine.Events;

public class LevelsManager : MonoBehaviour
{
    private Level _level = new Level();

    internal int WallNumber { get; private set; }
    internal Level Level { get => _level; set => _level = value; }

    private void NextStage()
    {
        Level.NextLevel();
        WallNumber = 0;
        if (Level.LevelNumber == 10)
        {
            Level = new Level();
        }
    }

    internal void NextRound()
    {
        WallNumber++;
        if (WallNumber == Level.CountWall)
        {
            NextStage();
        }
    }
}
