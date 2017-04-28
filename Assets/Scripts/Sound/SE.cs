using UnityEngine;
using System.Collections;

public class SE
{
    public static void Play(string name) 
    {
        Singleton<SoundPlayer>.instance.playSE(name);
    }

    public static AudioClip PlayVoice(int charaNo, Voice voice) 
    {
        return Singleton<SoundPlayer>.instance.playVoice(charaNo, voice);
    }
}
