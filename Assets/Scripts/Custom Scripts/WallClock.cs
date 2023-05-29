using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class WallClock : MonoBehaviour
{
    [SerializeField] GameObject hourHand;
    [SerializeField] GameObject minuteHand;
    [SerializeField] GameObject secondHand;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateClock", 0.1f, 1f);
    }

    void UpdateClock()
    {
        DateTime time = DateTime.Now;

        //float hourHandAngle = (360f / 3600f) * time.Second;
        float hourHandAngle = (360f / 12) * (time.Hour % 12 + time.Minute / 60f);
        float minuteHandAngle = (360f / 60) * time.Minute;
        float secondHandAngle = (360f / 60) * time.Second;

        hourHand.transform.localRotation = Quaternion.Euler(hourHandAngle, 0, 0);
        minuteHand.transform.localRotation = Quaternion.Euler(minuteHandAngle, 0, 0);
        secondHand.transform.localRotation = Quaternion.Euler(secondHandAngle, 0, 0);
    }

}
