using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Voice 
{
    V1 = 1,
    V2 = 2,
    Damage = 3,
    Piyo = 4,
    V5 = 5,
    Roll = 6,
    Select = 7,
    NewRecord = 8,
    ButRecord = 9,
    Win = 10,
    Lose = 11,
    Goal = 12
};

public class SoundPlayer
{
    BGMPlayer curBGMPlayer;
    BGMPlayer fadeOutBGMPlayer;
    GameObject soundPlayerObj;
    GameObject voicePlayerObj;
    AudioSource audioSource;
    AudioSource voiceAudio;
    Dictionary<string, AudioClipInfo> audioClips = new Dictionary<string, AudioClipInfo>();

    // AudioClip information
    class AudioClipInfo
    {
        public string resourceName;
        public string name;
        public AudioClip clip;

        public AudioClipInfo(string resourceName, string name)
        {
            this.resourceName = resourceName;
            this.name = name;
        }
    }

    public SoundPlayer()
    {
        audioClips.Add("select", new AudioClipInfo("select", "select"));
        audioClips.Add("miss1", new AudioClipInfo("miss1", "miss1"));
        audioClips.Add("barrage", new AudioClipInfo("barrage", "barrage"));
        audioClips.Add("fly", new AudioClipInfo("fly", "fly"));
    }

    public bool playSE(string seName, float volume = 0.23f)
    {
        if (audioClips.ContainsKey(seName) == false)
            return false; // not register

        AudioClipInfo info = audioClips[seName];

        // Load
        if (info.clip == null)
            info.clip = (AudioClip)Resources.Load(info.resourceName);

        if (soundPlayerObj == null)
        {
            soundPlayerObj = new GameObject("SoundPlayer");
            audioSource = soundPlayerObj.AddComponent<AudioSource>();
        }

        audioSource.volume = volume;

        // Play SE
        audioSource.PlayOneShot(info.clip);
        
        return true;
    }

    public void playBGM(string bgmName, float volume = 0.3f)
    {
        if (curBGMPlayer != null)
        {
            curBGMPlayer.destory();
        }

        // play new BGM
        if (audioClips.ContainsKey(bgmName) == false)
        {
            audioClips.Add(bgmName, new AudioClipInfo(bgmName, bgmName));
        }

        curBGMPlayer = new BGMPlayer(audioClips[bgmName].resourceName, volume);
        curBGMPlayer.playBGM();
    }

    public AudioClip playVoice(int charaNo, Voice voice, float volume = 1) 
    {
        string keyName = charaNo + "_" + (int)voice;
        
        if (audioClips.ContainsKey(keyName) == false) 
        {
            string resourceName = charaNo + "/chara" + keyName;

            audioClips.Add(keyName, new AudioClipInfo(resourceName, keyName));
        }

        AudioClipInfo info = audioClips[keyName];

        // Load
        if (info.clip == null)
            info.clip = (AudioClip)Resources.Load(info.resourceName);

        if (voicePlayerObj == null)
        {
            voicePlayerObj = new GameObject("VoicePlayer");
            voiceAudio = voicePlayerObj.AddComponent<AudioSource>();
        }

        voiceAudio.volume = volume;

        // Play SE
        voiceAudio.PlayOneShot(info.clip);

        return info.clip;
    }

    public void playBGMFadeIn(string bgmName, float fadeTime)
    {
        // destory old BGM
        if (fadeOutBGMPlayer != null)
            fadeOutBGMPlayer.destory();

        // change to fade out for current BGM
        if (curBGMPlayer != null)
        {
            curBGMPlayer.stopBGM(fadeTime);
            fadeOutBGMPlayer = curBGMPlayer;
        }

        // play new BGM
        if (audioClips.ContainsKey(bgmName) == false)
        {
            audioClips.Add(bgmName, new AudioClipInfo(bgmName, bgmName));
            // null BGM
            //curBGMPlayer = new BGMPlayer();
        }

        curBGMPlayer = new BGMPlayer(audioClips[bgmName].resourceName);
        curBGMPlayer.playBGM(fadeTime);
    }

    public void playBGM()
    {
        if (curBGMPlayer != null && curBGMPlayer.hadFadeOut() == false)
            curBGMPlayer.playBGM();
        if (fadeOutBGMPlayer != null && fadeOutBGMPlayer.hadFadeOut() == false)
            fadeOutBGMPlayer.playBGM();
    }

    public void pauseBGM()
    {
        if (curBGMPlayer != null)
            curBGMPlayer.pauseBGM();
        if (fadeOutBGMPlayer != null)
            fadeOutBGMPlayer.pauseBGM();
    }

    public void stopBGM(float fadeTime)
    {
        if (curBGMPlayer != null)
            curBGMPlayer.stopBGM(fadeTime);
        if (fadeOutBGMPlayer != null)
            fadeOutBGMPlayer.stopBGM(fadeTime);
    }

    public void stopBGM() 
    {
        if (curBGMPlayer != null)
            curBGMPlayer.stopBGM();
        if (fadeOutBGMPlayer != null)
            fadeOutBGMPlayer.stopBGM();
    }
}
