using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    // La liste de nom des scènes dans lesquelles le joueur peut se rendre
    public List<string> UnlockedLevels = new List<string>();

    // La liste des dialogues que le joueur peut lancer
    public List<string> UnlockedDialogues = new List<string>();

    // Variable qui définit si le joueur à la permission de se déplacer
    public bool canMove;

    public Player()
    {
        canMove = true;
        UnlockedLevels.Add("CityLevel 1");

        UnlockedDialogues.Add("Denied");
        UnlockedDialogues.Add("Portal1");
    }
}
