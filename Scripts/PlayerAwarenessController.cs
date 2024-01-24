using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    public static PlayerAwarenessController instance { get; private set; }
    [HideInInspector]
    public bool AwarenessOfPlayer;
    [HideInInspector]
    public Vector2 DirToPlayer;
   [SerializeField] private float playerAwarenessDistance;
    private Transform player;
    // Start is called before the first frame update
    private void Awake()
    {
        
        player = FindObjectOfType<Player>().transform;
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVecttor = player.position - transform.position;
        DirToPlayer = enemyToPlayerVecttor.normalized;

        if (enemyToPlayerVecttor.magnitude <= playerAwarenessDistance)
        {
            AwarenessOfPlayer = true;
        }
        else
        {
            AwarenessOfPlayer = false;
        }
    }
}
