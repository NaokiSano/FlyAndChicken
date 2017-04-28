using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDown : MonoBehaviour {

    public Text text;
    [System.NonSerialized]
    public float count, count2;
    private bool countStart;
    public bool rotationFlag, powerFlag, flyFlag;
    [System.NonSerialized]
    public int mode;
    private bool modeActive;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        count = 6;
        count2 = 6;
        countStart = false;
        rotationFlag = false;
        powerFlag = false;
        flyFlag = false;
        mode = 0;
        modeActive = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (mode == 1 || mode == 3)
        {
            text.text = "残り時間 : "+count2.ToString();
        }
        else
        {
            text.text = "";
        }

        ModeChange();
        if (countStart)
        {
            CountDownTimer();
        }
	}

    /***** カウントダウン開始 *****/
    void CountDownTimer()
    {
        if (countStart && count2 >= 0)
        {
            count -= 1 * Time.deltaTime ;
        }
        count2 = (int)count;
        if(count2 <= 0)
        {
            count2 = 0;
            countStart = false;
            rotationFlag = false;
            powerFlag = false;
            modeActive = true;
            if(mode == 1)
            {
                mode = 2;
            }
            else if(mode == 3)
            {
                flyFlag = true;
                mode = 4;
            }
        }
    }

    public bool TimerStartStop
    {
        set { countStart = value; }
    }

    /***** カウントリセット *****/
    void CountReset()
    {
        count = 6;
    }

    /***** モードチェンジ *****/
    void ModeChange()
    {
        if(Input.GetKeyDown(KeyCode.Space) && modeActive)
        {
            switch(mode)
            {
                case 0:
                    countStart = true;
                    rotationFlag = true;
                    modeActive = false;
                    mode = 1;    
                    break;
                case 1:
                    CountReset();
                    mode = 2;
                    break;
                case 2:
                    CountReset();
                    powerFlag = true;
                    countStart = true;
                    modeActive = false;
                    mode = 3;
                    break;
                case 3:
                    CountReset();
                    flyFlag = true;
                    mode = 4;
                    break;
                case 4:
                    mode = 5;
                    break;
                case 5:
                    break;
            }
        }
    }
}
