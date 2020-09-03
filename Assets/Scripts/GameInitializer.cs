using System;
using System.Collections;
using System.Collections.Generic;
using Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameInitializer : MonoBehaviour{
    [SerializeField] private GameObject pressStartScreen;
    [SerializeField] private GameObject retryMenu;
    [SerializeField] private Text playerScoresText;

    public static GameState GameState;
    private GameObject _ball;
    private GameObject _player;
    private GameObject _timer;

    private void Awake(){
        Time.timeScale = 0;
        GameState = GameState.GameNeedInit;
    }

    private void Update(){
        WaitForSpace();
    }

    private void InitComponents(){
        _ball = GameObject.Find( "Ball" );
        _player = GameObject.Find( "Player" );
        _timer = GameObject.Find( "Timer" );
    }

    private void WaitForSpace(){
        if (!Input.GetKey( KeyCode.Space )) return;
        switch (GameState) {
            case GameState.GameNeedInit:
                InitializeGame();
                break;
            case GameState.GamePaused:
                RestartGame();
                break;
            case GameState.GameRunning:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private static void RestartGame(){
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
    }

    private void ShowPlayerScores(){
        playerScoresText.text = "\t" + GameObject.Find( "ScoreManager" ).GetComponent<ScoreManager>().GetPlayerPoints();
        playerScoresText.text += " PTS with " + GameObject.Find( "Timer" ).GetComponent<Timer>().GetPlayerTime();
        //playerScoresText.text = "\t" + GameObject.Find( "ScoreManager" ).GetComponent<ScoreManager>().GetPlayerPoints();
    }

    private void InitializeGame(){
        InitComponents();
        GameState = GameState.GameRunning;
        pressStartScreen.gameObject.SetActive( false );
        Time.timeScale = 1;
        _ball.gameObject.GetComponent<MeshRenderer>().enabled = true;
        _ball.gameObject.GetComponent<TrailRenderer>().enabled = true;
    }

    public void StopGame(){
        Time.timeScale = 0;
        GameState = GameState.GamePaused;
        //_timer.SetActive( false );
        ShowPlayerScores();
        retryMenu.gameObject.SetActive( true );
    }
}