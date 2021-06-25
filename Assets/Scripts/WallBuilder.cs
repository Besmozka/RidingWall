using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBuilder : MonoBehaviour
{
    [SerializeField]
    private GameObject cube;
    [SerializeField]
    private Transform wall;

    private int wallWidth = 30;
    private int wallHeigth = 30;

    private float offsetStep = 0.25f;

    private void Start()
    {
        BuildWall();    
    }

    void BuildWall()
    {
        float currentX = this.transform.position.x;
        float currentY = 0f;
        Vector3 currentPosition = new Vector3();
        for (int i = 0; i < wallHeigth; i++)
        {
            for (int j = 0; j < wallWidth; j++)
            {
                currentPosition.x = currentX;
                currentPosition.y = currentY;
                Instantiate(cube, currentPosition, cube.transform.rotation, wall);
                currentX += offsetStep;
            }
            currentY += offsetStep;
            currentX = this.transform.position.x;
        }
    }
}
