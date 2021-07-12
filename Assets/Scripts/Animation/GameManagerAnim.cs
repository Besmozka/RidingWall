using GestureRecognizer;
using System.Collections;
using UnityEngine;

public class GameManagerAnim : MonoBehaviour
{
    [SerializeField]
    private GesturePatternDraw _gestureReference;
    [SerializeField]
    private DrawDetector _drawDetector;
    [SerializeField]
    private LevelsManager _levelsManager;
    [SerializeField]
    private GameObject _winMark;
    [SerializeField]
    private GameObject _failMark;

    public GesturePattern[] patterns;


    private void Start()
    {
        StartCoroutine(GetGesturePattern());
        _winMark?.SetActive(false);
        _failMark?.SetActive(false);
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
                StartCoroutine(ShowMark(_failMark));
            }
        }
    }

    private void Success()
    {                
        _drawDetector.ClearLines();

        StartCoroutine(GetGesturePattern());
        StartCoroutine(ShowMark(_winMark));
    }

    private IEnumerator GetGesturePattern()
    {
        _gestureReference.pattern = patterns[Random.Range(0, patterns.Length - 1)];
        _drawDetector.ClearLines();
        _gestureReference.enabled = false;
        yield return new WaitForSeconds(1f);
        _gestureReference.enabled = true;
    }

    private IEnumerator ShowMark(GameObject mark)
    {
        mark.SetActive(true);
        yield return new WaitForSeconds(1f);
        mark.SetActive(false);
    }
}
