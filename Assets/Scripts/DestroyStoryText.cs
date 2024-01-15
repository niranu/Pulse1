using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStoryText : MonoBehaviour
{
    void Update()
    {
        // Check if any key is pressed, excluding mouse clicks
        if (Input.anyKeyDown && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1))
        {
            // Start your game logic here
            Debug.Log("Game Started!");
            // You can add more game initialization logic here

            // Optionally, you can destroy the GameObject this script is attached to
            Destroy(gameObject);
        }
    }
}
