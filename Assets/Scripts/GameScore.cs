using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class GameScore : MonoBehaviour
{
    public TextMeshProUGUI redScoreText;
    public TextMeshProUGUI blueScoreText;
    public TextMeshProUGUI winnerText;
    public Ball ball;
    public Striker striker;
    int turnCount = 0;

    void Start()
    {
        PlayerPrefs.SetInt("RedScore", 0);
        PlayerPrefs.SetInt("BlueScore", 0);
        UpdateTheText();
    }

    public void UpdateTheText()
    {
        redScoreText.GetComponent<TextMeshProUGUI>().text = "Red Team: " + PlayerPrefs.GetInt("RedScore", 0).ToString();
        blueScoreText.GetComponent<TextMeshProUGUI>().text = "Blue Team: " + PlayerPrefs.GetInt("BlueScore", 0).ToString();
    }

    public void BlueTeamScores() //Call this function when blue team scores
    {
        int x = PlayerPrefs.GetInt("BlueScore", 0); //Calling blueScore and assign to x
        x++; //increase the x
        PlayerPrefs.SetInt("BlueScore", x); //update the score
        blueScoreText.text = "Blue Team: " + PlayerPrefs.GetInt("BlueScore", 0).ToString();
        turnCount++;
        ResetTurn();
    }

    public void RedTeamScores()
    {
        int x = PlayerPrefs.GetInt("RedScore", 0);
        x++;
        PlayerPrefs.SetInt("RedScore", x);
        redScoreText.text = "Red Team: " + PlayerPrefs.GetInt("RedScore", 0).ToString();
        turnCount++;
        ResetTurn();
    }

    public void ResetTurn()
    {
        if (turnCount == 9)
        {
            EndGame();
        }
        if (turnCount < 9)
        {
            print("Reseting Turn in 5 seconds...");
            ball.catcher = false;
            ball.ballCatcher.GetComponent<NavMeshAgent>().destination = new Vector3(-13.4f, 1, 13.7f);
            Invoke(nameof(ResetIsThrowed), 5);
        }
    }

    public void ResetIsThrowed()
    {
        ball.ballReachedBaseGuy4 = false;
        ball.strikerReachedBaseGuy4 = false;
        ball.GetComponent<Rigidbody>().useGravity = false;
        ball.GetComponent<Rigidbody>().isKinematic = true;
        ball.isThrowed = false;
        striker.GoToStartingPosition();
        ball.BallToTheStart();
        print("Turn ended.");
    }

    public void EndGame()
    {
        if (PlayerPrefs.GetInt("RedScore", 0) > PlayerPrefs.GetInt("BlueScore", 0))
        {
            print("Red Team Wins!");
            winnerText.text = "Red Team Wins!";
        }
        if (PlayerPrefs.GetInt("RedScore", 0) < PlayerPrefs.GetInt("BlueScore", 0))
        {
            print("Blue Team Wins!");
            winnerText.text = "Blue Team Wins!";
        }
    }
}
