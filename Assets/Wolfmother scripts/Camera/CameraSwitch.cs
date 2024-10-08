using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject CameraA;
    public GameObject CameraB;
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
            CameraB.SetActive(true);
            CameraA.SetActive(false);
        }
    }
}
