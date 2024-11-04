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
        if (inRange == true && Input.GetButtonUp("ActionButton") && WeaponMechanics.isAiming == false && dialogueShowing == false)
        {
            dialogueBox.SetActive(true);
            Time.timeScale = 0;
            dialogueShowing = true;
        }



        else if (dialogueShowing == true && Input.GetButtonUp("ActionButton"))
        {
            dialogueShowing = false;
            Hide();
        }

    }

    private void Hide()
    {
        Time.timeScale = 1;

        dialogueBox.SetActive(false);
    }
}
