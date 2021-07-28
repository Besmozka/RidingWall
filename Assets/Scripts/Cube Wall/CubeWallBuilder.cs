using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeWallBuilder : MonoBehaviour
{
    [SerializeField]
    private GameObject _cube;
    [SerializeField]
    private GameObject _spawnPoint;

    private int wallWidth = 40;
    private int wallHeigth = 40;

    private float offsetStep = 0.25f;


    public void BuildWall()
    {
        var parent = CreateParent();

        float currentX = parent.position.x - (wallWidth * offsetStep / 2);
        Vector3 currentPosition = parent.position;
        currentPosition.x = currentX;

        for (int i = 0; i < wallHeigth; i++)
        {
            for (int j = 0; j < wallWidth; j++)
            {                
                Instantiate(_cube, currentPosition, _cube.transform.rotation, parent);
                currentPosition.x += offsetStep;
            }
            currentPosition.x = currentX;
            currentPosition.y += offsetStep;
        }
    }

    Transform CreateParent()
    {
        GameObject wall = new GameObject();
        wall.AddComponent<CubeWallMovement>();
        wall.name = "CubeWall";
        wall.transform.position = _spawnPoint.transform.position;
        return wall.transform;
    }
}