using GHOSTED.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelController : MonoBehaviour
{

    AudioSource Music;
    // Start is called before the first frame update
    void Start()
    {
        Music = GetComponent<AudioSource>();
        EventManager.Instance.Raise(new PlayMusicEvent(Music));
    }
}
