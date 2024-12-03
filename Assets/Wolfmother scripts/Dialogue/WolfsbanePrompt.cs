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

    private void OnTriggerEnter(Collider other) // checks if the player is in range of the object
    {
        if (other.tag == "Player")
        {
            inRange = true;
        }

    }
    private void OnTriggerExit(Collider other)  // checks if the player is out of range of the object
    {
        if (other.tag == "Player")
        {
            inRange = false;
        }
    }
    void Update()
    {
        if (inRange == true && Input.GetButtonDown("ActionButton") && WeaponMechanics.isAiming == false) // triggers dialogue box and item camera
        {
            dialogueBox.SetActive(true);
            Time.timeScale = 0;     // pauses the game
            Cursor.lockState = CursorLockMode.Confined; // unlocks mouse from the middle of the scene
            Cursor.visible = true;  // makes the mouse visible
            itemGlint.Clear();   // stops the item glint particle effect
            itemCamera.SetActive(true); // changes camera angle to focus on the object
            player.SetActive(false);
        }
    }

    public void YesButton() // yes option in dialogue
    {
        
        Hide();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("Game"); // reloads the scene from the start
    }

    public void NoButton()
    {

        Hide();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        itemGlint.Play();
        itemCamera.SetActive (false);
        player.SetActive(true);
    }

    private void Hide() // hides dialogue box and unpauses the game
    {
        Time.timeScale = 1;

        dialogueBox.SetActive(false);
    }
}
