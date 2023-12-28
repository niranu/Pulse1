using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class PickAnItem : MonoBehaviour{
    private GameObject flashLightOnPlayer; // add the real flashlight as the child of the player
    PickableItem p;
    public GameObject[] inventory = new GameObject[7];

    // Start is called before the first frame update
    void Start() {
        flashLightOnPlayer = GameObject.Find("Flashlight");
        
    }
    
    private void OnTriggerStay(Collider other) { 

        if (other.gameObject.tag == "Pickable Item"){
            p = other.GetComponent<PickableItem>();
            if (Input.GetKey(KeyCode.E)) {
                Debug.Log("PickableItem is picked");
                addInventory(other.gameObject);
                other.gameObject.SetActive(false);
                
                // add inventory method
                
            }
        }
        else if (other.gameObject.tag == "Flashlight"){
            if (Input.GetKey(KeyCode.E)){
                 other.gameObject.SetActive(false);
                 gameObject.transform.GetChild(1).gameObject.SetActive(true);
                 //addInventory(other.gameObject);
                 Debug.Log("Flashlight is picked");
                 //addInventory(gameObject);
                 // add inventory method
                        
            } 
         }
        else if (other.gameObject.tag == "Key"){
            if (Input.GetKey(KeyCode.E)) {
                p = other.GetComponent<PickableItem>();
                if (Input.GetKey(KeyCode.E)){
                    Debug.Log("Key is picked");
                    addInventory(other.gameObject);
                    other.gameObject.SetActive(false);

                    // add inventory method

                }

            }
        }
        
    }
   

    public void addInventory(GameObject item) {
        
        if (item != null) {
            PickableItem pickableItem = item.GetComponent<PickableItem>();
            if (pickableItem != null)
            {
                for (int i = 0; i < inventory.Length; i++)
                {
                    if (inventory[i] == null)
                    {
                        inventory[i] = item;
                        Debug.Log("Item added to inventory at slot " + i);
                        return;
                    }
                }
            }

            
        }
        for (int i = 0; i < inventory.Length; i++)
        {
            Debug.Log(inventory[i]);
        }

    }
    public GameObject[] GetInventory(){
        if (inventory == null)
        {
            Debug.LogError("Inventory is null in PickAnItem script.");
            inventory = new GameObject[7]; // Initialize the array if it's null
        }
        return inventory;
    }
}
