using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float panSpeed = 0.5f;
	public float rotateSpeed = 1.25f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		float factor = 1f;
		if (Input.GetKey (KeyCode.LeftShift))
			factor = 2f;
		
		if (Input.GetKey ("w")) {
			pos.z += panSpeed * factor * Time.deltaTime;
		} 

		if (Input.GetKey ("a")) {
			pos.x -= panSpeed * factor  * Time.deltaTime;
		} 

		if (Input.GetKey ("s")) {
			pos.z -= panSpeed * factor  * Time.deltaTime;
		} 

		if (Input.GetKey ("d")) {
			pos.x += panSpeed * factor  * Time.deltaTime;
		} 

		transform.position = pos;

		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;
		if (Physics.Raycast (transform.position, ray.direction, out hit, 1000)) {
			
			if (Input.GetKey ("q")) {
				transform.RotateAround (hit.point, Vector3.up, -rotateSpeed * factor);
			} else if (Input.GetKey ("e")) {
				transform.RotateAround (hit.point, Vector3.up, rotateSpeed * factor);
			}
		}

	} 
}
