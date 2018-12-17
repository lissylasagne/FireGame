using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation1 : MonoBehaviour {
    private Transform text0;
    private Transform text1;
    private Transform text2;
    private Transform text3;
    private Transform text4;
    private Transform text5;

    // Use this for initialization
    void Start() {
        text0 = transform.GetChild(0).transform.GetChild(0);
        text1 = transform.GetChild(0).transform.GetChild(1);
        text2 = transform.GetChild(0).transform.GetChild(2);
        text3 = transform.GetChild(0).transform.GetChild(3);
        text4 = transform.GetChild(0).transform.GetChild(4);
        text5 = transform.GetChild(0).transform.GetChild(5);
    }
    
    // Update is called once per frame
    void Update() { 
       
        if(text1.GetComponent<TextMain>().hasPlayed == true) {
            text5.GetComponent<TextMain>().active = true;
        }
        
        if(text2.GetComponent<TextMain>().hasPlayed == true) {
            text1.GetComponent<TextMain>().active = false;
        }
        
        if(text3.GetComponent<TextMain>().hasPlayed == true) {
            text2.GetComponent<TextMain>().active = false;
        }
        
        if(text4.GetComponent<TextMain>().hasPlayed == true) {
            text3.GetComponent<TextMain>().active = false;
        }

        if(text5.GetComponent<TextMain>().hasPlayed == true) {
            if(text1.GetComponent<TextMain>().hasPlayed == true) {
                text1.GetComponent<TextMain>().active = false;
            } 
            if(text2.GetComponent<TextMain>().hasPlayed == true) {
                text2.GetComponent<TextMain>().active = false;
            }
            if(text3.GetComponent<TextMain>().hasPlayed == true) {
                text3.GetComponent<TextMain>().active = false;
            } 
            if(text4.GetComponent<TextMain>().hasPlayed == true) {
                text4.GetComponent<TextMain>().active = false;
            }      
        }
    }
}