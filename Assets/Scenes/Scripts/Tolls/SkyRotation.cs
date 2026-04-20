using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyRotation : MonoBehaviour
{

    private float rot = 0;
    public float rate = 0.7f;

    void Start()
    {
        rot = RenderSettings.skybox.GetFloat("_Rotation");
    }

    // Update is called once per frame
    void Update()
    {
        rot += rate * Time.deltaTime;
        rot %= 360;
        RenderSettings.skybox.SetFloat("_Rotation", rot);
    }
}
