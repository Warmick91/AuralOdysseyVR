using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    // Start is called before the first frame update
    MeshRenderer radioSwitchMesh;
    bool isPlaying = true;
    AudioSource audioSource;

    void Start()
    {
        radioSwitchMesh = GetComponent<MeshRenderer>();
        audioSource = GetComponentInParent<AudioSource>();

        if (!isPlaying)
        {
            TogglePlay();
        }
    }

    public void TogglePlay()
    {
        isPlaying = !isPlaying;

        if (!isPlaying)
        {
            audioSource.Pause();
            radioSwitchMesh.material.color = Color.red;
        }
        else
        {
            audioSource.Play();
            radioSwitchMesh.material.color = Color.green;
        }
    }
}
