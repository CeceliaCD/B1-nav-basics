using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject target;

    void Update() {

        float moveVertical = Input.GetAxis("Vertical") / 4.0f;        
        float moveHorizontal = Input.GetAxis("Horizontal") / 4.0f;                
        float moveDepth = Input.GetAxis("Depth") / 4.0f;

        transform.position = transform.position + transform.forward * moveVertical + transform.right * moveHorizontal + transform.up * moveDepth;
        
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if(Physics.Raycast(myRay, out hitInfo)) {
            if (Input.GetMouseButtonDown(0) && hitInfo.collider.tag == "Agent"){
                hitInfo.transform.gameObject.GetComponent<AgentController>().ToggleSelected();
            } else if (Input.GetMouseButton(1) && hitInfo.collider.tag == "Ground") {
                target.transform.position = hitInfo.point;
                target.GetComponent<TargetController>().isActive = true;
            }
        }

    }
}
