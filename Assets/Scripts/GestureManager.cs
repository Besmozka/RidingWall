using GestureRecognizer;
using System;
using UnityEngine;

public class GestureManager : MonoBehaviour
{
    [SerializeField]
    private GesturePatternDraw _gestureReference;
    [SerializeField]
    private DrawDetector _drawDetector;
    [SerializeField]
    private GameObject _winMark;
    [SerializeField]
    private GameObject _failMark;

    public GesturePattern[] patterns;

    internal Action WinEvent;
    internal Action FailEvent;

    private void Start()
    {
        NextGesturePattern();
    }

    public void OnRecognize(RecognitionResult result)
    {
        if (result != RecognitionResult.Empty)
        {
            if (result.gesture.id == _gestureReference.pattern.id)
            {
                WinEvent.Invoke();
                DisplayMark(_winMark);  
            }
            else
            {
                FailEvent.Invoke();
                DisplayMark(_failMark);
            }
        }
    }

    internal void NextGesturePattern()
    {
        _gestureReference.pattern = patterns[UnityEngine.Random.Range(0, patterns.Length - 1)];
        _drawDetector.ClearLines();
        _gestureReference.enabled = false;
        _gestureReference.enabled = true;

        HideMarks();
    }

    private void DisplayMark(GameObject mark)
    {
        mark.SetActive(true);
    }

    private void HideMarks()
    {
        _winMark?.SetActive(false);
        _failMark?.SetActive(false);
    }
}
