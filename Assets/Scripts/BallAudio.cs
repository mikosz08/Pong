using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAudio : MonoBehaviour{
    private AudioSource audio;

    private void Awake(){
        audio = GetComponent<AudioSource>();
    }
    
    private void OnCollisionEnter( Collision hit ){
        if (!hit.gameObject.tag.Equals( "Reflective" )) return;
        PlayBonkSoundOnce();
    }

    private void PlayBonkSoundOnce(){
        audio.Play();
    }
}