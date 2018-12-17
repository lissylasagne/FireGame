using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectScript : MonoBehaviour {

    private GameObject activeObject;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {     
        SelectObject();  
    }

    void SelectObject() {
        if(Input.GetMouseButtonDown(0)) {
         	RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            if(hit) { 
                print(hitInfo.transform.gameObject);
                if(hitInfo.transform.gameObject.tag == "Player") { 
                    if(activeObject != null) {
                        activeObject.GetComponent<ActiveBehaviour>().enabled = false; 
                    }
                    activeObject = hitInfo.transform.gameObject;
                    activeObject.GetComponent<ActiveBehaviour>().enabled = true;
                }
                else if(hitInfo.transform.gameObject.tag == "Enemy") {
                    if(activeObject != null) {
                        print("Distance: " + Vector3.Distance(hitInfo.transform.gameObject.transform.position, activeObject.transform.position));
                        if(Vector3.Distance(hitInfo.transform.gameObject.transform.position, activeObject.transform.position) <= 5) {
                            hitInfo.transform.gameObject.GetComponent<FlowerBehaviour>().enabled = true;
                        }
                        else {
                            activeObject.GetComponent<ActiveBehaviour>().enabled = false;  
                        }   
                    }
                }
         	}
         	else {
                if(activeObject != null) {
                    activeObject.GetComponent<ActiveBehaviour>().enabled = false;
                }
                activeObject = null;
         	}            
        }
        else if(Input.GetMouseButtonDown(1)) {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            if(hit) {   
                if(hitInfo.transform.gameObject.tag == "Player" && hitInfo.transform.gameObject != activeObject) {
                    if(activeObject != null) {
                        if(Vector3.Distance(hitInfo.transform.gameObject.transform.position, activeObject.transform.position) <= 5) {
                            combineFlames(activeObject, hitInfo.transform.gameObject);

                            //activeObject = newFire;
                            //activeObject.GetComponent<ActiveBehaviour>().enabled = true;
                        }
                    }
                }
            }
        }
    }

    void combineFlames(GameObject fire1, GameObject fire2) {
        //get size and position for new fire
        Vector3 fireSize = new Vector3();
        fireSize.x = (fire1.transform.localScale.x + fire2.transform.localScale.x);
        fireSize.y = (fire1.transform.localScale.y + fire2.transform.localScale.y);
        fireSize.z = (fire1.transform.localScale.z + fire2.transform.localScale.z);

        Vector3 firePos = new Vector3();
        firePos.x = (fire1.transform.position.x + fire2.transform.position.x)/2;
        firePos.y = (fire1.transform.position.y + fire2.transform.position.y)/2 + fireSize.y*0.5f;
        firePos.z = (fire1.transform.position.z + fire2.transform.position.z)/2;

        //deactivate and destroy old fires
        fire1.GetComponent<ActiveBehaviour>().enabled = false;
        fire2.GetComponent<ActiveBehaviour>().enabled = false;

        fire1.GetComponent<Collider>().enabled = false;
        fire2.GetComponent<Collider>().enabled = false;

        fire1.GetComponent<ParticleSystem>().Stop();
        fire2.GetComponent<ParticleSystem>().Stop();

        foreach (Transform child in fire1.transform) {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Transform child in fire2.transform) {
            GameObject.Destroy(child.gameObject);
        }

        Destroy(fire1, 5);
        Destroy(fire2, 5);

        //instantiate new fire
        GameObject newFire;
        newFire = Resources.Load("Prefabs/firePrefab") as GameObject;
        
        newFire.transform.localScale = fireSize;
        foreach (Transform child in newFire.transform) {
            child.transform.localScale = fireSize;
        }

        Instantiate(newFire, firePos, Quaternion.identity);

        Vector3 oneVec = new Vector3(1.0f, 1.0f, 1.0f);
        
        newFire.transform.localScale = oneVec;
        foreach (Transform child in newFire.transform) {
            child.transform.localScale = oneVec;
        }

    }
}