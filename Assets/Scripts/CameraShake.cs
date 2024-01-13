using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    public void ShakeCamera(float duration, float intensity)
    {
        StartCoroutine(Shake(duration, intensity));
    }

    private IEnumerator Shake(float duration, float intensity)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            Vector3 shakeOffset = Random.insideUnitSphere * intensity;
            transform.localPosition = originalPosition + shakeOffset;

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
