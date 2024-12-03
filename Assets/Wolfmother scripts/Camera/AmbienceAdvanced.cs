using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceAdvanced : MonoBehaviour
{
    public AudioSource From;
    public AudioSource To;
    public bool camOn = false;
    public int cameraNumber;
    public Player status;



    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            To.Play();
            From.Stop();


        }

        else if (other.tag == "Player" && status.hasBook == true)
        {

        }
    }
}
