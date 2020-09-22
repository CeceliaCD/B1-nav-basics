using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour {

    private bool selected;

    void OnMouseOver() {
        Debug.Log(selected);
        if (Input.GetMouseButtonDown(0)) {
            selected = !selected;
        }
    }

}
