using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    public string DialogueName;
    public string Name;
    [TextArea()]
    public string[] Sentences;
    public bool Repeatable;
    public Sprite Image;
}

[System.Serializable]
public class Discussion
{
    public Dialogue Dialogue;
    public Dialogue Deny;
}
