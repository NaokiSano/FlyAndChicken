using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
    public Transform player;
    private float moveValue;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        moveValue = player.position.x - transform.position.x;
        transform.Translate(moveValue, 0, 0);
	}
}
