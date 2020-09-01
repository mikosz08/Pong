
using UnityEngine;

public class PlayerManager : MonoBehaviour{
    [SerializeField] private float speed = 15.0f;
    private BoundsUtilities _boundsUtilities;


    private void Awake(){
        _boundsUtilities = GameObject.Find( "Table" ).GetComponent<BoundsUtilities>();
    }

    // Update is called once per frame
    private void Update(){
        MovePlayer();
    }

    private void MovePlayer(){
        //Get Input:
        var vertical = -Input.GetAxis( "Horizontal" ) * speed * Time.deltaTime;
        //Determinate Y pos:
        var posY = transform.position.y;
        //Add 'velocity':
        posY = Mathf.Clamp( posY + vertical, _boundsUtilities.DownBoundPosY + _boundsUtilities.BoundaryOffset, _boundsUtilities.UpBoundPosY - _boundsUtilities.BoundaryOffset );
        //Move:
        transform.position = new Vector3( transform.position.x, posY, transform.position.z );
    }
}