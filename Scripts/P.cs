using UnityEngine;
using UnityEngine.AI;

public class P : MonoBehaviour
{
    public static P instance { get; private set; }

    private Vector3 mousePosition;
    private NavMeshAgent agent;
    private Animator anim;
    private bool isClicked = false;
    private bool isAttacking = false;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        if (!isAttacking)
        {
            MouseMovement();
            SetDestination();
            rotate(); // added commint

            CheckForEnemy();
        }
    }

    private void MouseMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("walk", true);
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;

            // Check if the clicked position has a collider
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);
            if (hitCollider != null)
            {
                anim.SetBool("walk", false);
                // If the clicked position has a collider, don't move the player
                Debug.Log("Clicked on an object with a collider. Player won't move.");
                return;
            }

            // If no collider was found, move the player to the clicked position
            agent.SetDestination(mousePosition);
            isClicked = true;
        }

        // Player is close to the target position, reset movement input
        if (Vector2.Distance(transform.position, mousePosition) < 0.1f)
        {
            anim.SetBool("walk", false);
            isClicked = false;
        }
    }


    private void SetDestination()
    {
        if (isClicked)
        {
            agent.SetDestination(mousePosition);
        }
    }

    
    void rotate()
    {
        // Checking if the agent has a path
        if (agent.hasPath)
        {
            // Getting the direction to the next waypoint
            Vector3 nextWaypoint = agent.path.corners[1]; // Assuming the path has at least one corner
            Vector3 lookDirection = nextWaypoint - transform.position;

            // Calculate the rotation angle
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

            // Adjust the angle to make player face the correct direction
            angle -= 90f;

            // Use LookAt to set the rotation smoothly
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    // noyhing


    void CheckForEnemy()
    {
        // Define a layer mask to filter which objects the ray can hit
        int enemyLayerMask = 1 << LayerMask.NameToLayer("Enemy");

        // Cast a ray from the player position in the direction the player is facing
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1f, enemyLayerMask);

        // If the ray hits something on the "Enemy" layer, it's an enemy
        if (hit.collider != null && hit.collider.CompareTag("enemy"))
        {
            anim.SetTrigger("attack");
            Destroy(hit.collider.gameObject, 0.5f);
        }

        if (hit.collider != null && hit.collider.CompareTag("SC")) // For Scientist
        {
            // Trigger the attack animation
            anim.SetTrigger("attack");

            // Destroy the scientist after a delay
            Destroy(hit.collider.gameObject, 0.5f);
        }
    }



}
