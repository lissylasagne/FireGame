using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation2a : MonoBehaviour {
    public GameObject player;

    private bool message1 = false;
    private bool message2 = false;
    private bool message3 = false;
    private bool message4 = false;
    private bool end1 = false;
    private bool end2 = false;
    private bool end3 = false;

    // Use this for initialization
    void Start() {
    }
    
    // Update is called once per frame
    void Update() { 
        if(message1 == false && Vector3.Distance(player.transform.position, transform.position) <= 40) {
            print("Hey! Don't get too close!");
            message1 = true;
        }

        if(message2 == false && Vector3.Distance(player.transform.position, transform.position) <= 30) {
            print("What did I just say!?");
            message2 = true;
        }

        if(end1 == false && ((message1 == true && Vector3.Distance(player.transform.position, transform.position) > 45) 
                            || (message2 == true && Vector3.Distance(player.transform.position, transform.position) > 35))) {
            print("That's right...");
            end1 = true;
        }

        if(message3 == false && Vector3.Distance(player.transform.position, transform.position) <= 20) {
            print("Get away from me! You'll light me on fire!");
            message3 = true;
            end1 = true;
        }

        if(end2 == false && message3 == true && Vector3.Distance(player.transform.position, transform.position) > 25) {
            print("The nerves some people have...");
            end2 = true;
        }

        if(message4 == false && Vector3.Distance(player.transform.position, transform.position) <= 10) {
            print("That's too close! You're seriousy crossing some bounderies here!");
            message4 = true;
            end2 = true;
        } 

        if(end3 == false && message4 == true && Vector3.Distance(player.transform.position, transform.position) > 15) {
            print("Creep.");
            end3 = true;
        } 
    }

    private void OnTriggerEnter(Collider other) {
        if(this.enabled) {    
            print("How dare yoouuuu...");
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