using UnityEngine;
using System.Collections;

/*=======//
  発射台
 ========*/

public class LauchPad : MonoBehaviour {

    private float rotation;
    private bool activeFlag;
    public GameObject active;

	// Use this for initialization
	void Start () {
        rotation = 0;

	}
	
	// Update is called once per frame
	void Update () {
        activeFlag = active.GetComponent<CountDown>().rotationFlag;

        if (Input.anyKeyDown && activeFlag)
        {
            SE.Play("barrage");
            rotation += 1;
            Quaternion rot = transform.rotation;
            rot.z = rotation;
            transform.rotation = Quaternion.Euler(rot.x, rot.y, rot.z);
        }

	}
}
