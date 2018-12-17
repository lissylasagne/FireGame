using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawn : MonoBehaviour {
   public GameObject grass1;
   public GameObject player;

   private Vector3 scale;
   private Vector3 spawnPoint;


    // Use this for initialization
    void Start() {
        spawn(100);
    }
    
    // Update is called once per frame
    void Update() { 
    }

    private void SetRandomScale() {
        scale.x = scale.y = scale.z = Random.Range(0.1f, 0.5f);
    }

    private void SetRandomPositionInRange(int range) {
        spawnPoint.x = Random.Range(player.transform.position.x-range, player.transform.position.x+range);
        spawnPoint.y = 0;
        spawnPoint.z = Random.Range(player.transform.position.y-range, player.transform.position.y+range);

        //if(Physics.OverlapSphere(spawnPoint, scale.x).Length > 0) {
          //  SetRandomPositionInRange(range);
        //}
    }

    private void spawn(int number) {
        for(int i = 0; i <= number; i++) { 
            SetRandomScale();
            SetRandomPositionInRange(100);
            grass1.transform.localScale = scale;
            Instantiate(grass1, spawnPoint, Quaternion.identity);
        }
    }
}