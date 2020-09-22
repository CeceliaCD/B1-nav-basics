using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour {

    private bool selected;
    private Material material;

    void Start() {
        material = gameObject.GetComponent<Renderer>().material;
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            selected = !selected;
            if (selected) material.SetColor("_Color", Color.green);
            else material.SetColor("_Color", Color.red);
        }
    }

}
