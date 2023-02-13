using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 4, -4);
    public float rotation = 25f;

    private void LateUpdate()
    {
        transform.position = target.position + offset;
        transform.rotation = Quaternion.Euler(rotation, 0, 0);
    }
}
