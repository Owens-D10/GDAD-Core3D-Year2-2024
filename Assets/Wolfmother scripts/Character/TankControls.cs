using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TankControls : MonoBehaviour
{



    public GameObject Player;
    public bool isWalking;
    public float horizontalMove;
    public float verticalMove;
    private Vector3 playerInput;
    public bool isRunning;
    public float walkingSpeed = 4f;
    public float runningSpeed = 7f;
    public float movementSpeed;
    
    
    // Update is called once per frame
    private void Start()
    {

    }
    void Update()
    {

         if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
         {
            isWalking = true;
            Player.GetComponent<Animator>().Play("Walking");
             horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * 150;
             verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
             Player.transform.Rotate(0, horizontalMove, 0);
             Player.transform.Translate(0, 0, verticalMove);
         }
        else
        {
            isWalking = false;
            Player.GetComponent<Animator>().Play("Idle");
        }

        if (Input.GetButton("Run"))
        {
            isRunning = true;
            movementSpeed = runningSpeed;
        }
        else
        {
            isRunning = false;
            movementSpeed = walkingSpeed;
        }
       

    }


    
}
