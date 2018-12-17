using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation3 : MonoBehaviour {
    public GameObject player;

    private bool message1 = false;
    private bool message2 = false;
    private bool message3 = false;
    private bool message4 = false;
    private bool end1 = false;
    private bool end2 = false;

    // Use this for initialization
    void Start() {
    }
    
    // Update is called once per frame
    void Update() { 
        if(message1 == false && Vector3.Distance(player.transform.position, transform.position) <= 40) {
            print("Hey you.");
            message1 = true;
        }

        if(message2 == false && Vector3.Distance(player.transform.position, transform.position) <= 30) {
            print("Can you not come too close? I don't really feel like burning now.");
            message2 = true;
        }

        if(message3 == false && Vector3.Distance(player.transform.position, transform.position) <= 20) {
            print("Seriously, I don't want that...");
            message3 = true;
        }

        if(end1 == false && ((message2 == true && Vector3.Distance(player.transform.position, transform.position) > 35)
                        || (message3 == true && Vector3.Distance(player.transform.position, transform.position) > 25))) {
            print("Thanks.");
            end1 = true;
        }

        if(message4 == false && Vector3.Distance(player.transform.position, transform.position) <= 10) {
            print("Please go away.");
            message4 = true;
            end1 = true;
        } 

        if(end2 == false && message4 == true && Vector3.Distance(player.transform.position, transform.position) > 15) {
            print("Finally.");
            end2 = true;
        } 
    }

    private void OnTriggerEnter(Collider other) {
        if(this.enabled) { 
            print("Oh damn.");
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
}