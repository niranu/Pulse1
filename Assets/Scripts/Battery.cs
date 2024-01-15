using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.F))
        {
            if (other.CompareTag("Player"))
            {
                other.gameObject.transform.GetChild(1).gameObject.GetComponent<FlashlightToggle>().BatteryIsAdded();
                Destroy(gameObject);
            }  
        }

    }
}
