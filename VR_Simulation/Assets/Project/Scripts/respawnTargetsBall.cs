using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class respawnTargetsBall : MonoBehaviour
{
    Vector3 ballSpawnPoint;
    Rigidbody rb;

    public List<GameObject> Boundaries = new List<GameObject>();

    void Start() {

        rb = GetComponent<Rigidbody>();

        ballSpawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        //Find each "Boundary" trigger,
        //then add each Boundary trigger to list
        GameObject OB = GameObject.Find("OffWallBoundary");
        Boundaries.Add(OB);
        GameObject FB = GameObject.Find("FloorBoundary");
        Boundaries.Add(FB);
    }
 
    void OnTriggerEnter(Collider col)
    {
        //Loop through each trigger in list, 
        //if collision is detected call RespawnBall function
        foreach (GameObject bd in Boundaries) {
            if (col.gameObject == bd ) {
            Invoke("RespawnBall", 3);
            }
        }
    }

    //RespawnBall, moves it back to original position,
    //whilst simultaneously setting its velocity to 0.
    void RespawnBall()
    {
        transform.position =  ballSpawnPoint;
        rb.velocity = Vector3.zero; //Slowing down the ball
        rb.angularVelocity = Vector3.zero;
    }
}