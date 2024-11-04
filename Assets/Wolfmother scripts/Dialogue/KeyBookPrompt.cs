using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEditor.Rendering;
using Unity.VisualScripting;


public class KeyBookPrompt : MonoBehaviour
{
    public WeaponMechanics weaponMechanics;
    public GameObject dialogueBox;
    public GameObject keyBook;
    public GameObject window;
    public GameObject brokenWindow;
    public AudioSource windowBreak;
    public GameObject wolf1;
    public PlayerStatus playerStatus;
    public bool inRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
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
        if (inRange == true && Input.GetButtonUp("ActionButton") && WeaponMechanics.isAiming == false)
        {
            dialogueBox.SetActive(true);
            Time.timeScale = 0;
        }
    }


    public void YesButton()
    {
        keyBook.SetActive(false);
        Hide();
        BreakWindow();
        playerStatus.hasBook = true;
        inRange = false;
    }

    public void NoButton()
    {

        Hide();
    }

    private void Hide()
    {
        Time.timeScale = 1;

        dialogueBox.SetActive(false);
    }

    void BreakWindow()
    {
        windowBreak.Play();
        window.SetActive(false);
        brokenWindow.SetActive(true);
        wolf1.SetActive(true);

    }
}
