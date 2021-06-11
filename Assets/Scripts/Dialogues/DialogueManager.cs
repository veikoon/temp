using GHOSTED.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] Text NameText;
    [SerializeField] Text DialogueText;
    [SerializeField] Animator Animator;
    [SerializeField] Image Image;
    AudioSource m_Sound;
    Queue<string> m_Sentences;

    private static DialogueManager m_Instance;
    public static DialogueManager Instance { get { return m_Instance; } }

    #region Events subscrive
    public void SubscribeEvents()
    {
        EventManager.Instance.AddListener<StartDiscussionEvent>(StartDialogue);
    }

    public void UnsubscribeEvents()
    {
        EventManager.Instance.RemoveListener<StartDiscussionEvent>(StartDialogue);
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
    void StartDialogue(StartDiscussionEvent e)
    {
        StartDiscussion(e.Discussion);
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

    void Start()
    {
        m_Sentences = new Queue<string>();
        m_Sound = GetComponent<AudioSource>();
    }

    public void StartDiscussion(Discussion discussion)
    {
        // On vérifie si le joueur à la permission de lancer la conversation
        if (!Allow(discussion))
            StartDialogue(discussion.Deny);
        else
            StartDialogue(discussion.Dialogue);
    }

    public bool StartDialogue(Dialogue dialogue)
    {
        
        // On bloque le mouvement du joueur
        GameManager.Instance.Player.canMove = false;
        // On lance l'animation pop up de la fenêtre de conversation
        Animator.SetBool("IsOpen", true);
        // On définit l'image de la personne qui parle
        Image.sprite = dialogue.Image;
        // On définit le nom de la personne qui parle
        NameText.text = dialogue.Name;
        // On vide la page d'une potentielle conversation précedente
        m_Sentences.Clear();

        // On rajoute toutes les phrases du dialogue dans une Queue
        foreach (string sentence in dialogue.Sentences)
        {
            m_Sentences.Enqueue(sentence);
        }
        // On lance la première phrase
        DisplayNextSentence();
        return true;
    }

    // Lancement de la phrase suivante
    public void DisplayNextSentence()
    {
        // Si il ne reste plus de phrase dans la Queue on arrète la conversation
        if(m_Sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        // Sinon
        // On lance la son de conversation
        m_Sound.Play();
        // On récupère la dernière phrase de la queue
        string sentence = m_Sentences.Dequeue();
        // On arrète les coroutines au cas ou la précèdente animation ne soit pas terminé
        StopAllCoroutines();
        // On lance la coroutine qui va lancer l'animation pour cette phrase
        StartCoroutine(TypeSentence(sentence));
    }

    // Coroutine de l'animation d'écriture de texte dans la fenêtre
    IEnumerator TypeSentence(string sentence)
    {
        // On réinitialise le texte
        DialogueText.text = "";
        // Pour chaque lettre de la phrase
        foreach (char letter in sentence)
        {
            // On rajoute la lettre
            DialogueText.text += letter;
            // On attend 10 frames avant d'afficher la prochaine lettre
            for (int i = 0; i < 10; i++)
            {
                yield return 0;
            }
        }
        // On coupe le son à la fin de la phrase
        m_Sound.Stop();
    }

    // Fin de la discussion
    public void EndDialogue()
    {
        // On réautorise le joueur à se déplacer
        GameManager.Instance.Player.canMove = true;
        // On fait disparaitre la fenêtre de discussion
        Animator.SetBool("IsOpen", false);
        // On coupe le son au cas ou l'animation n'était pas terminé à la fermeture du dialogue
        m_Sound.Stop();
        // On stoppe la coroutine de l'animation
        StopAllCoroutines();
    }

    // Permet de vérifier si le joueur à débloquer ou non la conversation
    public bool Allow(Discussion discussion)
    {
        if (!GameManager.Instance.Player.UnlockedDialogues.Contains(discussion.Dialogue.DialogueName))
            return false;
        // Si le dialogue doit toujours pouvoir être lancé on ne le supprime pas
        else if (!discussion.Dialogue.Repeatable)
            GameManager.Instance.Player.UnlockedDialogues.Remove(discussion.Dialogue.DialogueName);
        return true;
    }
}
