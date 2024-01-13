using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class PickAnItem : MonoBehaviour{
    private GameObject flashLightOnPlayer; // add the real flashlight as the child of the player
    PickableItem p;
    public GameObject[] inventory = new GameObject[15];


    MoveObjectController moveObjectController;
    ClosePlayerEntered closePlayerEntered;
    public int totalKey = 7;
    public int keyCount = 0;

    // Start is called before the first frame update
    void Start() {
        flashLightOnPlayer = GameObject.Find("Flashlight");



        moveObjectController = GameObject.Find("PFB_DoorDouble").GetComponent<MoveObjectController>();

        if (moveObjectController == null)
        {
            Debug.LogError("MoveObjectController not found on the PFB_DoorDouble GameObject.");
        }
        closePlayerEntered = GameObject.Find("PFB_DoorDouble").GetComponent<ClosePlayerEntered>();
        if (closePlayerEntered == null)
        {
            Debug.LogError("ClosePlayerEntered not found on the PFB_DoorDouble GameObject.");
        }



    }
    
    private void OnTriggerStay(Collider other) { 

        if (other.gameObject.tag == "Pickable Item"){
            p = other.GetComponent<PickableItem>();
            if (Input.GetKey(KeyCode.F)) {
                Debug.Log("PickableItem is picked");
                addInventory(other.gameObject);
                other.gameObject.SetActive(false);
                
                // add inventory method
                
            }
        }
        else if (other.gameObject.tag == "Flashlight"){
            if (Input.GetKey(KeyCode.F)){
                 other.gameObject.SetActive(false);
                 gameObject.transform.GetChild(1).gameObject.SetActive(true);
                 //addInventory(other.gameObject);
                 Debug.Log("Flashlight is picked");
                 //addInventory(gameObject);
                 // add inventory method
                        
            } 
         }
        else if (other.gameObject.tag == "Key"){
            if (Input.GetKey(KeyCode.F)) {
                p = other.GetComponent<PickableItem>();
                if (Input.GetKey(KeyCode.F)){
                    Debug.Log("Key is picked");
                    addInventory(other.gameObject);
                    other.gameObject.SetActive(false);
                    keyCount++;
                    
                    
                    /*foreach (GameObject item in inventory)
                    {
                        if (item.CompareTag("Key"))
                        {
                            keyCount++;
                        }
                        if (keyCount == totalKey)
                        {
                            moveObjectController.enabled = true;
                        }

                    }
                    keyCount = 0;*/

                    if(keyCount == totalKey)
                    {
                        moveObjectController.enabled = true;
                        Debug.Log("Main door enabled.");
                        closePlayerEntered.enabled = false;
                        Debug.Log("ClosePlayerEntered disabled");
                    }

                    // add inventory method

                }

                

            }
            //check if the key count = key num, if so activate the main door
            
            


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
