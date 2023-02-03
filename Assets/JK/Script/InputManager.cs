using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [NonSerialized] public Vector3 cameraPoint;
    public void CameraPoint(Vector3 point)
    {
        // 카메라 위치
        point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, -Camera.main.transform.position.z));

        if (Input.GetMouseButtonDown(0))
        {

            Debug.Log(point.ToString());
        }
    }

    private void Update()
    {
        CameraPoint(cameraPoint);

        

    }




}
