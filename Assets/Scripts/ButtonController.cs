using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
     
    //Reset Game Function:
    public void ResetGame(){
        SceneManager.LoadScene( "Pong");
    }
    
    //QUIT GAME
    public void QuitApp(){
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKey("escape")) {
            QuitApp();
        }
    }
    
}
