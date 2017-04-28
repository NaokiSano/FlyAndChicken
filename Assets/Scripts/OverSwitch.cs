using UnityEngine;
using System.Collections;

public class OverSwitch : MonoBehaviour {
    public Transform player;
    public GameObject cameraObj;
    public GameObject fadeAndSceneManager;

    private SceneManager sceneManager;

    // Use this for initialization
    void Start () {
        sceneManager = fadeAndSceneManager.GetComponent<SceneManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if(player.position.x > transform.position.x  ||  player.position.y < transform.position.y)
        {
            SE.Play("miss1");
            cameraObj.GetComponent<CameraMove>().enabled = false;
            sceneManager.SceneEnd();
            enabled = false;
        }
	}
}
