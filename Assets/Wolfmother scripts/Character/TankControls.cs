using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TankControls : MonoBehaviour
{

    [SerializeField] CharacterController controller;

    [SerializeField] private float playerSpeed = 3f;

    [SerializeField] private float playerRotation = 40f;

    public GameObject Player;
    public bool isWalking;
    public float horizontalMove;
    public float verticalMove;
    private Vector3 playerInput;

    // Update is called once per frame
    void Update()
    {
         if (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) ;
         {
             isWalking = true;
             Player.GetComponent<Animator>().Play("Walk_N");
             horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * 150;
             verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * 4;
             Player.transform.Rotate(0, horizontalMove, 0);
             Player.transform.Translate(0, 0, verticalMove);
         }

       // PlayerMovement();

    }

   /* private void OnMove(InputValue value)
    {
        playerInput = value.Get<Vector3>();
    }

    private void PlayerMovement()
    {
        controller.Move(transform.forward * playerInput.z * playerSpeed * Time.deltaTime);

        transform.Rotate(transform.up, playerRotation * playerInput.y * Time.deltaTime);
    }*/

    
}
