using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player3D : MonoBehaviour
{
    // Je sais pas ce que c'est (je suppose que c'est un composant qui permet de d�placer le joueur)
    private CharacterController Controller;
    private Vector3 PlayerVelocity;
    [Tooltip("PlayerReference")]
    [SerializeField] private Player Player;
    [Header("Motion Setup")]
    [Tooltip("MovementSpeed")]
    [SerializeField] private float PlayerSpeed;
    // Position du centre de la scene 3D
    private Vector3 Center;
    // Distance au dela de la quelle le joueur est bloqu�
    private float radius;

    private void Start()
    {
        // On d�finit le centre
        Center = new Vector3(15, 0, 100);
        // On d�finit le radius
        radius = 200;

        // On cr�er le composant CharacterController
        Controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        // Si le joueur ne peux pas se d�placer on annule le d�placement
        if (!GameManager.Instance.Player.canMove) return;
        
        // On r�cup�re les inputs du joueur
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Si la future distance du joueur d�passe le radius on annule le d�placement
        if (Vector3.Distance(Center, gameObject.transform.position + 1 * move) > radius) return;
        

        //On d�place le joueur
        Controller.Move(move * Time.deltaTime * PlayerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        Controller.Move(PlayerVelocity * Time.deltaTime);
    }
}