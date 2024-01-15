using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    
    
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
