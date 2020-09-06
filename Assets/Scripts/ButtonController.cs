using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
     
    //Reset Game Function:
    public void ResetGame(){
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex);
    }
    
    //QUIT GAME
    public static void QuitApp(){
        Application.Quit();
    }
    
    private void Update()
    {
        print( "Quitting..." );
        if (Input.GetKey(KeyCode.Escape)) {
            print( "Quitting..." );
            QuitApp();
        }
    }
    
}
