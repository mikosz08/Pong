using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour{
    [SerializeField] private Text pointsText;
    [SerializeField] private int pointsOnLose;
    [SerializeField] private int pointsOnWin;
    private string playerPoints;
    private Random r;

    private void Start(){
        playerPoints = "0000";
    }

    private void Update(){
        pointsText.text = "SCORE: " + playerPoints;
    }

    //convert player points to int, add/subtrack points and convert it back into string
    public void SubtractPoints(){
        playerPoints = ( int.Parse( playerPoints ) - Random.Range( pointsOnLose, pointsOnLose * 2 ) ).ToString();
    }

    public void AddPoints(){
        playerPoints = ( int.Parse( playerPoints ) + Random.Range( pointsOnWin, pointsOnWin * 2 ) ).ToString();
    }
}