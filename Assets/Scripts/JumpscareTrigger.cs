using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JumpscareTrigger : MonoBehaviour
{
    public GameObject jumpscareObject; // Reference to the jumpscare object (image, model, etc.)
    public AudioClip jumpscareSound;   // Jumpscare sound
    public float shakeDuration = 0.5f;  // Duration of the camera shake
    public float shakeIntensity = 0.1f; // Intensity of the camera shake

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activate the jumpscare object
            if (jumpscareObject != null)
            {
                jumpscareObject.SetActive(true);
            }

            // Play the jumpscare sound
            if (jumpscareSound != null)
            {
                AudioSource.PlayClipAtPoint(jumpscareSound, transform.position);
            }

            // Start camera shake
            Camera.main.GetComponent<CameraShake>().ShakeCamera(shakeDuration, shakeIntensity);
        }
    }
}
