using UnityEngine;
using UnityEngine.AI;

public class P : MonoBehaviour
{
    public static P instance { get; private set; }

    private Vector3 mousePosition;
    private NavMeshAgent agent;
    private Animator anim;
    private bool isClicked = false;
    //[SerializeField] private float rotatespeed = 10f;

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
        MouseMovement();
        SetDestination();
        rotate();
    }

    private void MouseMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("walk", true);
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;
            isClicked = true;
        }

        //  player is close to the target position, and reset movement input
        if (Vector2.Distance(transform.position, mousePosition) < .1f)
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
        Vector3 lookDirection = mousePosition - transform.position;
        float distanceToTarget = Vector2.Distance(transform.position, mousePosition);

        // if the player is close to the target
        if (distanceToTarget > 1f)
        {
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

            // Use LookAt to set the rotation smoothly
            transform.up = lookDirection.normalized;
        }
    }

}