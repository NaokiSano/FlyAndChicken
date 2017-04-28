using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GuideGUI : MonoBehaviour {

    public GameObject countDownTimer, player, gameScore;
    private int mode, move, power;
    private float timer;
    GUITexture guiTex;
    public Texture2D guideGuiTex;
    public Text text;
    Color colors;
    private bool active;
    private string texts;
    private float distance, maxDistance, playerDistance;

	// Use this for initialization
	void Start () {
        guiTex = GetComponent<GUITexture>();
        text = GetComponent<Text>();
        active = false;
        colors.a = 1;
        guiTex.color = colors;
        move = 0;
        timer = 0;

        playerDistance = 0;
        maxDistance = 0;
        distance = 0;
	}
	
	// Update is called once per frame
	void Update () {
        mode = countDownTimer.GetComponent<CountDown>().mode;
        power = player.GetComponent<Barrage>().power;

        maxDistance = gameScore.transform.position.x;
        playerDistance = player.transform.position.x;

        timer += 1 + Time.deltaTime;
        ActiveGui();
        DistanceCalculator();
	}

    void ActiveGui()
    {
        if(timer >= 8)
        {
            timer = 0;
        }

        if (timer > 4)
        {
            move = 125;
        }
        else
        {
            move = 120;
        }
    }

    void OnGUI()
    {
        switch (mode)
        {
            case 0:
                text.text = "ボタンを連打して角度を決定しよう！\nスペースキーを押して開始！";
                break;
            case 1:
                text.text = "";
                GUI.color = new Color(255, 255, 255, 1);
                GUI.DrawTexture(new Rect(0, move, Screen.width, Screen.height), guideGuiTex);
                break;
            case 2:
                text.text = "角度が決定された！\n次はパワーを決定しよう！\nスペースキーを押して開始！";
                GUI.color = new Color(255, 255, 255, 0);
                break;
            case 3:
                text.text = "貯めたパワー :" + power;
                GUI.color = new Color(255, 255, 255, 1);
                GUI.DrawTexture(new Rect(0, move, Screen.width, Screen.height), guideGuiTex);
                break;  
            case 4:
                text.text = "パワーが決定された！\nスペースキーでジャンプ！！";
                break;
            case 5:
                //text.enabled = false;
                text.text = "崖までの残り : " + distance.ToString();
                break;
        }
    }

    /***** 崖までの残りを算出 *****/
    void DistanceCalculator()
    {
        distance = maxDistance - playerDistance;
    }
}
