using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTrigger : MonoBehaviour
{
    private DialogueTrigger DialogueTrigger;

    private void Start()
    {
        // On récupère le DisalogueTrigger dans le GO courant
        DialogueTrigger = GetComponent<DialogueTrigger>();
    }

    // Detection des collisions dans un environnement 3D
    private void OnTriggerEnter(Collider collider)
    {
        OnCollision(collider.gameObject);
    }

    // Detection des collisions dans un environnement 2D
    private void OnTriggerEnter2D(Collider2D collider)
    {
        OnCollision(collider.gameObject);
    }

    private void OnCollision(GameObject go)
    {
        if (go.tag.Equals("Player"))
        {
            // Si le joueur peut passer à travers le portail on lance le dialogue
            DialogueTrigger.TriggerDialogue();
        }
    }
}
