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
    public PlayerStatus playerStatus;
    public AudioSource footstep;

    // Update is called once per frame
    private void Start()
    {

    }
    void Update()
    {
        if (WeaponMechanics.isAiming == false)
        {


            if (Input.GetButton("Horizontal") && playerStatus.isPaused == false || Input.GetButton("Vertical") && playerStatus.isPaused == false)
            {
                isWalking = true;
                GetComponent<Animator>().SetBool("isWalking", true);
                horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * 150;
                verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
                Player.transform.Rotate(0, horizontalMove, 0);
                Player.transform.Translate(0, 0, verticalMove);
            }
            else
            {
                isWalking = false;
                GetComponent<Animator>().SetBool("isWalking", false);
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

    void Footstep()
    {
        footstep.pitch = UnityEngine.Random.Range(1f, 1.5f);
        footstep.Play();
    }


    
}
