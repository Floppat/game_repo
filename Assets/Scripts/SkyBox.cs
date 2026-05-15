using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBox : MonoBehaviour
{
    [SerializeField] private Material[] skyboxes;
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = skyboxes[0];
    }

    // Update is called once per frame
    void Update()
    {
        //iterate through the skyboxes and change the skybox when the user presses 1, 2, or 3
        foreach (var skybox in skyboxes)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                RenderSettings.skybox = skyboxes[1];
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                RenderSettings.skybox = skyboxes[2];
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                RenderSettings.skybox = skyboxes[3];
            }
        }
    }
}
