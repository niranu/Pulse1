using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickAnItem : MonoBehaviour
{
    private GameObject flashLightOnPlayer; // add the real flashlight as the child of the player

    // Start is called before the first frame update
    void Start()
    {
        flashLightOnPlayer = GameObject.Find("Flashlight");
        
    }
    
    private void OnTriggerStay(Collider other)
    {
        PickableItem p = other.gameObject.GetComponent<PickableItem>();
        
        if (other.gameObject.tag == "Pickable Item")
        {
            if (Input.GetKey(KeyCode.E)) 
            {
                Debug.Log("PickableItem is picked");
                p.addInventory(other.gameObject);
                other.gameObject.SetActive(false);
                //addInventory(gameObject);
                // add inventory method
                
            }
        }
        else if (other.gameObject.tag == "Flashlight")
            {
                if (Input.GetKey(KeyCode.E))
                {
                    other.gameObject.SetActive(false);
                    gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    p.addInventory(other.gameObject);
                    Debug.Log("Flashlight is picked");
                    //addInventory(gameObject);
                    // add inventory method
                        
                } 
            }
        
    }

    // Update is called once per frame
     void Update()
     {
     
     }
}