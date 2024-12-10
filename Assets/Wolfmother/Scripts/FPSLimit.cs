using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimit : MonoBehaviour
{

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.targetFrameRate != 30)
        {
            Application.targetFrameRate = 30;
        }
    }
}
