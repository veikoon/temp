using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GHOSTED.Events;

public class MainMenuController : MonoBehaviour, IEventHandler
{
    [SerializeField] GameObject m_MainMenu;
    [SerializeField] GameObject m_OptionsMenu;
    [SerializeField] Slider MusicSlider;
    [SerializeField] Slider SoundSlider;
    [SerializeField] AudioSource ButtonSound;
    [SerializeField] AudioSource Music;
    List<GameObject> m_AllPanels = new List<GameObject>();

    private void Awake()
    {
        m_AllPanels.Add(m_MainMenu);
        m_AllPanels.Add(m_OptionsMenu);
    }

    private void Start()
    {
        // On récupère les préférences du joueur, par défaut on met le son a fond
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);
        SoundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 1);

        EventManager.Instance.Raise(new PlayMusicEvent(Music));
    }

    #region Events subscrive
    public void SubscribeEvents()
    {
        EventManager.Instance.AddListener<MainMenuEvent>(MainMenu);
    }

    public void UnsubscribeEvents()
    {
        EventManager.Instance.RemoveListener<MainMenuEvent>(MainMenu);
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
    void MainMenu(MainMenuEvent e)
    {
        DisplayPanel(m_MainMenu);
    }
    #endregion

    void DisplayPanel(GameObject panel)
    {
        m_AllPanels.ForEach(item => item.SetActive(panel == item));
    }

    public void PlayButton()
    {
        EventManager.Instance.Raise(new PlaySoundEvent(ButtonSound));
        EventManager.Instance.Raise(new PlayButtonClickedEvent());
    }

    public void OptionButton()
    {
        EventManager.Instance.Raise(new PlaySoundEvent(ButtonSound));
        DisplayPanel(m_OptionsMenu);
    }

    public void BackButton()
    {
        EventManager.Instance.Raise(new PlaySoundEvent(ButtonSound));
        DisplayPanel(m_MainMenu);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void OnVolumeChangeMusic()
    {
        PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
        PlayerPrefs.Save();
        EventManager.Instance.Raise(new UpdateMusicVolumeEvent());
    }

    public void OnVolumeChangeSound()
    {
        PlayerPrefs.SetFloat("SoundVolume", SoundSlider.value);
        PlayerPrefs.Save();
        EventManager.Instance.Raise(new UpdateSoundVolumeEvent());
    }
}