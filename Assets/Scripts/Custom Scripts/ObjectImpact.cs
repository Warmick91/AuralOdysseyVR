using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectImpact : MonoBehaviour
{
    AudioSource audioSource;
    Rigidbody rb;
    AudioClip panelImpact;
    AudioClip doorImpact;

    float volumeSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        panelImpact = Resources.Load<AudioClip>("FX/SFX_Impact_Ball");
        doorImpact = Resources.Load<AudioClip>("FX/SFX_Impact_Heavy");
        if (panelImpact == null || doorImpact == null)
        {
            Debug.Log("Impact sound not found");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        volumeSound = rb.velocity.magnitude;
        string tag = collision.gameObject.tag;

        switch (tag)
        {
            case "Panel":
                audioSource.clip = panelImpact;
                audioSource.PlayOneShot(audioSource.clip, volumeSound);
                break;

            case "Door":
                audioSource.clip = doorImpact;
                audioSource.PlayOneShot(audioSource.clip, volumeSound);
                Debug.Log("DOOR SOUND: " + volumeSound);
                break;

            default:
                //Debug.Log("Impact without sound");
                break;
        }
    }

}
