﻿class Level
{
    private int _levelNumber;
    private int _countWall;

    public int LevelNumber { get => _levelNumber; private set => _levelNumber = value; }
    public int CountWall { get => _countWall; private set => _countWall = value; }

    public Level()
    {
        _levelNumber = 0;
        _countWall = 5;
    }

    public void NextLevel()
    {
        _levelNumber++;
        if (_levelNumber % 2 == 0)
        {
            _countWall++;
        }
    }
}
