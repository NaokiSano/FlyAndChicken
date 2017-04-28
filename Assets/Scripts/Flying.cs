using UnityEngine;
using System.Collections;

public class Flying : MonoBehaviour {
    public GameObject fadeAndSceneManager;

    private SceneManager sceneManager;
    private Rigidbody2D rigi2D;

    // Use this for initialization
    void Start () {
        rigi2D = GetComponent<Rigidbody2D>();
        sceneManager = fadeAndSceneManager.GetComponent<SceneManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if(Mathf.Abs(rigi2D.velocity.x) <= 0.1)
        {
            sceneManager.SceneEnd();
            enabled = false;
        }
	}
}
