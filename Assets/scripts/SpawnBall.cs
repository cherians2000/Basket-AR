using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBall : MonoBehaviour
{

    public static int chance = 10;
    [SerializeField] GameObject ball;
    public Camera arCamera; // Reference to your AR camera
    public float spawnOffset = 1.5f; // Offset on the z-axis
  
    public void Spawn()
    {
        Vector3 cameraPosition = arCamera.transform.position; // Get the position of the AR camera
        Vector3 spawnPosition = cameraPosition + arCamera.transform.forward * spawnOffset; // Add an offset to the z-coordinate

        Instantiate(ball, spawnPosition, Quaternion.identity); // Instantiate the ball at the spawn position

        chance--;
        ScoreManager.instance.ballLeft.text = chance.ToString();


        if (chance <= 0)
        {
            ScoreManager.instance.GameOver();
        }
    }
}
