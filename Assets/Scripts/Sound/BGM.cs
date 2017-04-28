using UnityEngine;
using System.Collections;

public class BGM
{
    public static void Play(string name, float volume = 0.4f) 
    {
        Singleton<SoundPlayer>.instance.playBGM(name, volume);
    }

    public static void PlayFadeIn(string name, float fadeTime = 1.0f)
    {
        Singleton<SoundPlayer>.instance.playBGMFadeIn(name, fadeTime);
    }

    public static void Play()
    {
        Singleton<SoundPlayer>.instance.playBGM();
    }

    public static void Pause() 
    {
        Singleton<SoundPlayer>.instance.pauseBGM();
    }

    public static void Stop(float fadeTime) 
    {
        Singleton<SoundPlayer>.instance.stopBGM(fadeTime);
    }

    public static void Stop()
    {
        Singleton<SoundPlayer>.instance.stopBGM();
    }
}
