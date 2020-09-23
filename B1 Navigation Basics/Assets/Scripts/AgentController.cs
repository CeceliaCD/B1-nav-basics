using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AgentController : MonoBehaviour {

    private bool selected;
    private Material material;
    public GameObject target;
    NavMeshAgent agent;

    void Start() {
        material = GetComponent<Renderer>().material;
        agent = GetComponent<NavMeshAgent>(); 
    }

    void Update() {
        if(selected && target.GetComponent<TargetController>().isActive) {
            agent.SetDestination(target.transform.position);
            agent.isStopped = false;  
        } else {
            agent.isStopped = true;
            agent.ResetPath();
        }
    }

    public void ToggleSelected() {
        selected = !selected;
        if (selected) material.SetColor("_Color", Color.green);
        else material.SetColor("_Color", Color.red);
    }

}
