using System;
using UnityEngine;

public class UltraAI : MonoBehaviour{
    [SerializeField] private float speed;
    private BoundsUtilities _boundsUtilities;
    private Vector3 _currentPos;
    private Vector3 _targetPos;
    private GameObject _ball;

    private void Awake(){
        _boundsUtilities = GameObject.Find( "Table" ).GetComponent<BoundsUtilities>();
    }

    private void FixedUpdate(){
        if (_ball != null) {
            _targetPos = _ball.transform.position;
            _currentPos = transform.position;

            //Get ball position and try to align the Y value of the Opponent gObject:
            if (_targetPos.y >= _currentPos.y && ( _targetPos.y - _currentPos.y ) > .3f) {
                var newPosY = Mathf.Clamp( _currentPos.y + speed * Time.deltaTime * 0.1F, 
                    _boundsUtilities.DownBoundPosY + _boundsUtilities.BoundaryOffset, _boundsUtilities.UpBoundPosY - _boundsUtilities.BoundaryOffset);
                transform.position = new Vector3( transform.position.x, newPosY, transform.position.z );
            }

            if (_targetPos.y <= _currentPos.y && ( _targetPos.y - _currentPos.y ) < .3f) {
                var newPosY = Mathf.Clamp( _currentPos.y - speed * Time.deltaTime * 0.1f, 
                    _boundsUtilities.DownBoundPosY + _boundsUtilities.BoundaryOffset, _boundsUtilities.UpBoundPosY - _boundsUtilities.BoundaryOffset );
                transform.position = new Vector3( transform.position.x, newPosY, transform.position.z );
            }
        }
        else {
            _ball = GameObject.FindWithTag( "Ball" );
        }
    }
}