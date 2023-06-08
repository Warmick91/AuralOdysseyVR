using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MusicControlPanel : MonoBehaviour
{
    // The variable for simplyfing the access to the list of audio clips from the InfoCanvas object
    private List<AudioClip> periodTracks;

    [SerializeField]
    private InfoPanel infoPanel;

    // The main audio source GameObject in the scene
    private AudioSource mainAudioSource = null;
    private AudioSource ambientHumSource = null;
    private AudioSource ambientMusicSource = null;

    // UI elements
    [SerializeField]
    private TMP_Dropdown dropdownTracks;

    private int currentTrack = 0;

    void Awake()
    {
        if (!SetupMusicSources())
        {
            Debug.Log("Failed to setup one or more audio sources in MusicControlPanel");
            return;
        }

        periodTracks = infoPanel.GetPeriodTracks();
        if (periodTracks == null || periodTracks.Count == 0)
        {
            Debug.Log("No period tracks loaded in MusicControlPanel or periodTracks is null.");
        }
    }

    void Start()
    {
        SetupDropdown();
    }

    void Update()
    {
        // May probe useful. Used for testing whether the right track has been loaded and playing.
        //Debug.Log("The main audio source with the track titled " + mainAudioSource.clip.name + " is playing: " + mainAudioSource.isPlaying);
    }

    bool SetupMusicSources()
    {
        mainAudioSource = GameObject.Find("Main Music Source").GetComponent<AudioSource>();
        ambientHumSource = GameObject.Find("Ambient Hum").GetComponent<AudioSource>();
        ambientMusicSource = GameObject.Find("Ambient Music").GetComponent<AudioSource>();

        return (mainAudioSource != null && ambientHumSource != null && ambientMusicSource != null);
    }

    public void SetupDropdown()
    {
        dropdownTracks.options.Clear();

        foreach (AudioClip track in periodTracks)
        {
            dropdownTracks.options.Add(new TMP_Dropdown.OptionData(track.name));
        }

        if (dropdownTracks.options.Count > 0)
        {
            dropdownTracks.value = currentTrack;
            dropdownTracks.captionText.text = dropdownTracks.options[currentTrack].text;
            dropdownTracks.interactable = true;
        }
        else
        {
            dropdownTracks.captionText.text = "No tracks loaded";
            dropdownTracks.interactable = false;
        }
    }

    public void PlayTrack()
    {
        Invoke("DelayedPlayTrack", 0.1f);
    }

    // DelayedPlayTrack ensures the track starts playing only once the previous object is put back and its track stopped
    public void DelayedPlayTrack()
    {
        if (mainAudioSource != null && !mainAudioSource.isPlaying)
        {
            ambientHumSource.Pause();
            ambientMusicSource.Pause();
            mainAudioSource.Play();
        }
    }

    public void PauseTrack()
    {
        mainAudioSource.Pause();
    }

    public void RestartTrack()
    {
        mainAudioSource.time = 0;
        mainAudioSource.Play();
    }

    public void StopTrack()
    {
        mainAudioSource.Stop();
        mainAudioSource.time = 0;
        ambientHumSource.Play();
        ambientMusicSource.Play();
    }

    public void ChangeTrack()
    {
        if ((dropdownTracks.value < periodTracks.Count))
        {
            mainAudioSource.clip = periodTracks[dropdownTracks.value];
            mainAudioSource.time = 0;
            mainAudioSource.Play();
        }
    }

    // Assign the track to the AudioSource when the object is enabled (the historical object is picked up)
    private void OnEnable()
    {
        if (mainAudioSource != null && periodTracks != null)
        {
            mainAudioSource.clip = periodTracks[currentTrack];
        }

        dropdownTracks.value = currentTrack;
    }
}
