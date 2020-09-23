using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject target;
    public float movementMultiplier;
    public float lookMultiplierX, lookMultiplierY;
    public string lookButton;

    void Update() {

        float moveVertical = Input.GetAxis("Vertical") * movementMultiplier;        
        float moveHorizontal = Input.GetAxis("Horizontal") * movementMultiplier;                
        float moveDepth = Input.GetAxis("Depth") * movementMultiplier;

        transform.position = transform.position + transform.forward * moveVertical + transform.right * moveHorizontal + transform.up * moveDepth;
        
        if (Input.GetKey(lookButton)) {
            Debug.Log("Look Toggled");
            transform.eulerAngles = transform.eulerAngles + new Vector3(-1 * lookMultiplierY * Input.GetAxis("Mouse Y"), lookMultiplierX * Input.GetAxis("Mouse X"), 0.0f);
        }

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
