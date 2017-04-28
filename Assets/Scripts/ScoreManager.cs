using UnityEngine;
using System.Collections;

public class ScoreManager : ScoreSingleton<ScoreManager> {

    private float gameScore;
    private float maxScore;
    private float finalScore;
    
    public ScoreManager() 
    {
        gameScore = 0;
        maxScore = 1;
        finalScore = 0;
    }

    public float Score
    {
        set { gameScore = value; }
        get { return gameScore; }
    }

    public float FinalScore
    {
        get { return finalScore; }
    }

    /***** スコア追加 *****/
    public void AddScore(float addScore)
    {
        gameScore = addScore;
    }

    /***** スコアの計算 *****/
    public void ScoreCalculator()
    {
        finalScore = gameScore / maxScore;
        finalScore *= 100;
    }

    /***** スコアリセット *****/
    public void ResetScore(float maxScore)
    {
        gameScore = 0;
        this.maxScore = maxScore;
    }
}
