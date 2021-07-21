using GestureRecognizer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureController : MonoBehaviour
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


    private void Start()
    {
        GetGesturePattern();
        HideMarks();
    }

    public void OnRecognize(RecognitionResult result)
    {
        if (result != RecognitionResult.Empty)
        {
            if (result.gesture.id == _gestureReference.pattern.id)
            {
                Success();
            }
            else
            {
                Fail();
            }
        }
    }

    private void GetGesturePattern()
    {
        _gestureReference.pattern = patterns[Random.Range(0, patterns.Length - 1)];
        _drawDetector.ClearLines();
        _gestureReference.enabled = true;
    }

    private void Success()
    {
        _drawDetector.ClearLines(); //зарефакторить в первый IF
        _winMark.SetActive(true);
    }

    private void Fail()
    {
        _drawDetector.ClearLines();
        _failMark.SetActive(true);
    } 

    private void HideMarks()
    {
        _winMark?.SetActive(false);
        _failMark?.SetActive(false);
    }
}
