using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsUtilities : MonoBehaviour{
    [SerializeField] float boundaryOffset;
    public float BoundaryOffset { get; set; }
    public float UpBoundPosY { get; set; }
    public float DownBoundPosY { get; set; }

    private void Start(){
        BoundaryOffset = boundaryOffset;
        UpBoundPosY = GameObject.Find( "Up" ).transform.position.y;
        DownBoundPosY = GameObject.Find( "Down" ).transform.position.y;
    }
}