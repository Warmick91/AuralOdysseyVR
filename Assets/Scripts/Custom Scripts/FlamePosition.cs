using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamePosition : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 worldUp = Vector3.up;
        Vector3 worldForward = Vector3.Cross(transform.right, worldUp);
        Quaternion targetRotation = Quaternion.LookRotation(worldForward, worldUp);
        transform.rotation = targetRotation;
    }
}
