using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skybox_Handler : MonoBehaviour
{
    public Material[] skyboxes;
    // Start is called before the first frame update
    void Start()
    {
        var element = skyboxes[Random.Range(0, skyboxes.Length)];
        RenderSettings.skybox = element;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
