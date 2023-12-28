using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class ClosePlayerEntered : MonoBehaviour{

    public float reachRange = 3.5f;

    private Animator anim;
    private Camera fpsCam;
    private GameObject player;

    private const string animBoolName = "isOpen_Obj_";

    private bool playerEntered;
    private bool showInteractMsg;
    private GUIStyle guiStyle;
    private string msg;

    private int rayLayerMask;

    public bool enteredHouse = false;
    private MoveObjectController moveObjectController;

    public bool openTheDoor = true; 

    //MoveObjectController moveObjectController;


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)     //player has exited trigger
        {
            playerEntered = false;
            //hide interact message as player may not have been looking at object when they left
            showInteractMsg = false;

            enteredHouse = true;
        }
    }




    // Start is called before the first frame update
    void Start(){
        //Initialize moveDrawController if script is enabled.
        player = GameObject.FindGameObjectWithTag("Player");

        fpsCam = Camera.main;
        if (fpsCam == null) //a reference to Camera is required for rayasts
        {
            Debug.LogError("A camera tagged 'MainCamera' is missing.");
        }

        //create AnimatorOverrideController to re-use animationController for sliding draws.
        anim = GetComponent<Animator>();
        anim.enabled = false;  //disable animation states by default.  

        //the layer used to mask raycast for interactable objects only
        LayerMask iRayLM = LayerMask.NameToLayer("InteractRaycast");
        rayLayerMask = 1 << iRayLM.value;

        //setup GUI style settings for user prompts
        //setupGui();

        GameObject myGameObject = gameObject;

        moveObjectController = GetComponent<MoveObjectController>();
        






    }

    // Update is called once per frame
    void Update(){

        MoveableObject moveable = GetComponent<MoveableObject>();
        int myNumber = moveable.objectNumber;

        
        string animBoolNameNum = animBoolName + myNumber.ToString();

        if (enteredHouse){
            anim.enabled = true;
            anim.SetBool(animBoolNameNum, false);
            openTheDoor = false;
            moveObjectController.enabled = false;
        }

        

        

        
        


    }
        
    

    /*private void setupGui()
    {
        guiStyle = new GUIStyle();
        guiStyle.fontSize = 16;
        guiStyle.fontStyle = FontStyle.Bold;
        guiStyle.normal.textColor = Color.white;
        msg = "Press E/Fire1 to Open";
    }*/

    /*private string getGuiMsg(bool isOpen)
    {
        string rtnVal;
        if (isOpen)
        {
            rtnVal = "Press E/Fire1 to Close";
        }
        else
        {
            rtnVal = "Press E/Fire1 to Open";
        }

        return rtnVal;
    }*/

   /* void OnGUI(){
        if (showInteractMsg)  //show on-screen prompts to user for guide.
        {
            GUI.Label(new Rect(50, Screen.height - 50, 200, 50), msg, guiStyle);
        }
    }
    //End of GUI Config --------------
   */

}


