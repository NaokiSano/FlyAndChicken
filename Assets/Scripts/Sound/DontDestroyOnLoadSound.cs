using UnityEngine;
using System.Collections;

public class DontDestroyOnLoadSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {

        if (!gameObject.GetComponent<AudioSource>().isPlaying)
            Destroy(gameObject);
	}
}
