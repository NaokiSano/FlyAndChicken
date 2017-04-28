using UnityEngine;
using System.Collections;

/*========================================//
  シーン遷移＆フェードアウト、フェードイン
//========================================*/

public class SceneManager : MonoBehaviour {

    Fade fade;

    public string nextSceneName;
    public float fadeAlpha;
    [System.NonSerialized]
    public bool fadeInFlag;
    [System.NonSerialized]
    public bool fadeOutFlag;

	// Use this for initialization
	void Start () {
        fade = GetComponent<Fade>();
        fadeOutFlag = false;
        fadeInFlag = true;
	}
	
	// Update is called once per frame
	void Update () {
        SceneMove();
        FadeOut();
	}

    /***** シーン遷移 *****/
    void SceneMove()
    {
        if(fadeOutFlag && fade.sceneNext)
        {
            fadeOutFlag = false;
            fadeInFlag = true;
            Application.LoadLevel(nextSceneName);
        }
    }

    /***** フェード切替 *****/
    void FadeOut()
    {
        if (Application.loadedLevelName == "GamePlay") return;

        if (fade.inputActive)
        {
            if (Input.anyKeyDown)
            {
                SE.Play("select");
                fadeOutFlag = true;
                fadeInFlag = false;
            }
        }
    }

    public void SceneEnd()
    {
        fadeOutFlag = true;
        fadeInFlag = false;
    }
}
