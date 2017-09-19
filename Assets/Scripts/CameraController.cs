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
		float angle = transform.eulerAngles.y;
		Debug.Log ("angle is " + angle);

		float factor = 1f;
		if (Input.GetKey (KeyCode.LeftShift))
			factor = 2f;
		
		if (Input.GetKey ("w")) {
			pos.z += panSpeed * factor * Time.deltaTime * Mathf.Cos (angle * Mathf.PI / 180f);
			pos.x += panSpeed * factor * Time.deltaTime * Mathf.Sin (angle * Mathf.PI / 180f);
		} 

		if (Input.GetKey ("a")) {
			pos.x -= panSpeed * factor * Time.deltaTime * Mathf.Cos (angle * Mathf.PI / 180);
			pos.z += panSpeed * factor * Time.deltaTime * Mathf.Sin (angle * Mathf.PI / 180);
		} 

		if (Input.GetKey ("s")) {
			pos.z -= panSpeed * factor * Time.deltaTime * Mathf.Cos (angle * Mathf.PI / 180);
			pos.x -= panSpeed * factor * Time.deltaTime * Mathf.Sin (angle * Mathf.PI / 180);
		} 

		if (Input.GetKey ("d")) {
			pos.x += panSpeed * factor * Time.deltaTime * Mathf.Cos (angle * Mathf.PI / 180);
			pos.z -= panSpeed * factor * Time.deltaTime * Mathf.Sin (angle * Mathf.PI / 180);
		} 

		transform.position = pos;

		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;
		if (Physics.Raycast (transform.position, ray.direction, out hit, 1000)) {
			
			if (Input.GetKey ("q")) {
//				transform.Rotate(Vector3.up, -rotateSpeed * factor * Time.deltaTime, Space.World);
				transform.RotateAround (hit.point, Vector3.up, -rotateSpeed * factor);
			} else if (Input.GetKey ("e")) {
				transform.RotateAround (hit.point, Vector3.up, rotateSpeed * factor);
			}
		}

	} 
}
