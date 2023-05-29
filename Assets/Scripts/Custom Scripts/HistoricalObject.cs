using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HistoricalObject : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Transform originalParent;
    public bool isInSocket = true;
    public bool isBeingHeld = false;

    void Start()
    {
        // Save the original position and rotation of the object
        originalPosition = this.transform.position;
        originalRotation = this.transform.rotation;
        originalParent = this.transform.parent;
    }

    public void ResetObjectToOriginalPosition()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        if (interactable.isSelected)
        {
            XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
            grabInteractable.enabled = false;
            grabInteractable.enabled = true;
        }

        this.transform.SetParent(null);
        this.transform.position = originalPosition;
        this.transform.rotation = originalRotation;
        this.transform.SetParent(originalParent);
    }

    // Create a list of historical objects EXCLUDING the object being held
    public List<GameObject> GetOtherHistoricalObjects()
    {
        var goArray = GameObject.FindObjectsOfType<GameObject>();
        var goList = new List<GameObject>();
        for (int i = 0; i < goArray.Length; i++)
        {
            if (goArray[i].layer == 6)
            {
                goList.Add(goArray[i]);
            }
        }

        goList.Remove(this.gameObject);

        return goList;
    }

    // Check if other objects are outside of their sockets, then reset them to their original position
    public void ResetOtherObjects()
    {
        foreach (GameObject go in GetOtherHistoricalObjects())
        {
            HistoricalObject historicalObject = go.GetComponent<HistoricalObject>();
            if (historicalObject.isInSocket == false)
            {
                historicalObject.ResetObjectToOriginalPosition();

                historicalObject.SetIsBeingHeld(false);
            }
        }
    }

    public void PlaceInTheSocket()
    {
        isInSocket = true;
    }

    public void RemoveFromTheSocket()
    {
        isInSocket = false;
    }

    public void SetIsBeingHeld(bool isBeingHeld)
    {
        this.isBeingHeld = isBeingHeld;
    }
}
