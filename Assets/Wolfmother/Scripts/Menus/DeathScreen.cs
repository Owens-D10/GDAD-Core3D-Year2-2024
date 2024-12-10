using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void TryAgainButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Title");
    }
}
