using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum GameState { menu, play, pause, victory }

public class GameManager : MonoBehaviour
{
    private static GameManager m_Instance;
    public static GameManager Instance { get { return m_Instance; } }

    public Player Player;

    private GameState m_State;

    #region Init
    private void Awake()
    {
        // On n'autorise qu'une seule instance de Game Manager
        if (m_Instance) Destroy(gameObject);
        else
        {
            m_Instance = this;

            // On définit cette instance comme persistante
            DontDestroyOnLoad(gameObject);
            Player = new Player();
        }
    }

    void Start()
    {
        SetState(GameState.menu);
    }

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    public void SubscribeEvents()
    {
    }

    public void UnsubscribeEvents()
    {
    }
    #endregion

    void SetState(GameState newState)
    {
        m_State = newState;

        // notification du changement d'état
        switch (m_State)
        {
            case GameState.menu:
                break;
            case GameState.play:
                break;
            case GameState.pause:
                break;
            case GameState.victory:
                break;
            default:
                break;
        }
    }

    void PlayButtonClicked(PlayButtonClickedEvent e)
    {
        SetState(GameState.play);
    }

    void MainMenuButtonClicked(MainMenuButtonClickedEvent e)
    {
        SetState(GameState.menu);
    }

    void Pause()
    {
        SetState(GameState.pause);
    }

    void Victory()
    {
        SetState(GameState.victory);
    }
}
