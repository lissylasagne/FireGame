using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneScript : MonoBehaviour {
    public GameObject player;
    public GameObject flower1;
    public GameObject flower2;
    public GameObject flower3;

    public int deadFlowers = 0;

    // Use this for initialization
    void Start() {
    }
    
    // Update is called once per frame
    void Update() { 
        if(Vector3.Distance(player.transform.position, flower1.transform.position) <= 40) {
           flower1.GetComponent<Conversation1>().enabled = true;
        }

        if(Vector3.Distance(player.transform.position, flower2.transform.position) <= 40) {
            if(deadFlowers == 0) {
                flower2.GetComponent<Conversation2a>().enabled = true;
            }
            else if(deadFlowers == 1) {
                flower2.GetComponent<Conversation2b>().enabled = true;
            }
        }
        
        if(Vector3.Distance(player.transform.position, flower3.transform.position) <= 40) {
            flower3.GetComponent<Conversation3>().enabled = true;
        }
    }
}