using GHOSTED.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    private static LevelsManager m_Instance;
    public static LevelsManager Instance { get { return m_Instance; } }

    #region Events subscrive
    public void SubscribeEvents()
    {
        EventManager.Instance.AddListener<PlayButtonClickedEvent>(PlayGame);
        EventManager.Instance.AddListener<PortalEvent>(Portal);
    }

    public void UnsubscribeEvents()
    {
        EventManager.Instance.RemoveListener<PlayButtonClickedEvent>(PlayGame);
        EventManager.Instance.RemoveListener<PortalEvent>(Portal);
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
    void PlayGame(PlayButtonClickedEvent e)
    {
        ChangeScene("SelectLevel");
    }

    void Portal(PortalEvent e)
    {
        OnPortalUse(e.Portal.LevelName.name, e.Portal.NextLevel.name);
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
        }
    }

    void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Méthode appelé lors de l'emprunt d'un portail
    public void OnPortalUse(string levelName, string nextLevel)
    {
        Debug.Log("OnPortalUse");
        // On vérifie que le joueur à la permission de se rendre dans ce niveau
        if (GameManager.Instance.Player.UnlockedLevels.Contains(levelName))
        {
            // On débloque le niveau suivant si il n'est pas déjà débloqué
            if (!GameManager.Instance.Player.UnlockedLevels.Contains(nextLevel))
                GameManager.Instance.Player.UnlockedLevels.Add(nextLevel);
            // On charge le niveau
            SceneManager.LoadScene(levelName);
        }
    }
}
