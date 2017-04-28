using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {
    public CameraMove cameraMove;
    private Transform player;

	// Use this for initialization
	void Start () {
        player = cameraMove.player;
	}
	
	// Update is called once per frame
	void Update () {
        if(player.position.x >= transform.position.x)
        {
            cameraMove.enabled = true;
            enabled = false;
        }
	}
}
