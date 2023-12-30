using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Striker : MonoBehaviour
{
    public Transform baseGuy1, baseGuy2, baseGuy3, baseGuy4, firstLocation;
    public GameScore gameScore;
    public Ball ball;


    public void strikerRun()
    {
        transform.DOMove(baseGuy1.position, 3);
        transform.DOMove(baseGuy2.position, 3).SetDelay(3);
        transform.DOMove(baseGuy3.position, 3).SetDelay(6);
        transform.DOMove(baseGuy4.position, 3).SetDelay(9).OnComplete(strikerReachedBaseGuy4);
    }

    void strikerReachedBaseGuy4()
    {
        ball.strikerReachedBaseGuy4 = true;
        if (ball.ballReachedBaseGuy4 == false)
        {
            gameScore.BlueTeamScores();
        }
    }

    public void GoToStartingPosition()
    {
        firstLocation.position = new Vector3(firstLocation.position.x, 1, firstLocation.position.z); 
        transform.DOMove(firstLocation.position, 0.2f);
    }
}
