using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class respawnBasketBall : MonoBehaviour
{
    Vector3 ballSpawnPoint;
    Rigidbody rb;

    public List<GameObject> Boundaries = new List<GameObject>();

    void Start() {

        rb = GetComponent<Rigidbody>();

        ballSpawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        //Find each "Boundary" trigger (located at the fence on each side),
        //then add each Boundary trigger to list
        GameObject NB = GameObject.Find("NorthBoundary");
        Boundaries.Add(NB);
        GameObject EB = GameObject.Find("EastBoundary");
        Boundaries.Add(EB);
        GameObject SB = GameObject.Find("SouthBoundary");
        Boundaries.Add(SB);
        GameObject WB = GameObject.Find("WestBoundary");
        Boundaries.Add(WB);
    }
 
    void OnTriggerEnter(Collider col)
    {
        //Loop through each trigger in list, 
        //if collision is detected call RespawnBall function
        foreach (GameObject bd in Boundaries) {
            if (col.gameObject == bd ) {
            Invoke("RespawnBall", 2);
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
