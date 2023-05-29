using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MusicalPeriod : ScriptableObject
{
    [SerializeField]
    protected string periodName;

    [SerializeField]
    protected List<ImageData> imageScriptables;

    [TextArea(10, 10)]
    [SerializeField]
    protected string infoText;

    [SerializeField]
    protected List<AudioClip> periodTracks;

    public string GetPeriodName()
    {
        return periodName;
    }

    public string GetInfoText()
    {
        return infoText;
    }

    public List<AudioClip> GetPeriodTracks()
    {
        return periodTracks;
    }

    public List<ImageData> GetImages()
    {
        return imageScriptables;
    }
}
