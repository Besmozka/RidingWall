using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawPen : MonoBehaviour /*IPointerDownHandler*/
{
    private LineRenderer _line;
    private Vector3 lastTouchPosition;
    public Camera camera;
    public Touch touch;


    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
    }

    private void Update()
    {        
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Vector3 touchPos = touch.position;
            if (touchPos != lastTouchPosition)
            {
                lastTouchPosition = touchPos;
                touchPos.z = 3f;
                Vector3 worldPos = camera.ScreenToWorldPoint(touchPos);
                _line.positionCount++;
                _line.SetPosition(_line.positionCount - 1, worldPos);
            }
        }
    }
}
