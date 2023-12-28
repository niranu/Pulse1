/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMainDoor : MonoBehaviour
{

    public int totalKey = 2;
    public int keyCount = 0;

    private MoveObjectController moveObjectController;
    private PickAnItem pickAnItem;
    GameObject[] inventory;

    //if the key number in the inventory that is in the Pick An Item is equal to totalKey
    //then enable moveObjectController

    // Start is called before the first frame update
    void Start(){
        
        pickAnItem = GetComponent<PickAnItem>();

        GameObject doubleDoorObject = GameObject.Find("PFB_DoorDouble");

        if (doubleDoorObject != null)
        {
            moveObjectController = doubleDoorObject.GetComponent<MoveObjectController>();

            if (moveObjectController == null)
            {
                Debug.LogError("MoveObjectController not found on the DoubleDoor GameObject.");
            }
        }
        else
        {
            Debug.LogError("DoubleDoor GameObject not found.");
        }

    }

    // Update is called once per frame
    void Update(){
        inventory = pickAnItem.GetInventory();
        foreach (GameObject item in inventory){
            if (item.CompareTag("Key"))
            {
                keyCount++;
            }
            if(keyCount == totalKey)
            {
                moveObjectController.enabled = true;
            }

        }
        keyCount = 0;

    }
}*/
