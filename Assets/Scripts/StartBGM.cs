using UnityEngine;
using System.Collections;

public class StartBGM : MonoBehaviour {
    public string fileName;

	// Use this for initialization
	void Start () {
        BGM.Play(fileName);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
