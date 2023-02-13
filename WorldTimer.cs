using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WorldTimer : MonoBehaviour
{
    public float realTimeMinute = 1f;
    public float inGameHour = 1f;

    private float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= realTimeMinute)
        {
            elapsedTime = 0f;
            inGameHour = inGameHour + 1f;
        }
    }
}