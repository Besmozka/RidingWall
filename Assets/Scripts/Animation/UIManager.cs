using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text levelNumber;
    public Text wallNumber;

    [SerializeField]
    private LevelsManager _levelManager;

    private void Update()
    {
        if (_levelManager.Level.LevelNumber > Convert.ToInt32(levelNumber.text))
        {
            levelNumber.text = _levelManager.Level.LevelNumber.ToString();
            wallNumber.text = "0";
        }
        if (_levelManager.WallNumber > Convert.ToInt32(wallNumber.text))
        {
            wallNumber.text = _levelManager.WallNumber.ToString();
        }
    }
}
