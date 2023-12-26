using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickAnItem : MonoBehaviour
{
    public GameObject flashLightOnPlayer; // add the real flashlight as the child of the player

    // Start is called before the first frame update
    void Start()
    {
        flashLightOnPlayer.SetActive(false);
    }

    public bool IsFlashLight(GameObject gameObject)
    {
        bool isFlashLight = gameObject.tag == "Flashlight";
        return isFlashLight;
    }

    private void OnTriggerStay(Collider other) //pickable Item's collider
    {
        if (other.gameObject.tag == "Player")
            //is the *other* gambeObject's tag Player
        {
            PickableItem p = gameObject.GetComponent<PickableItem>(); 
            if (p != null)
            {
                
                if (Input.GetKey(KeyCode.E))
                {
                    if (IsFlashLight(gameObject))
                    {
                        PickUpItem(gameObject); 
                        flashLightOnPlayer.SetActive(true);
                        //addInventory(gameObject);
                        // add inventory method
                    }
                    else if (IsFlashLight(gameObject) != true)
                    {
                       PickUpItem(gameObject);
                       print("Item is picked");
                       // add inventory method 
                    }
                }
            }
           /* else
            {
                OnTriggerExit();
            } */
        }
    }

    void PickUpItem(GameObject g)
    {
        g.gameObject.SetActive(false);
        Debug.Log("Item is picked up");
        return;
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}