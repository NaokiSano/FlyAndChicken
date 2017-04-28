using UnityEngine;
using System.Collections;

public class BGMPlayer
{
    // State
    class State
    {
        protected BGMPlayer bgmPlayer;
        public State(BGMPlayer bgmPlayer)
        {
            this.bgmPlayer = bgmPlayer;
        }
        public virtual void playBGM() { }
        public virtual void pauseBGM() { }
        public virtual void stopBGM() { }
        public virtual void update() { }
    }

    /*
    ...ここにStateの派生クラスが並ぶ〜...
    */

    class Wait : State
    {
        public Wait(BGMPlayer bgmPlayer) : base(bgmPlayer) { }

        public override void playBGM()
        {
            if (bgmPlayer.fadeInTime > 0.0f)
                bgmPlayer.state = new FadeIn(bgmPlayer);
            else
                bgmPlayer.state = new Playing(bgmPlayer);
        }
    }

    class FadeIn : State 
    {
        float t = 0.0f;

        public FadeIn(BGMPlayer bgmPlayer) : base(bgmPlayer) 
        {
            bgmPlayer.source.Play();
            bgmPlayer.source.volume = 0.0f;
        }

        public override void pauseBGM()
        {
            bgmPlayer.state = new Pause(bgmPlayer, this);
        }

        public override void stopBGM()
        {
            bgmPlayer.state = new FadeOut(bgmPlayer);
        }

        public override void update()
        {
            t += Time.deltaTime;
            bgmPlayer.source.volume = t / bgmPlayer.fadeInTime;
            if (t >= bgmPlayer.fadeInTime) 
            {
                bgmPlayer.source.volume = 1.0f;
                bgmPlayer.state = new Playing(bgmPlayer);
            }
        }
    }

    class FadeOut : State 
    {
        float initVolume;
        float t = 0.0f;

        public FadeOut(BGMPlayer bgmPlayer) : base(bgmPlayer) 
        {
            initVolume = bgmPlayer.source.volume;
        }

        public override void pauseBGM()
        {
            bgmPlayer.state = new Pause(bgmPlayer, this);
        }

        public override void update()
        {
            t += Time.deltaTime;
            bgmPlayer.source.volume = initVolume * (1.0f - t / bgmPlayer.fadeOutTime);
            if (t >= bgmPlayer.fadeOutTime) 
            {
                bgmPlayer.isFadeOut = true;
                bgmPlayer.source.volume = 0.0f;
                bgmPlayer.source.Stop();
                bgmPlayer.state = new Wait(bgmPlayer);
            }
        }
    }

    class Playing : State
    {
        public Playing(BGMPlayer bgmPlayer)
            : base(bgmPlayer)
        {
            if (bgmPlayer.source.isPlaying == false)
            {
                bgmPlayer.source.volume = bgmPlayer.volume;
                bgmPlayer.source.Play();
            }
        }

        public override void pauseBGM()
        {
            bgmPlayer.state = new Pause(bgmPlayer, this);
        }

        public override void stopBGM()
        {
            bgmPlayer.state = new FadeOut(bgmPlayer);
        }
    }

    class Pause : State
    {
        State preState;

        public Pause(BGMPlayer bgmPlayer, State preState)
            : base(bgmPlayer)
        {
            this.preState = preState;
            bgmPlayer.source.Pause();
        }

        public override void stopBGM()
        {
            bgmPlayer.source.Stop();
            bgmPlayer.state = new Wait(bgmPlayer);
        }

        public override void playBGM()
        {
            bgmPlayer.state = preState;
            bgmPlayer.source.Play();
        }
    }

    /*
    ここまで-----------------------------------------------------
    */

    GameObject obj;
    AudioSource source;
    State state;
    float volume;
    float fadeInTime = 0.0f;
    float fadeOutTime = 0.0f;
    bool isFadeOut = false;

    public BGMPlayer() { }

    public BGMPlayer(string bgmFileName, float volume = 1)
    {
        AudioClip clip = (AudioClip)Resources.Load(bgmFileName);
        if (clip != null)
        {
            obj = new GameObject("BGMPlayer");
            source = obj.AddComponent<AudioSource>();
            source.clip = clip;
            source.loop = true;
            source.volume = volume;
            this.volume = volume;
            state = new Wait(this);
        }
        else
            Debug.LogWarning("BGM " + bgmFileName + " is not found.");
    }

    public void destory()
    {
        if (source != null)
            GameObject.Destroy(obj);
    }

    public void playBGM()
    {
        if (source != null)
        {
            state.playBGM();
        }
    }

    public void playBGM(float fadeTime)
    {
        if (source != null)
        {
            this.fadeInTime = fadeTime;
            state.playBGM();
        }
    }

    public void pauseBGM()
    {
        if (source != null)
            state.pauseBGM();
    }

    public void stopBGM(float fadeTime)
    {
        if (source != null)
        {
            fadeOutTime = fadeTime;
            state.stopBGM();
        }
    }

    public void stopBGM()
    {
        source.Stop();
        state = new Wait(this);
    }

    public void update()
    {
        if (source != null)
            state.update();
    }

    public bool hadFadeOut()
    {
        return isFadeOut;
    }
}