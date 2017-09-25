using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public GameObject target;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        if (target)
            offset = transform.position - target.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target) {
            transform.position = target.transform.position + offset;
        }
	}

    public void setTarget(GameObject newTarget) {
        target = newTarget;
    }
}
