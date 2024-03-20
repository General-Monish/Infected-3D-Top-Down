using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform player;
    public float speed;
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = player.position;
        RotateTowardsTarget();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    void RotateTowardsTarget()
    {
        Vector3 direction = target - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
