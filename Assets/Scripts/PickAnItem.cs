using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class PickAnItem : MonoBehaviour
{
    private GameObject flashLightOnPlayer; // add the real flashlight that will be shown on scene as the child of the player
    PickableItem p;
    public GameObject[] inventory = new GameObject[15];


    MoveObjectController moveObjectController;
    ClosePlayerEntered closePlayerEntered;
    public int totalKey = 2;
    public int keyCount = 0;

    public GameObject anibus;

    // Start is called before the first frame update
    void Start()
    {
        flashLightOnPlayer = GameObject.Find("Flashlight");
        anibus = GameObject.Find("anubis_head");
        anibus.SetActive(false);


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

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Pickable Item")
        {
            p = other.GetComponent<PickableItem>();
            if (Input.GetKey(KeyCode.F))
            {
                Debug.Log("PickableItem is picked");
                addInventory(other.gameObject);
                other.gameObject.SetActive(false);

                // add inventory method   +

            }
        }
        else if (other.gameObject.tag == "Flashlight")
        {
            if (Input.GetKey(KeyCode.F))
            {
                other.gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                //addInventory(other.gameObject);
                Debug.Log("Flashlight is picked");
                //addInventory(gameObject);
                // add inventory method

            }
        }
        else if (other.gameObject.tag == "Key")
        {
            if (Input.GetKey(KeyCode.F))
            {
                //p = other.GetComponent<PickableItem>();
                if (Input.GetKey(KeyCode.F))
                {
                    Debug.Log("Key is picked");
                    addInventory(other.gameObject);
                    other.gameObject.SetActive(false);
                    keyCount++;
                    Debug.Log(keyCount);


                    if (keyCount == totalKey)
                    {
                        moveObjectController.enabled = true;
                        Debug.Log("Main door enabled.");
                        closePlayerEntered.enabled = false;
                        Debug.Log("ClosePlayerEntered disabled");

                        //set trinket active
                        anibus.SetActive(true);


                    }

                    // add inventory method

                }
            }
            //check if the key count = key num, if so activate the main door


        }
         /*else if (other.gameObject.tag == "Battery")
        {
            if (Input.GetKey(KeyCode.F))
            {
                other.gameObject.SetActive(false);
                //gameObject.transform.GetChild(1).gameObject.SetActive(true);
                //addInventory(other.gameObject);
                Debug.Log("Battery is picked");
                Debug.Log("You can use flashlight 30 more secs");

                //*
                // Check if the FlashlightToggle component is found
                FlashlightToggle flashlightToggle = flashLightOnPlayer.GetComponent<FlashlightToggle>();

                if (flashlightToggle != null)
                {
                    flashlightToggle.BatteryIsAdded();
                }
                //NO NEED TO ADD TO INVENTORY SINCE WE ARE USING IT ??
                //

            }

        }*/
    }

    public void addInventory(GameObject item)
    {

        if (item != null)
        {
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

    public GameObject[] GetInventory()
    {
        if (inventory == null)
        {
            Debug.LogError("Inventory is null in PickAnItem script.");
            inventory = new GameObject[7]; // Initialize the array if it's null
        }

        return inventory;
    }
}


