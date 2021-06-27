using System.Collections;
using System.Collections.Generic;
using GestureRecognizer;
using UnityEngine;
using UnityEngine.UI;

public class GestureOptions : MonoBehaviour
{

    public Dropdown dropdownMin;
    public Dropdown dropdownMax;
    public Dropdown dropdownThreads;
    public Text textTime;

    public DrawDetector[] detectors;

    public Recognizer recognizer;

    public void OnChangeMinMax()
    {
        int min = dropdownMin.value + 1;
        int max = dropdownMax.value + 1;
        foreach (var detector in detectors)
        {
            detector.MinLines = min;
            detector.MaxLines = max;
            detector.ClearLines();
        }
    }
    public void OnChangeThreads()
    {
        int n_threads = dropdownThreads.value + 1;
        recognizer.numberOfThreads = n_threads;
    }

}
