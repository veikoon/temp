using GHOSTED.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [Header("Selection Level Settings")]
    [Tooltip("LevelName")]
    // La scène vers laquel pointe le portail
    [SerializeField] public Object LevelName;

    [Tooltip("LevelToUnlock")]
    // La scène que le joueur va débloquer en entrant dans le portail
    [SerializeField] public Object NextLevel;

    // Lors d'une collision avec un collider en 3D
    private void OnTriggerEnter(Collider collider)
    {
        OnCollision(collider.gameObject);
    }

    // Lors d'une collision avec un collider en 2D
    private void OnTriggerEnter2D(Collider2D collider)
    {
        OnCollision(collider.gameObject);
    }

    private void OnCollision(GameObject go)
    {
        if (go.tag.Equals("Player"))
            EventManager.Instance.Raise(new PortalEvent(this));
    }
}
