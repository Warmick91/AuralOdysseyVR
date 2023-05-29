using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class HeavensLight : MonoBehaviour
{
    private Light heavensLight;
    private float initIntensityLevel;

    void Start()
    {
        heavensLight = GetComponent<Light>();
        initIntensityLevel = heavensLight.intensity;
    }

    public void DimTheLight()
    {
        heavensLight.intensity = initIntensityLevel * 0.5f;
    }

    public void NormalizeTheLight()
    {
        heavensLight.intensity = initIntensityLevel;
    }

}
