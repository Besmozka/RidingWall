using GestureRecognizer;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

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

    private bool _canTry = true;


    private void Start()
    {
        StartCoroutine(GetGesturePattern());
        _winMark?.SetActive(false);
        _failMark?.SetActive(false);
        _levelsManager.WallDestroyEvent += CanTry;
    }

    private void CanTry()
    {
        _canTry = true;
    }

    public void OnRecognize(RecognitionResult result)
    {
        if (result != RecognitionResult.Empty && _canTry)
        {
            if (result.gesture.id == _gestureReference.pattern.id)
            {
                Success();
                _canTry = false;
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

        _levelsManager.PlayerPose();

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
