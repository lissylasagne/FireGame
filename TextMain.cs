using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMain : MonoBehaviour {
    private Camera camera;
    private GameObject player;
    private float time = 0;

    public int trigger = 0;
    public int mode = 1;
    public float timeLimit = 3;
    public bool active = true;
    public bool hasPlayed = false;

    // Use this for initialization
    void Start() {
        transform.position = transform.parent.transform.parent.transform.position;
        transform.position += 10 * Vector3.up;
        camera = Camera.main;
        player = GameObject.FindWithTag("Player");
        if(mode == 2  || mode == 3) {
            active = false;
        }
    }
    
    // Update is called once per frame
    void Update() { 
        transform.LookAt(2 * transform.position - camera.transform.position);
        
        if(active) {
            if(mode == 1) {
                if(Vector3.Distance(player.transform.position, transform.position) <= trigger) {
                    GetComponent<UnityEngine.UI.Text>().enabled = true;
                    if(!hasPlayed) {
                        print(GetComponent<UnityEngine.UI.Text>().text);
                        hasPlayed = true;
                    }
                }
            }
            else if(mode == 2) {
                if(Vector3.Distance(player.transform.position, transform.position) >= trigger) {
                    GetComponent<UnityEngine.UI.Text>().enabled = true;
                    print(GetComponent<UnityEngine.UI.Text>().text);
                    if(!hasPlayed) {
                        print(GetComponent<UnityEngine.UI.Text>().text);
                        hasPlayed = true;
                    }
                }
            }
            else if(mode == 3) {
                GetComponent<UnityEngine.UI.Text>().enabled = true;
                if(!hasPlayed) {
                    print(GetComponent<UnityEngine.UI.Text>().text);
                    hasPlayed = true;
                }
            }
        }

        else if(!active) {
            GetComponent<UnityEngine.UI.Text>().enabled = false;
        }

        if(hasPlayed && time <= timeLimit) {
            time += Time.deltaTime;
        }
        else if(time > timeLimit) {
            active = false;
        }
    }
}