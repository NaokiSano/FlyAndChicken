using UnityEngine;
using System.Collections;

public class Barrage : MonoBehaviour {
    public int power;

    private PlayerFly playerFly;

    public GameObject active;
    private bool activePowerFlag, activeFlyFlag;

	// Use this for initialization
	void Start () {
        power = 0;
        playerFly = GetComponent<PlayerFly>();
	}
	
	// Update is called once per frame
	void Update () {
        activePowerFlag = active.GetComponent<CountDown>().powerFlag;
        activeFlyFlag = active.GetComponent<CountDown>().flyFlag;

        if (Input.anyKeyDown && activePowerFlag)
        {
            power++;
            SE.Play("barrage");
        }
        if (Input.GetKeyDown(KeyCode.Space) && activeFlyFlag)
        {
            enabled = false;
            playerFly.enabled = true;
        }
	}
}
