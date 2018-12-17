using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : MonoBehaviour {

	private float time = 0;
	private float lifeTime;
	private float minTime = 15;
	private float maxTime = 25;

	// Use this for initialization
	void Start() {
		SetRandomTime();
	}
	
	// Update is called once per frame
	void Update() {
		time += Time.deltaTime;
 
        //Check if its the right time to destroy the object
        if(time >= lifeTime){
        	time = 0;
            Destroy(gameObject);
            SetRandomTime();
        }
	}

  	void SetRandomTime() {
        lifeTime = Random.Range(minTime, maxTime);
    }
}




/*

TODO:

-time flowers and trees
-find narration:
	-with words
	-with sounds (voices)
	-with faces, showing emotion
	-shwoing motion without faces?

*/