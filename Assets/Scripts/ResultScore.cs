using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultScore : MonoBehaviour {

    public Text scoreText;
    private int resultScore;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        ScoreManager.Instance.ScoreCalculator();
        resultScore = (int)ScoreManager.Instance.FinalScore;
        scoreText.text = "ギリギリ度 : " + resultScore.ToString() + "%";
	}
	
	// Update is called once per frame
	void Update () {
	}
}
