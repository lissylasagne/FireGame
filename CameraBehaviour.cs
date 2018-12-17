using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {
    public float turnSpeed = 3.0f;
    public Transform player;

    private Vector3 offset;

    void Start () {
        offset = new Vector3(player.position.x, player.position.y + 8.0f, player.position.z + 7.0f);
        Screen.lockCursor = false;
    }
 
    void Update() {
    	float rotationX = Input.GetAxis("Mouse X") * turnSpeed;
    	float rotationY = Input.GetAxis("Mouse Y") * turnSpeed;
        
        offset = Quaternion.AngleAxis(rotationX, Vector3.up) * offset;
        offset = Quaternion.AngleAxis(rotationY, Vector3.left) * offset;
        offset.y = Mathf.Clamp(offset.y, 30, 45);
        
        transform.position = player.position + offset; 
        transform.LookAt(player.position);
        transform.position += transform.forward * 30;
        transform.position += transform.forward * -2  * player.transform.localScale.x;

        if(Input.GetKeyDown(KeyCode.L)) {
            Screen.lockCursor = (Screen.lockCursor == false) ? true : false;
        }
    }
}

