using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour{
    [SerializeField] private float timeRemaining = 10;
    [SerializeField] private float stopperLimit = 10;
    [SerializeField] private Text timeText;
    [SerializeField] private bool timerRuns;
    [SerializeField] private bool stopperRuns;
    private string _playerTime;
    private float _minutes = 0;

    private void Start(){
        if (stopperRuns) {
            timeRemaining = 0;
        }
    }

    // Update is called once per frame
    private void Update(){
        if (timerRuns) {
            TimerStart();
        }

        if (stopperRuns) {
            StopperStart();
        }
    }

//STOPPER
    private void StopperStart(){
        if (timeRemaining < stopperLimit) {
            timeRemaining += Time.deltaTime;
            DisplayTime( timeRemaining );
        }
        else {
            print( "Round Ends!" );
            stopperRuns = false;
        }
    }

//TIMER
    private void TimerStart(){
        if (timeRemaining > 0) {
            timeRemaining -= Time.deltaTime;
            DisplayTime( timeRemaining );
        }
        else {
            print( "Round Ends!" );
            timeText.text = "00:00:000";
            timeRemaining = 0;
            timerRuns = false;
        }
    }

    private void DisplayTime( float timeToDisplay ){
        if (timeRemaining >= 60) {
            timeRemaining = 0;
            _minutes++;
        }

        // float minutes = Mathf.FloorToInt( timeToDisplay / 60.0f );
        float seconds = Mathf.FloorToInt( timeToDisplay % 60.0f );
        var millis = ( timeToDisplay - seconds ) * 100;

        //timeText.text = string.Format( "{0:00}:{1:00}", seconds, millis );
        _playerTime = $"{_minutes:00}:{seconds:00}:{millis:000}";
        timeText.text = _playerTime;
    }

    public string GetPlayerTime(){
        return _playerTime;
    }
    
}