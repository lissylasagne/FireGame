using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBehaviour : MonoBehaviour {
	private Rigidbody rb;
	private float time = 0;

	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update() {
		time += Time.deltaTime;
		if(time >= 0.5f) {
			if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
				Vector3 dir = Camera.main.transform.forward;
	  			dir.Normalize();
	  			dir.y = 0.5f;
				rb.AddForce(dir*30, ForceMode.Impulse);
				time = 0;
			}
		    else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
				Vector3 dir = -Camera.main.transform.forward;
	  			dir.Normalize();
	  			dir.y = 0.5f;
				rb.AddForce(dir*30, ForceMode.Impulse);
				time = 0;
			}
			else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
				Vector3 dir = -Camera.main.transform.right;
	  			dir.Normalize();
	  			dir.y = 0.5f;
				rb.AddForce(dir*30, ForceMode.Impulse);
				time = 0;
			}
			else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
				Vector3 dir = Camera.main.transform.right;
	  			dir.Normalize();
	  			dir.y = 0.5f;
				rb.AddForce(dir*30, ForceMode.Impulse);
				time = 0;
			}
		}
	}
}