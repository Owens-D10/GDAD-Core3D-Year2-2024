using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfPrompts : MonoBehaviour
{
    public WeaponMechanics weaponMechanics;
    public GameObject dialogueBox;
    public GameObject keyBook;
    public PlayerStatus playerStatus;
    public GameObject promptBox;
    public GameObject bookshelf;
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
        if (inRange == true && Input.GetButtonUp("ActionButton") && WeaponMechanics.isAiming == false && playerStatus.hasBook == false && dialogueShowing == false)
        {
            dialogueBox.SetActive(true);
            Time.timeScale = 0;
            dialogueShowing = true;
            itemCamera.SetActive(true);
            player.SetActive(false);
        }

        else if (inRange == true && Input.GetButtonUp("ActionButton") && WeaponMechanics.isAiming == false && playerStatus.hasBook == true)
        {
            promptBox.SetActive(true);
            Time.timeScale = 0;
            itemCamera.SetActive(true);
            player.SetActive(false);
        }

        else if(dialogueShowing == true && Input.GetButtonDown("ActionButton"))
        {
            dialogueShowing = false;
            HideDialogue();
            itemCamera.SetActive(false);
            player.SetActive(true);
        }

    }


    public void YesButton()
    {
        HidePrompt();
        keyBook.SetActive(true);
        inRange = false;
        bookshelf.GetComponent<Animator>().Play("bookshelf_move");
        itemCamera.SetActive(false);
        player.SetActive(true);
    }

    public void NoButton()
    {

        HidePrompt();
        itemCamera.SetActive(false);
        player.SetActive(true);
    }

    private void HidePrompt()
    {
        Time.timeScale = 1;

        promptBox.SetActive(false);
    }

    private void HideDialogue()
    {
        Time.timeScale = 1;

        dialogueBox.SetActive(false);
    }
}
