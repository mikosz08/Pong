using System;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Random = UnityEngine.Random;

public class ScoreManager : MonoBehaviour{
    [SerializeField] private Text pointsText;
    [SerializeField] private int pointsOnLose;
    [SerializeField] private int pointsOnWin;

    private DifficultyManager _difficultyManager;
    private string _playerPoints;
    private Random r;

    private void Awake(){
        _difficultyManager = GameObject.Find( "DifficultyManager" ).GetComponent<DifficultyManager>();
    }

    private void Start(){
        _playerPoints = "0000";
    }

    private void Update(){
        pointsText.text = "SCORE: " + _playerPoints;
    }

    //convert player points to int, add/subtrack points and convert it back into string
    public void SubtractPoints(){
        if (GameInitializer.GameState != GameState.GameRunning) return;
        _playerPoints = ( int.Parse( _playerPoints ) - Random.Range( pointsOnLose, pointsOnLose * 2 ) ).ToString();
    }

    public void AddPoints(){
        if (GameInitializer.GameState != GameState.GameRunning) return;
        _playerPoints = ( int.Parse( _playerPoints ) + Random.Range( pointsOnWin, pointsOnWin * 2 ) ).ToString();
        _difficultyManager.ManageDiffByScore(int.Parse( _playerPoints ));
    }

    public string GetPlayerPoints(){
        pointsText.text = "SCORE: " + _playerPoints;
        return pointsText.text;
    }
}