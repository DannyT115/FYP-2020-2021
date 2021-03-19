using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class respawnBall : MonoBehaviour
{
    Vector3 ballSpawnPoint;

    void Start() {
        ballSpawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
 
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Floor") {
        Thread.Sleep(3000);
        transform.position =  ballSpawnPoint;
        }
    }
}
