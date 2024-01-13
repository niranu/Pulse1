using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDrawer : MonoBehaviour
{
    MoveObjectController controller;
    MoveableObject moveable;
    int drawNumber;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<MoveObjectController>();
        moveable = GetComponent<MoveableObject>();
        drawNumber = controller.enterNumber;

        
       
    }

    // Update is called once per frame
    void Update()
    {
        if(drawNumber != 7)
        {
            moveable.objectNumber = controller.enterNumber;
            Debug.Log(moveable.objectNumber);
        }
        else  {
            moveable.objectNumber = 1;
            Debug.Log(moveable.objectNumber);
        }
        
    }
}
