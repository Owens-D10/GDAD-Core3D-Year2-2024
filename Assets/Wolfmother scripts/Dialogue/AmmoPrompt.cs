using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEditor.Rendering;


public class AmmoPrompt : MonoBehaviour
{
    public WeaponMechanics weaponMechanics;
    public GameObject dialogueBox;
    public GameObject ammoBox;
    public bool inRange = false;
    public GameObject itemGlint;
    public GameObject itemCamera;
    public GameObject player;
    public AudioSource itemPickup;

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
        if (inRange == true && Input.GetButtonDown("ActionButton") && WeaponMechanics.isAiming == false)
        {
            dialogueBox.SetActive(true);
            Time.timeScale = 0;
            itemGlint.SetActive(false);
            itemCamera.SetActive(true);
            player.SetActive(false);
        }
        
    }

    public void YesButton()
    {
        weaponMechanics.AmmoGain();
        ammoBox.SetActive(false);
        Hide();
        itemCamera.SetActive(false);
        player.SetActive(true);
        itemPickup.Play();
    }

    public void NoButton()
    {

        Hide();
        itemGlint.SetActive(true);
        itemCamera.SetActive(false);
        player.SetActive(true);
    }

    private void Hide()
    {
        Time.timeScale = 1;

        dialogueBox.SetActive(false);
    }
}
