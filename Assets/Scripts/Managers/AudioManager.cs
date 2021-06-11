using GHOSTED.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    private static AudioManager m_Instance;
    public static AudioManager Instance { get { return m_Instance; } }

    private List<AudioSource> m_Sounds;
    private List<AudioSource> m_Musics;

    #region Events subscrive
    public void SubscribeEvents()
    {
        EventManager.Instance.AddListener<PlayMusicEvent>(PlayMusic);
        EventManager.Instance.AddListener<PlaySoundEvent>(PlaySound);
        EventManager.Instance.AddListener<UpdateMusicVolumeEvent>(UpdateMusicVolume);
        EventManager.Instance.AddListener<UpdateSoundVolumeEvent>(UpdateSoundVolume);
    }

    public void UnsubscribeEvents()
    {
        EventManager.Instance.RemoveListener<PlayMusicEvent>(PlayMusic);
        EventManager.Instance.RemoveListener<PlaySoundEvent>(PlaySound);
        EventManager.Instance.RemoveListener<UpdateMusicVolumeEvent>(UpdateMusicVolume);
        EventManager.Instance.RemoveListener<UpdateSoundVolumeEvent>(UpdateSoundVolume);
    }

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }
    #endregion

    #region Events callbacks
    void PlayMusic(PlayMusicEvent e)
    {
        PlayMusic(e.Sound);
    }

    void PlaySound(PlaySoundEvent e)
    {
        PlaySound(e.Sound);
    }

    void UpdateMusicVolume(UpdateMusicVolumeEvent e)
    {
        foreach (AudioSource sound in m_Musics)
        {
            sound.volume = PlayerPrefs.GetFloat("MusicVolume", 1);
        }
    }

    void UpdateSoundVolume(UpdateSoundVolumeEvent e)
    {
        foreach (AudioSource sound in m_Sounds)
        {
            sound.volume = PlayerPrefs.GetFloat("SoundVolume", 1);
        }
    }
    #endregion

    private void Awake()
    {
        // On n'autorise qu'une seule instance de Game Manager
        if (m_Instance) Destroy(gameObject);
        else
        {
            m_Instance = this;

            // On définit cette instance comme persistante
            DontDestroyOnLoad(gameObject);
            m_Musics = new List<AudioSource>();
            m_Sounds = new List<AudioSource>();
        }
    }

    void PlaySound(AudioSource sound)
    {
        if (!m_Sounds.Contains(sound)) m_Sounds.Add(sound);
        sound.volume = PlayerPrefs.GetFloat("SoundVolume", 1);
        sound.Play();
    }

    void PlayMusic(AudioSource sound)
    {
        if (!m_Musics.Contains(sound)) m_Musics.Add(sound);
        sound.volume = PlayerPrefs.GetFloat("MusicVolume", 1);
        sound.Play();
    }
}
