using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloseMainDoor : MonoBehaviour
{

    
    private GameObject player;
    public bool playerEnteredHouse = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    

    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player) {
            Debug.Log("Player entered the Door_Object collider");
            playerEnteredHouse = true;
         
        }
    }

}
