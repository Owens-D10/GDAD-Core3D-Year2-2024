using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject From;
    public GameObject To;
    public bool camOn = false;
    public int cameraNumber;
    
    void Start()
    {
        cameraNumber = 1;
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            To.SetActive(true);
            From.SetActive(false);
            
        }
    }
}
