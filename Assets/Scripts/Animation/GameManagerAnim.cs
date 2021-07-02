using GestureRecognizer;
using UnityEngine;

public class GameManagerAnim : MonoBehaviour
{
    [SerializeField]
    private GesturePatternDraw _gestureReference;
    [SerializeField]
    private DrawDetector _drawDetector;
    [SerializeField]
    private LevelsManager _levelsManager;

    public GesturePattern[] patterns;
    private GesturePattern _currentGesturePattern;

    private bool isSuccess = false;


    private void Start()
    {        
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
        _currentGesturePattern = GetGesturePattern();
        _gestureReference.pattern = _currentGesturePattern;

        _drawDetector.ClearLines();
        _gestureReference.enabled = false;
        _gestureReference.enabled = true;
    }

    private void Success()
    {        
        //_player.NextPose(_animationState);
        isSuccess = true;
        _drawDetector.ClearLines();
    }

    private GesturePattern GetGesturePattern()
    {
        return patterns[Random.Range(0, patterns.Length - 1)];
    }
}
