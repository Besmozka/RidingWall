class Level
{
    private int _levelNumber;
    private int _countWall;
    private int _wallSpeed;

    public int LevelNumber { get => _levelNumber; private set => _levelNumber = value; }
    public int CountWall { get => _countWall; private set => _countWall = value; }
    public int WallSpeed { get => _wallSpeed; set => _wallSpeed = value; }

    public Level()
    {
        _levelNumber = 0;
        _countWall = 5;
        _wallSpeed = 100;
    }

    public void NextLevel()
    {
        _levelNumber++;
        if (_levelNumber % 2 == 0)
        {
            _countWall++;
            _wallSpeed += 5;
        }
    }
}

