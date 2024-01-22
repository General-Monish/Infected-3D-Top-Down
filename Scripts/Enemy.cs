using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instance { get; private set; }
    public float detectionRadius = 5f; // Adjust this based on how close you want the player to be detected

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is more than one instance of the Enemy script.");
        }
        else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPlayer();
    }

    void CheckForPlayer()
    {
        // Find the player object (you may need to adjust the tag or method based on your game)
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Check the distance to the player
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            // If the player is within the detection radius, perform actions
            if (distanceToPlayer < detectionRadius)
            {
                // Your logic for when the player is detected goes here
               
            }
        }
    }
}
