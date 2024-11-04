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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inRange = true;
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
        weaponMechanics.AmmoGain();
        ammoBox.SetActive(false);
        Hide();
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
}
