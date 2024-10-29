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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && Input.GetButton("ActionButton") && WeaponMechanics.isAiming == false)
        {
            dialogueBox.SetActive(true);
            Time.timeScale = 0;
        }

    }

    public void YesButton()
    {
        Time.timeScale = 1;
        weaponMechanics.AmmoGain();
        Destroy(ammoBox);
        Hide();
    }

    public void NoButton()
    {
        Time.timeScale = 1;

        Hide();
    }

    private void Hide()
    {
        Time.timeScale = 1;

        dialogueBox.SetActive(false);
    }
}
