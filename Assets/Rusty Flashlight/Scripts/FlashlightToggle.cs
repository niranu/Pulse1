﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;




public class FlashlightToggle : MonoBehaviour
{
    public GameObject lightGO; // Light gameObject to work with
    public float TotalUsageTime { get; private set; } = 0f;

    private float usageStartTime;
    private bool outOfBattery = false;

    // Use this for initialization
    void Start()
    {
        // Set default off
        lightGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if flashlight is not out of battery
        if (!outOfBattery)
        {
            // Toggle flashlight on key down
            if (Input.GetKeyDown(KeyCode.X))
            {
                ToggleFlashlight();
            }

            // Check if flashlight is on
            if (lightGO.activeSelf)
            {
                // Update total usage time
                TotalUsageTime += Time.deltaTime;

                // Check if total usage time has exceeded 30 seconds
                if (TotalUsageTime > 30f)
                {
                    // Turn off flashlight and mark it as out of battery
                    ToggleFlashlight();
                    outOfBattery = true;
                    Debug.Log("Flashlight is now out of battery");
                }
            }
        }
    }

    void ToggleFlashlight()
    {
        // Toggle light
        lightGO.SetActive(!lightGO.activeSelf);

        // If turning on, start the timer
        if (lightGO.activeSelf)
        {
            usageStartTime = Time.time;
            Debug.Log("Flashlight is now in use");
        }
    }
}