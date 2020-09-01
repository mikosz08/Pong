using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour{
    [SerializeField] private GameObject textMenu;
    private GameObject _ball;
    private GameObject _player;
    private GameObject _timer;


    private void Awake(){
        _ball = GameObject.Find( "Ball" );
        _player = GameObject.Find( "Player" );
        _timer = GameObject.Find( "Timer" );
    }

    private void Update(){
        WaitForSpace();
    }

    private void WaitForSpace(){
        if (Input.GetKey( KeyCode.Space )) {
            InitializeGame();
        }
    }

    private void InitializeGame(){
        textMenu.gameObject.SetActive( false );

        //Ball - GameManager, MeshRenderer ON:
        _ball.gameObject.GetComponent<MeshRenderer>().enabled = true;
        _ball.gameObject.GetComponent<BallManager>().enabled = true;

        //Player - PlayerManager ON:
        _player.gameObject.GetComponent<PlayerManager>().enabled = true;

        //Timer - Script ON
        _timer.gameObject.GetComponent<Timer>().enabled = true;
    }
}