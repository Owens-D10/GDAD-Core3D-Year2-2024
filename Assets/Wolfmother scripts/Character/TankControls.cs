using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TankControls : MonoBehaviour
{



    public GameObject Player;
    int isWalkingHash;
    public float horizontalMove;
    public float verticalMove;
    private Vector3 playerInput;
    int isRunningHash;
    public float walkingSpeed = 4f;
    public float runningSpeed = 7f;
    public float movementSpeed;
    Animator animator;
    
    // Update is called once per frame
    private void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }
    void Update()
    {
        bool isWalking =animator.GetBool(isWalkingHash);
        bool isRunning =animator.GetBool(isRunningHash);    
         if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
         {
             
             horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * 150;
             verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
             Player.transform.Rotate(0, horizontalMove, 0);
             Player.transform.Translate(0, 0, verticalMove);
         }
         else
        {
            isWalking = false;
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
