using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text levelNumber;

    [SerializeField]
    private LevelsManager _levelManager;

    private void Update()
    {
        if (_levelManager.Level.LevelNumber > Convert.ToInt32(levelNumber.text))
        {
            levelNumber.text = _levelManager.Level.LevelNumber.ToString();
        }
    }
}
