using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResizer : MonoBehaviour
{
    private Camera playerCamera;

    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        float aspectRatio = (float)Screen.width / (float)Screen.height;
        playerCamera.fieldOfView = Mathf.Atan(Mathf.Tan(playerCamera.fieldOfView * Mathf.Deg2Rad) / aspectRatio) * Mathf.Rad2Deg;
    }
}
