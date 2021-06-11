using GHOSTED.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Discussion[] Discussion;

    // Déclanchement d'un dialogue
    public void TriggerDialogue()
    {
        // Si le joueur à la permission on lance le dialogue sinon on lance le dialogue de refus
        EventManager.Instance.Raise(new StartDiscussionEvent(Discussion[0]));
    }

    // Permet de déclancher un autre dialogue (dans le cas ou il y en a plusieurs)
    public void TriggerOtherDialogue(int index)
    {
        EventManager.Instance.Raise(new StartDiscussionEvent(Discussion[index]));
    }
}
