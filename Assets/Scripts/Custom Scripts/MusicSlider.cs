using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class MusicSlider : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    private AudioSource mainMusicSource = null;
    private Slider slider = null;
    private bool isBeingDragged = false;

    [SerializeField]
    private TextMeshProUGUI trackProgressText = null;

    void Start()
    {
        GameObject mainMusicObject = GameObject.Find("Main Music Source");
        if (mainMusicObject != null)
        {
            mainMusicSource = mainMusicObject.GetComponent<AudioSource>();
        }

        slider = GetComponent<Slider>();
    }

    void Update()
    {
        UpdateSlider();
    }

    public void ChangeTrackProgress()
    {
        if (mainMusicSource != null && mainMusicSource.clip != null)
        {
            mainMusicSource.time = slider.value * mainMusicSource.clip.length;
        }

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isBeingDragged = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (mainMusicSource != null && mainMusicSource.clip != null)
        {
            isBeingDragged = false;
            mainMusicSource.time = slider.value * mainMusicSource.clip.length;
        }
    }

    string FormatTime(float timeInSeconds, float durationInSeconds)
    {
        TimeSpan currentTime = TimeSpan.FromSeconds(timeInSeconds);
        TimeSpan duration = TimeSpan.FromSeconds(durationInSeconds);

        return string.Format("{0} / {1}", currentTime.ToString("mm':'ss"), duration.ToString("mm':'ss"));
    }

    void UpdateSliderValue()
    {
        slider.value = mainMusicSource.time / mainMusicSource.clip.length;
    }

    public void UpdateTrackProgressText()
    {
        if (mainMusicSource != null && mainMusicSource.clip != null)
        {
            trackProgressText.text = FormatTime(mainMusicSource.time, mainMusicSource.clip.length);
        }
    }

    void UpdateSlider()
    {
        if (gameObject.activeInHierarchy && !isBeingDragged && mainMusicSource != null && mainMusicSource.isPlaying && mainMusicSource.time < mainMusicSource.clip.length)
        {
            UpdateSliderValue();
            UpdateTrackProgressText();
        }
    }
}
