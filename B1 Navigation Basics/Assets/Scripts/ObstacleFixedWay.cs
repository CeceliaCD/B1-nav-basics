using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObstacleFixedWay : MonoBehaviour
{
    public Transform[] follow;
    //NavMeshObstacle cubeObstacleFixed;
    private int curr;
    public float speed= 4.0f;

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position != follow[curr].position){
            Vector3 place = Vector3.MoveTowards(transform.position, follow[curr].position, speed*Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(place);
        }else
        curr = (curr+1) % follow.Length;
        
        
    }
        
}
