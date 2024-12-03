using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceSwitcher : MonoBehaviour
{
    public AudioSource PreviousAmbience;
    public AudioSource NextAmbience;
    public Player player;
    public AudioSource NewPreviousAmbience;
    public AudioSource NewNextAmbience;
    private void OnTriggerEnter(Collider other)
    {
        if (player.hasBook == false)
        {
            PreviousAmbience.Stop();
            NextAmbience.Play();
        }
        else if (player.hasBook == true)
        {
            NewPreviousAmbience.Stop();
            NewNextAmbience.Play();
        }
    }
}
