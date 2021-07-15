using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeWallBuilder : MonoBehaviour
{
    [SerializeField]
    private GameObject _cube;
    [SerializeField]
    private GameObject _spawnPoint;

    private int wallWidth = 50;
    private int wallHeigth = 40;

    private float offsetStep = 0.25f;


    public void BuildWall()
    {
        var parent = CreateParent();

        float currentX;
        float currentY = parent.position.y;
        Vector3 currentPosition = parent.position;

        for (int i = 0; i < wallHeigth; i++)
        {
            currentX = parent.position.x - (wallWidth * offsetStep / 2);

            for (int j = 0; j < wallWidth; j++)
            {
                currentPosition.x = currentX;
                Instantiate(_cube, currentPosition, _cube.transform.rotation, parent);
                currentX += offsetStep;
            }

            currentY += offsetStep;
            currentPosition.y = currentY;
        }
    }

    Transform CreateParent()
    {
        GameObject wall = new GameObject();
        wall.AddComponent<Rigidbody>();
        wall.AddComponent<CubeWallMovement>();
        wall.name = "CubeWall";
        wall.transform.position = _spawnPoint.transform.position;
        return wall.transform;
    }
}