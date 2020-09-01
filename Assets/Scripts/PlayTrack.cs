using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTrack : MonoBehaviour{
    
    [SerializeField] private AudioClip clip;
    
    private AudioSource source;
    
    [Range(0.0f, 1.0f)]
    public float volume;
    
    private void Awake(){
        source = gameObject.GetComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.Play();
    }

}
