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
    public ParticleSystem itemGlint;
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
            itemGlint.Clear();
            itemCamera.SetActive(true);
            player.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
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
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void NoButton()
    {

        Hide();
        itemGlint.Play();
        itemCamera.SetActive(false);
        player.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Hide()
    {
        Time.timeScale = 1;

        dialogueBox.SetActive(false);
    }
}
