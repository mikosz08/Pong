using System;
using UnityEngine;

public class DifficultyManager : MonoBehaviour{
    [SerializeField] private int increasePoint;
    [SerializeField] private float increaseBallSpeedBy;
    
    [SerializeField] private float opponentScaleLimit;
    [SerializeField] private float playerScaleLimit;
    [SerializeField] private float ballSpeedLimit;

    private GameObject _player;
    private GameObject _opponent;
    private BallManager _ballManager;

    private int _scoreCeiling;


    private void Awake(){
        _player = GameObject.Find( "Player" );
        _opponent = GameObject.Find( "Opponent" );
        _ballManager = GameObject.Find( "Ball" ).GetComponent<BallManager>();
    }

    private void Start(){
        _scoreCeiling = increasePoint;
    }

    public void ManageDiffByScore( int currentScore ){
        if (_scoreCeiling >= currentScore) return;
        _scoreCeiling = currentScore + increasePoint;
        IncreaseDifficulty();
    }

    private void IncreaseDifficulty(){
        var player = _player.transform;
        var opponent = _opponent.transform;

        if (player.localScale.y > playerScaleLimit) {
            player.localScale -= new Vector3( 0, player.localScale.y * 0.1f, 0 );
        }


        if (opponent.localScale.y < opponentScaleLimit) {
            opponent.localScale += new Vector3( 0, opponent.localScale.y * 0.2f, 0 );
        }

        if (_ballManager.BallSpeed < ballSpeedLimit) {
            _ballManager.IncreaseSpeed( increaseBallSpeedBy );
        }
    }
}