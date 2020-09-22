using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    void Update() {

        float moveVertical = Input.GetAxis("Vertical") / 4.0f;        
        float moveHorizontal = Input.GetAxis("Horizontal") / 4.0f;                
        float moveDepth = Input.GetAxis("Depth") / 4.0f;

        transform.position = new Vector3(transform.position.x + moveHorizontal, transform.position.y + moveDepth, transform.position.z + moveVertical);


    }
}
