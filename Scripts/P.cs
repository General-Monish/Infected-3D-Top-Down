using UnityEngine;
using UnityEngine.AI;

public class P : MonoBehaviour
{
    public static P instance { get; private set; }

    private Vector3 mousePosition;
    private NavMeshAgent agent;
    private Animator anim;
   [SerializeField] private float rotatespeed=10f;

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
        }

        // Check if the player is close to the target position, and reset movement input
        if (Vector2.Distance(transform.position, mousePosition) < 1f)
        {
            anim.SetBool("walk", false);
        }
    }

    private void SetDestination()
    {
        agent.SetDestination(mousePosition);
    }

    void rotate()
    {
        transform.up = Vector2.Lerp(transform.forward, mousePosition, Time.deltaTime * rotatespeed);
    }

}
