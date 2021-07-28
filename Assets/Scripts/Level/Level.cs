class Level
{
    private int _levelNumber;
    private int _countWall;
    private float _wallSpeed;

    public int LevelNumber { get => _levelNumber; private set => _levelNumber = value; }
    public int CountWall { get => _countWall; private set => _countWall = value; }
    public float WallSpeed { get => _wallSpeed; set => _wallSpeed = value; }

    public Level()
    {
        _levelNumber = 0;
        _countWall = 4;
        _wallSpeed = 100f;
    }

    public void NextLevel()
    {
        _levelNumber++;
        if (_levelNumber % 2 == 0)
        {
            _countWall++;
            _wallSpeed += 5f;
        }
    }
}

