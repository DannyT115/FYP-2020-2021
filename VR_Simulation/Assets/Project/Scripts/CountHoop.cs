using System.Collections;
using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;
 using TMPro;

public class CountHoop : MonoBehaviour
{
public TextMeshPro PlayerScoreText;
public int scoreValue;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0;

    }
    void OnTriggerEnter()
    {
        scoreValue = scoreValue + 1; //add 1 to the score
        PlayerScoreText.text = scoreValue.ToString();
        //AudioSource.PlayClipAtPoint(scoreSoundn); //TODO: play score sound
    }
}
