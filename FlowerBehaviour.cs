using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBehaviour : MonoBehaviour {
	private float time = 0;
	private float timeLimit;
	private bool collided = false;

	// Use this for initialization
	void Start() {
		timeLimit = transform.GetChild(0).transform.GetChild(0).GetComponent<TextMain>().timeLimit;
	}
	
	// Update is called once per frame
	void Update() {	
		if(collided) {
			time += Time.deltaTime;
		}
		if(time >= timeLimit) {
			gameObject.SetActive(false);
		}
	}

	private void OnTriggerEnter(Collider other) {
		if(this.enabled) {
			collided = true;
			Vector3 fireSize = gameObject.transform.localScale;
        	other.gameObject.transform.localScale += fireSize * 0.2f; 
        	foreach (Transform child in other.gameObject.transform) {
            	child.transform.localScale += fireSize * 0.2f;
        	}

        	GameObject SceneScripter = GameObject.FindWithTag("SceneScripter");
        	SceneScript SceneScript = SceneScripter.GetComponent<SceneScript>();
        	SceneScript.deadFlowers += 1;

        	foreach (Transform child in transform.GetChild(0).transform) {
            	child.GetComponent<TextMain>().active = false;
        	}

        	transform.GetChild(0).transform.GetChild(0).GetComponent<TextMain>().active = true;
			
        	transform.GetChild(1).gameObject.SetActive(true);

        	GetComponent<MeshRenderer>().enabled = false;
		}
    }
/*
    private void OnTriggerEnter(Collider other) {
		if((other.gameObject.transform.localScale.x + other.gameObject.transform.localScale.y + other.gameObject.transform.localScale.z) 
				>= (gameObject.transform.localScale.x + gameObject.transform.localScale.y + gameObject.transform.localScale.z)) {
			Vector3 fireSize = gameObject.transform.localScale;
        	other.gameObject.transform.localScale += fireSize * 0.2f; 
        	foreach (Transform child in other.gameObject.transform) {
            	child.transform.localScale += fireSize * 0.2f;
        	}

        	GameObject SceneScripter = GameObject.FindWithTag("SceneScripter");
        	SceneScript SceneScript = SceneScripter.GetComponent<SceneScript>();
        	SceneScript.deadFlowers += 1;
			gameObject.SetActive(false);
		}
    }
    */
}