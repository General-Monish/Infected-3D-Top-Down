using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    private Rigidbody2D rb;
    private Vector2 targetDir;
    private float _changeDir;
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
        HandleRandomDirectionChange();
        MovringWawayFromPlayer();
    }

    private void MovringWawayFromPlayer()
    {
        if (PlayerAwarenessController.instance.AwarenessOfPlayer)
        {
            targetDir = -PlayerAwarenessController.instance.DirToPlayer;
        }
    }

    private void HandleRandomDirectionChange()
    {
        _changeDir -= Time.deltaTime;

        if (_changeDir <= 0)
        {
            float angleChange = Random.Range(90, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            targetDir = rotation * targetDir;
            _changeDir = Random.Range(1f, 2f);
        }
    }
    private void RotateTowardsTarget()
    {
       
      
        
            Quaternion TargetRotation = Quaternion.LookRotation(transform.forward, targetDir);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, TargetRotation, rotationSpeed * Time.deltaTime);
            rb.SetRotation(rotation);
        
    }

    private void SetVelocity()
    {
        
            rb.velocity = transform.up * speed;
        
    }
}
