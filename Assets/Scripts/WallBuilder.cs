using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBuilder : MonoBehaviour
{
    [SerializeField]
    private GameObject _cubePrefab;
    [SerializeField]
    private Transform _parent;

    private int _wallWidth = 30;
    private int _wallHeigth = 30;

    private float _offsetStepX;
    private float _offsetStepY;

    private void Start()
    {
        Vector3 sizeCube = _cubePrefab.GetComponent<Renderer>().bounds.size;
        _offsetStepX = sizeCube.x;
        _offsetStepY = sizeCube.y; 
        BuildWall();
    }

    void BuildWall()
    {
        float currentX = this.transform.position.x;
        float currentY = 0f;
        Vector3 currentPosition = new Vector3();
        for (int i = 0; i < _wallHeigth; i++)
        {
            for (int j = 0; j < _wallWidth; j++)
            {
                currentPosition.x = currentX;
                currentPosition.y = currentY;
                Instantiate(_cubePrefab, currentPosition, _cubePrefab.transform.rotation, _parent);
                currentX += _offsetStepX;
            }
            currentY += _offsetStepY;
            currentX = this.transform.position.x;
        }
    }
}
