using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : MonoBehaviour {
    public GameObject player;

    void Start () {
    }
 
    void Update() {
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject == player) {
            player.SetActive(false);
        }
    }
}
