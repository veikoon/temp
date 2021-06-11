using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player3D : MonoBehaviour
{
    // Je sais pas ce que c'est (je suppose que c'est un composant qui permet de déplacer le joueur)
    private CharacterController Controller;
    private Vector3 PlayerVelocity;
    [Tooltip("PlayerReference")]
    [SerializeField] private Player Player;
    [Header("Motion Setup")]
    [Tooltip("MovementSpeed")]
    [SerializeField] private float PlayerSpeed;
    // Position du centre de la scene 3D
    private Vector3 Center;
    // Distance au dela de la quelle le joueur est bloqué
    private float radius;

    private void Start()
    {
        // On définit le centre
        Center = new Vector3(15, 0, 100);
        // On définit le radius
        radius = 200;

        // On créer le composant CharacterController
        Controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        // Si le joueur ne peux pas se déplacer on annule le déplacement
        if (!GameManager.Instance.Player.canMove) return;
        
        // On récupère les inputs du joueur
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Si la future distance du joueur dépasse le radius on annule le déplacement
        if (Vector3.Distance(Center, gameObject.transform.position + 1 * move) > radius) return;
        

        //On déplace le joueur
        Controller.Move(move * Time.deltaTime * PlayerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        Controller.Move(PlayerVelocity * Time.deltaTime);
    }
}