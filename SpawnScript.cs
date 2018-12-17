using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

	private float time = 0;
	private float spawnTime;
	private float minTime = 5;
	private float maxTime = 10;

	private Vector3 spawnPoint;
  private Vector3 scale;

	private GameObject flower1;
  private GameObject flower2;
  private GameObject flower3;
  private GameObject tree1;

	// Use this for initialization
	void Start() {
        flower1 = Resources.Load("Prefabs/flower1prefab") as GameObject;
		    flower2 = Resources.Load("Prefabs/flower2prefab") as GameObject;
        flower3 = Resources.Load("Prefabs/flower3prefab") as GameObject;
        tree1 = Resources.Load("Prefabs/tree1prefab") as GameObject;

        //flower2 = Resources.Load("Prefabs/flower2Prefab") as GameObject;
        for(int i = 0; i <= 5; i++) {
            //int random = UnityEngine.Random.Range(0,2);
            //if(random <= 2) {
                //SpawnObject(flower1);
            //}
            //else {
                //SpawnObject(flower2);
            //}
        }
		SetRandomTime();
	}

	// Update is called once per frame
	void Update() {
        //random spawning
       	time += Time.deltaTime;
 
       	if(time >= spawnTime) {
       		time = 0;
       		/*int random = UnityEngine.Random.Range(0,5);
       		if(random >= 2) {
       			SpawnObject(flower1);
       		}
       		else {
       			SpawnObject(flower2);
       		}*/

          //SpawnObject(flower1);
          SetRandomTime();
        }
        
        //manual spawning
        if(Input.GetKeyDown(KeyCode.C)) {
            SpawnObject(flower1);
            SpawnObject(flower2);
            SpawnObject(flower3);
            SpawnObject(tree1);
        }
        /*
        if(Input.GetKeyDown(KeyCode.X)) {
            SpawnObject(flower2);
        }*/
	}

	private void SetRandomTime() {
        spawnTime = Random.Range(minTime, maxTime);
    }

    private void SetRandomPosition() {
    	spawnPoint.x = Random.Range(-30, 30);
      	spawnPoint.y = 1;
      	spawnPoint.z = Random.Range(0, 60);

      	if(Physics.OverlapSphere(spawnPoint, scale.x).Length > 0) {
            SetRandomPosition();
        }
    }
/*
    void SetRandomPositionInRange(int range) {
    	//in range of any fire
        GameObject[] flames;
        flames = GameObject.FindGameObjectsWithTag("Player");

        int random = UnityEngine.Random.Range(0,flames.Length);

        GameObject player = flames[random];

        spawnPoint.x = Random.Range(player.transform.position.x-range, player.transform.position.x+range);
      	spawnPoint.y = scale.y;
      	spawnPoint.z = Random.Range(player.transform.position.y-range, player.transform.position.y+range);

        if(Physics.OverlapSphere(spawnPoint, scale.x).Length > 0) {
            SetRandomPositionInRange(range);
        }
    }
*/
    private void SetRandomScale() {
        scale.x = scale.y = scale.z = Random.Range(0.5f, 1.5f);
    }

    private void SpawnObject(GameObject flower) {
        SetRandomScale();
        flower.transform.localScale = scale;

    	   SetRandomPosition();
        Instantiate(flower, spawnPoint, Quaternion.identity);
    }
}