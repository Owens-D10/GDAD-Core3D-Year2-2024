using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEditor.Rendering;


public class KeyBookPrompt : MonoBehaviour
{
    public WeaponMechanics weaponMechanics;
    public GameObject dialogueBox;
    public GameObject keyBook;
    public GameObject window;
    public GameObject brokenWindow;
    public AudioSource windowBreak;
    public GameObject wolf1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && Input.GetButtonDown("ActionButton") && WeaponMechanics.isAiming == false)
        {
            dialogueBox.SetActive(true);
            Time.timeScale = 0;
        }

    }

    public void YesButton()
    {
        Destroy(keyBook);
        Hide();
        StartCoroutine(BreakWindow());
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

    IEnumerator BreakWindow()
    {
        yield return new WaitForSeconds(1);
        windowBreak.Play();
        window.SetActive(false);
        brokenWindow.SetActive(true);
        wolf1.SetActive(true);

    }
}
