using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObstacleMotion : MonoBehaviour
{
    NavMeshObstacle cubeObstacle;
    private float speed = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
       cubeObstacle = GetComponent<NavMeshObstacle>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveDepth = Input.GetAxis("Depth");
        
        transform.position = transform.position + new Vector3(moveHorizontal*speed, 0, moveDepth*speed);
    }
}
