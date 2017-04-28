using UnityEngine;
using System.Collections;

public class PlayerFly : MonoBehaviour {
    public Transform launchPad;

    private Flying flying;
    private Barrage barrage;
    private Rigidbody2D rigi2D;

	// Use this for initialization
	void Start () {
        flying = GetComponent<Flying>();
        barrage = GetComponent<Barrage>();
        rigi2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        SE.Play("fly");
        Vector2 velocity = launchPad.right * barrage.power;
        rigi2D.AddForce(velocity, ForceMode2D.Impulse);
        rigi2D.AddTorque(-barrage.power * 2, ForceMode2D.Impulse);
        flying.enabled = true;
        enabled = false;
	}
}
