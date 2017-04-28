using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

    SceneManager sceneManager;
    GUITexture guiTex;
    Color colors;
    public Texture2D screen;
    public float fadeAlpha;

    [System.NonSerialized]
    public bool sceneNext;
    [System.NonSerialized]
    public bool inputActive;

	// Use this for initialization
	void Start () {
        sceneManager = GetComponent<SceneManager>();
        guiTex = GetComponent<GUITexture>();
        fadeAlpha = 0.005f;
        colors.a = 1;
        guiTex.color = colors;
        sceneNext = false;
	}
	
	// Update is called once per frame
	void Update () {
        Mathf.Clamp(colors.a, 0, 1);

        if (colors.a > 1)
        {
            inputActive = false;
            sceneNext = true;
        }
        else if(colors.a <= 0)
        {
            inputActive = true;
        }
        else
            sceneNext = false;
        
        if(colors.a < 0)
        {
            sceneManager.fadeInFlag = false;
        }
	}

    void OnGUI()
    {
        if (sceneManager.fadeOutFlag)
        {
            colors.a += fadeAlpha;
            GUI.color = new Color(255, 255, 255, colors.a);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), screen);
        }
        else if (sceneManager.fadeInFlag)
        {
            colors.a -= fadeAlpha;
            GUI.color = new Color(255, 255, 255, colors.a);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), screen);
        }
    }
}
