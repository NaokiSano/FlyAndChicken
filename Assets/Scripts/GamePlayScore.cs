using UnityEngine;
using System.Collections;

public class GamePlayScore : MonoBehaviour {
    public Transform player;
    
	// Use this for initialization
	void Start () {
        ScoreManager.Instance.ResetScore(transform.position.x);
	}
	
	// Update is called once per frame
	void Update () {
        ScoreManager.Instance.AddScore(player.position.x);
        if(player.position.x < 0)
        {
            ScoreManager.Instance.AddScore(0);
        }
        if(player.position.x > transform.position.x || player.position.y < transform.position.y)
        {
            ScoreManager.Instance.AddScore(0);
            enabled = false;
        }
	}
}
