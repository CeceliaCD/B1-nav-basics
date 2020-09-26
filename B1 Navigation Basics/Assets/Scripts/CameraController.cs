using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject target;
    public float movementMultiplier;
    public float lookMultiplierX, lookMultiplierY;
    private bool mouseLock;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        mouseLock = true;
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape) || (!mouseLock && Input.GetMouseButton(0))) {
            mouseLock = !mouseLock;
            Cursor.lockState = mouseLock ? CursorLockMode.Locked : CursorLockMode.None;
        }
        if (!mouseLock) return;

        float moveVertical = Input.GetAxis("Vertical") * movementMultiplier;        
        float moveHorizontal = Input.GetAxis("Horizontal") * movementMultiplier;                
        float moveDepth = Input.GetAxis("Depth") * movementMultiplier;

        transform.position = transform.position + transform.forward * moveVertical + transform.right * moveHorizontal + transform.up * moveDepth;
        transform.eulerAngles = transform.eulerAngles + new Vector3(-1 * lookMultiplierY * Input.GetAxis("Mouse Y"), lookMultiplierX * Input.GetAxis("Mouse X"), 0.0f);
       
        RaycastHit hitInfo;
        if(Physics.Raycast(transform.position, transform.forward, out hitInfo)) {
            if (Input.GetMouseButtonDown(0) && hitInfo.collider.tag == "Agent"){
                hitInfo.transform.gameObject.GetComponent<AgentController>().ToggleSelected();
            } else if (Input.GetMouseButton(1) && hitInfo.collider.tag == "Ground") {
                target.transform.position = hitInfo.point;
                target.GetComponent<TargetController>().isActive = true;
            }
        }

    }
}
