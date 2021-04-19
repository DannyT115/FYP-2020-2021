using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timerManager : MonoBehaviour
{
    float currentTime;
    public TextMeshPro TimerValue;

    // Start is called before the first frame update
    public void Start()
    {
        enabled = false;
    }
    public void StartTimer()
    {
        enabled = true;
    }
    public void Update(){

        currentTime -= 1 * Time.deltaTime;
        TimerValue.text = currentTime.ToString("0");

        if (currentTime <= 0){
            currentTime = 0;
        }
    }

     public void RestartTimer(){
        currentTime = 60f;
        TimerValue.text = currentTime.ToString("0");
    }

    public void StopTimer(){
        enabled = false;
        TimerValue.text = currentTime.ToString("0");
    }

    public void SetTime60(){
        currentTime = 60f;
        TimerValue.text = currentTime.ToString("0");
    }

    public void SetTime120(){
        currentTime = 120f;
        TimerValue.text = currentTime.ToString("0");
    }

    public void SetTime180(){
        currentTime = 180f;
        TimerValue.text = currentTime.ToString("0");
    }
}
