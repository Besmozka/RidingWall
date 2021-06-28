using GestureRecognizer;
using UnityEngine;

public class GameManagerAnim : MonoBehaviour
{
    [SerializeField]
    private GesturePatternDraw _gestureReference;
    [SerializeField]
    private DrawDetector _drawDetector;
    [SerializeField]
    private PlayerAnimController _player;
    [SerializeField]
    private PlayerAnimController _playerGhost;
    [SerializeField]
    private WallController _wallController;

    public GesturePattern[] patterns;
    private GesturePattern _currentGesturePattern;

    private int _animationState;
    private bool isSuccess = false;


    private void Start()
    {
        _animationState = NextIndexAnimation();
        _playerGhost.NextPose(_animationState);

        _currentGesturePattern = GetGesturePattern();
        _gestureReference.pattern = _currentGesturePattern;

        _wallController.WallInvisible += ThrowNewWall;
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
        _animationState = NextIndexAnimation();
        _playerGhost.NextPose(_animationState);

        _wallController.Back();

        _currentGesturePattern = GetGesturePattern();
        _gestureReference.pattern = _currentGesturePattern;

        _drawDetector.ClearLines();
        _gestureReference.enabled = false;
        _gestureReference.enabled = true;
    }

    private void Success()
    {        
        _player.NextPose(_animationState);
        isSuccess = true;
        _drawDetector.ClearLines();
    }

    private int NextIndexAnimation()
    {
        return Random.Range(1, 8);
    }

    private GesturePattern GetGesturePattern()
    {
        return patterns[Random.Range(0, patterns.Length - 1)];
    }
}
