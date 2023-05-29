using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    // The Scriptable Object holding all necessery data about the musical period
    [SerializeField] private MusicalPeriod musicalPeriodScriptableObject;

    // Information fields
    private TextMeshProUGUI periodNameField;
    private TextMeshProUGUI infoTextField;
    private Image imageField;

    void Awake()
    {
        try
        {
            periodNameField = this.transform.Find("Background Panel/Period Name").GetComponent<TextMeshProUGUI>();
            infoTextField = this.transform.Find("Background Panel/Text Control Panel/Period Info").GetComponent<TextMeshProUGUI>();
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }

    void Start()
    {
        periodNameField.text = GetPeriodName();
        infoTextField.text = GetInfoText();
    }

    public string GetPeriodName()
    {
        return musicalPeriodScriptableObject.GetPeriodName();
    }

    public string GetInfoText()
    {
        return musicalPeriodScriptableObject.GetInfoText();
    }

    public List<AudioClip> GetPeriodTracks()
    {
        return musicalPeriodScriptableObject.GetPeriodTracks();
    }

    public List<ImageData> GetImages()
    {
        return musicalPeriodScriptableObject.GetImages();
    }
}
