using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.SceneManagement;

public class WolfsbanePrompt : MonoBehaviour
{
    public WeaponMechanics weaponMechanics;
    public GameObject dialogueBox;
    public Scene game;
    public ParticleSystem itemGlint;
    public GameObject itemCamera;
    public GameObject player;

    public bool inRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
        }

    }
    void Update()
    {
        if (inRange == true && Input.GetButtonDown("ActionButton") && WeaponMechanics.isAiming == false)
        {
            dialogueBox.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            itemGlint.Clear();
            itemCamera.SetActive(true);
            player.SetActive(false);
        }
    }

    public void YesButton()
    {
        
        Hide();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("Game");
        itemCamera.SetActive(false);
        player.SetActive(true);
    }

    public void NoButton()
    {

        Hide();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        itemGlint.Play();
        itemCamera.SetActive(false);
        player.SetActive(true);
    }

    private void Hide()
    {
        Time.timeScale = 1;

        dialogueBox.SetActive(false);
    }
}
