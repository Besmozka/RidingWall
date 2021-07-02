using GestureRecognizer;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GesturePatternDraw _gestureReference;
    [SerializeField]
    private DrawDetector _drawDetector;
    [SerializeField]
    private PlayerRigsController _player;
    [SerializeField]
    private PlayerRigsController _playerGhost;
    [SerializeField]
    private WallController _wallController;

    public GesturePattern[] patterns;
    private GesturePattern _currentGesturePattern;
    private PlayerPose _playerPose;

    private bool isSuccess = false;


    private void Start()
    {
        _playerPose = _playerGhost.NewPose();
        _playerGhost.playerPose = _playerPose;

        _playerGhost.changePositionSpeed = 20f;

        _currentGesturePattern = GetGesturePattern();
        _gestureReference.pattern = _currentGesturePattern;
    }


    public void OnRecognize(RecognitionResult result)
    {
        if (result != RecognitionResult.Empty)
        {
            if (result.gesture.id == _currentGesturePattern.id)
            {
                Success();
            }
        }
    }

    private void ThrowNewWall()
    {
        _playerGhost.ResetPose();

        _playerPose = _playerGhost.NewPose();
        _playerGhost.playerPose = _playerPose;

        _currentGesturePattern = GetGesturePattern();
        _gestureReference.pattern = _currentGesturePattern;

        _drawDetector.ClearLines();
        _gestureReference.enabled = false;
        _gestureReference.enabled = true;
    }

    private void Success()
    {
        _player.playerPose = _playerPose;
        isSuccess = true;
        _drawDetector.ClearLines();
    }

    private GesturePattern GetGesturePattern()
    {
        return patterns[Random.Range(0, patterns.Length - 1)];
    }
}
