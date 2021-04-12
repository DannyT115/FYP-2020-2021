using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class targetManager : MonoBehaviour {

    public GameObject[] targetWaypoints; //Points for target to move between.
    public GameObject[] listOfBalls; //A list of all balls in the spawner.

    int waypointIndex = 0;
    public float targetSpeed; //Defines the speed of the target
    float targetDetectionArea = 0.1f;

    public TextMeshPro PlayerScoreText; //TODO: Player score

    public AudioSource scoreSound;
    public int scoreValue; //TODO: for adding to the score count on scoreboard.

    void Start(){

        scoreSound = GetComponent<AudioSource>();
    
        scoreValue = 0;

        listOfBalls = GameObject.FindGameObjectsWithTag("Balls"); //Getting all balls gameobjects tagged "Balls"

        if (targetWaypoints == null){
            targetWaypoints = GameObject.FindGameObjectsWithTag("Respawn"); //Getting all waypoint gameobjects tagged "Respawn".
        }
    }
	
	void Update () {
        //Select a random waypoint in the list of waypoints, that is away from the current waypoint.
		if(Vector3.Distance(targetWaypoints[waypointIndex].transform.position, transform.position) < targetDetectionArea) { 
            waypointIndex = Random.Range(0,targetWaypoints.Length);
        }
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoints[waypointIndex].transform.position, Time.deltaTime * targetSpeed);
    } 

    void OnTriggerEnter(Collider col) {
    //Loop through each trigger in list, 
    //if collision is detected call RespawnBall function
        foreach (GameObject b in listOfBalls) {
            if (col.gameObject == b ) {
                Invoke("RespawnTargetAtRandom", 0);
                Invoke("AddToScore", 0);
            }
        }
    }

    void AddToScore(){
        scoreSound.Play();
        scoreValue = scoreValue + 1; //add 1 to the score
        PlayerScoreText.text = scoreValue.ToString();
    }

    void RespawnTargetAtRandom(){
        waypointIndex = Random.Range(0,targetWaypoints.Length); //Making sure a random waypoint is selected next for "move to".
        var randomSpawn = targetWaypoints[Random.Range(0,targetWaypoints.Length)].transform.position;
        transform.position = randomSpawn; //Move the actual target to the new random position.
    }
}