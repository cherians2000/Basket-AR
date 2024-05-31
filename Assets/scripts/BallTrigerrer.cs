using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigerrer : MonoBehaviour
{
    public Animator scoreAnim;
   
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            scoreAnim.SetTrigger("Scored");
            ScoreManager.instance.Scored(1,other.transform.position);
            SpawnBall.chance++;
            ScoreManager.instance.ballLeft.text = SpawnBall.chance.ToString();
        }
    }
}
