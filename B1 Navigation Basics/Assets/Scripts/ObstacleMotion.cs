using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObstacleMotion : MonoBehaviour
{
    NavMeshObstacle cubeObstacle;
    
    // Start is called before the first frame update
    void Start()
    {
       cubeObstacle = GetComponent<NavMeshObstacle>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Obstacle_Horizontal");
        float moveVertical = Input.GetAxis("Obstacle_Vertical");
        
        transform.position = transform.position + new Vector3(moveHorizontal*Time.deltaTime, 0f, moveVertical*Time.deltaTime);
    }
}
