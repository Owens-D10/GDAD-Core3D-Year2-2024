using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    public WeaponMechanics weaponMechanics;
    public GameObject dialogueBox;
    public PlayerStatus playerStatus;
    public bool inRange = false;
    public bool dialogueShowing = false;
    public GameObject itemCamera;
    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
        }
    }

    void Update()
    {
        if (inRange == true && Input.GetButtonDown("ActionButton") && WeaponMechanics.isAiming == false && dialogueShowing == false)
        {
            dialogueBox.SetActive(true);
            Time.timeScale = 0;
            dialogueShowing = true;
            itemCamera.SetActive(true);
            player.SetActive(false);

        }



        else if (dialogueShowing == true && Input.GetButtonDown("ActionButton"))
        {
            dialogueShowing = false;
            Hide();
            itemCamera.SetActive(false);
            player.SetActive(true);
        }

    }

    private void Hide()
    {
        Time.timeScale = 1;

        dialogueBox.SetActive(false);
    }
}
