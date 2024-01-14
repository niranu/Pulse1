using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRotation : MonoBehaviour
{
    public float rotationSpeed = 1.0f;

    void Update()
    {

        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}