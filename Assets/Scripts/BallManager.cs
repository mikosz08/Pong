using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

public class BallManager : MonoBehaviour{
    [SerializeField] private float ballSpeed;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float obliquePower; // the power that describes how big an angle should be when hitting a wall/player etc.
    private ScoreManager _scoreManager;
    private Rigidbody ballBody;
    private float _upBoundPosY;
    private float _downBoundPosY;

    private void Awake(){
        _scoreManager = GameObject.Find( "ScoreManager" ).GetComponent<ScoreManager>();
        ballBody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    private void Start(){
        LaunchBall();
    }


    private void LaunchBall(){
        var direction = Random.Range( 0, 2 );
        switch (direction) {
            case 0:
                ballBody.AddForce( new Vector2( ballSpeed, 0 ), ForceMode.Impulse );
                break;
            case 1:
                ballBody.AddForce( new Vector2( -ballSpeed, 0 ), ForceMode.Impulse );
                break;
        }
    }

    private void OnCollisionEnter( Collision hit ){
        if (hit.gameObject.tag.Equals( "Reflective" )) {
            //Determine if the ball is in upper/mid/down position relatively to player:
            var distance = transform.position.y - hit.transform.position.y;
            BounceTheBall( distance, hit );
        }

        if (hit.gameObject.tag.Equals( "Goal" )) {
            ManagePoints( hit );
            ResetBall();
        }
    }

    //Add or Subtract points:
    private void ManagePoints( Collision hit ){
        if (hit.gameObject.name.Equals( "Right" )) {
            _scoreManager.AddPoints();
        }
        else
            if (hit.gameObject.name.Equals( "Left" )) {
                _scoreManager.SubtractPoints();
            }
    }

    private void BounceTheBall( float direction, Collision hit ){
        switch (hit.gameObject.name) {
            case "Player":
                ballBody.velocity = new Vector2( ballSpeed, direction * obliquePower );
                break;
            case "Opponent":
                ballBody.velocity = new Vector2( -ballSpeed, direction * obliquePower );
                break;
        }
    }

    private void ResetBall(){
        Instantiate( ballPrefab, new Vector3( 0, 0, -1 ), Quaternion.identity );
        Destroy( gameObject );
        LaunchBall();
    }
}