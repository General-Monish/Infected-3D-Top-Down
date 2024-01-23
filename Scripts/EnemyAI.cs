using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    private Rigidbody2D rb;
    private Vector2 targetDir;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTargetDir();
        RotateTowardsTarget();
        SetVelocity();
    }

   private void UpdateTargetDir()
    {
        if (PlayerAwarenessController.instance.AwarenessOfPlayer)
        {
            targetDir = PlayerAwarenessController.instance.DirToPlayer;
        }
        else
        {
            targetDir = Vector2.zero;
        }

    }

    private void RotateTowardsTarget()
    {
        if (targetDir == Vector2.zero)
        {
            return;
        }
        else
        {
            Quaternion TargetRotation = Quaternion.LookRotation(transform.forward, targetDir);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, TargetRotation, rotationSpeed * Time.deltaTime);
            rb.SetRotation(rotation);
        }
    }

    private void SetVelocity()
    {
        if (targetDir == Vector2.zero)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = transform.up * speed;
        }
    }
}
