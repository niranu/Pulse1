using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class JumpScareController : MonoBehaviour
{
    public MoveObjectController moveObjectController;
    public CameraShake cameraShake;
    void Update()
    {
        // Check if the doors are open
        if (moveObjectController.isOpen)
        {
            // Trigger jump scare here
            TriggerJumpScare();

            // Optional: You might want to reset the isOpen variable to avoid repeated scares
            moveObjectController.isOpen = false;
        }
    }

    void TriggerJumpScare()
    {
        // Calculate the direction from the monster to the camera
        Vector3 directionToCamera = Camera.main.transform.position - transform.position;

        // Define the speed at which the monster moves
        float jumpSpeed = 500f;

        // Move the monster towards the camera
        transform.Translate(directionToCamera.normalized * jumpSpeed * Time.deltaTime, Space.World);

        // Optional: You can play a scary sound or do other visual effects here

        // After the jump, deactivate the monster GameObject after a delay
        float disappearDelay = 1.0f; // Adjust this according to your needs
        Invoke("DisappearMonster", disappearDelay);
    }

    void DisappearMonster()
    {
        // Deactivate the monster GameObject
        gameObject.SetActive(false);
        Debug.Log("DisappearMonster method is called");
    }
}
