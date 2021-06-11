using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region GameManager Events
public class MainMenuEvent : GHOSTED.Events.Event
{
}
public class GamePlayEvent : GHOSTED.Events.Event
{
}
public class GamePauseEvent : GHOSTED.Events.Event
{
}
public class GameResumeEvent : GHOSTED.Events.Event
{
}
public class GameVictoryEvent : GHOSTED.Events.Event
{
}
#endregion

#region MenuManager Events
public class EscapeButtonClickedEvent : GHOSTED.Events.Event
{
}
public class PlayButtonClickedEvent : GHOSTED.Events.Event
{
}
public class ResumeButtonClickedEvent : GHOSTED.Events.Event
{
}
public class MainMenuButtonClickedEvent : GHOSTED.Events.Event
{
}
public class NextLevelButtonClickedEvent : GHOSTED.Events.Event
{
}
#endregion

#region AudioManager Events
public class UpdateMusicVolumeEvent : GHOSTED.Events.Event
{
}

public class UpdateSoundVolumeEvent : GHOSTED.Events.Event
{
}

public class PlaySoundEvent : GHOSTED.Events.Event
{
    AudioSource m_Sound;
    public AudioSource Sound { get { return this.m_Sound; } }
    public PlaySoundEvent(AudioSource sound)
    {
        m_Sound = sound;
    }
}

public class PlayMusicEvent : GHOSTED.Events.Event
{
    AudioSource m_Sound;
    public AudioSource Sound { get { return this.m_Sound; } }
    public PlayMusicEvent(AudioSource sound)
    {
        m_Sound = sound;
    }
}
#endregion

#region LevelManager Events

public class PortalEvent : GHOSTED.Events.Event
{
    Portal m_Portal;

    public Portal Portal { get { return this.m_Portal; } }
    public PortalEvent(Portal portal)
    {
        m_Portal = portal;
    }
}

#endregion

#region DialogueManager Events

public class StartDiscussionEvent : GHOSTED.Events.Event
{
    Discussion m_Discussion;

    public Discussion Discussion { get { return this.m_Discussion; } }
    public StartDiscussionEvent(Discussion discussion)
    {
        m_Discussion = discussion;
    }
}

#endregion