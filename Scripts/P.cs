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
    public GameObject key;

    [SerializeField]
    private GameObject bloodEffectPrefab;

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
            rotate();
            CheckForEnemy();
        }
        else
        {
            agent.isStopped = true;
        }
    }

    private void MouseMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("walk", true);
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;

            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);
            if (hitCollider != null)
            {
                anim.SetBool("walk", false);
                // If the clicked position has a collider, don't move the player
                Debug.Log("Clicked on an object with a collider. Player won't move.");
                return;
            }

            agent.SetDestination(mousePosition);
            isClicked = true;
        }

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
        if (agent.hasPath)
        {
            Vector3 nextWaypoint = agent.path.corners[1];
            Vector3 lookDirection = nextWaypoint - transform.position;

            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

            angle -= 90f;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void CheckForEnemy()
    {
        int enemyLayerMask = 1 << LayerMask.NameToLayer("Enemy");

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1f, enemyLayerMask);

        if (hit.collider != null && hit.collider.CompareTag("enemy"))
        {
            isAttacking = true;
            anim.SetTrigger("attack");
            FindObjectOfType<AudioManager>().Play("Attack");
            Instantiate(bloodEffectPrefab, hit.point, Quaternion.identity);
            agent.isStopped = true;
            Destroy(hit.collider.gameObject);
            Invoke("ResetAttack", 1.0f);
        }

        if (hit.collider != null && hit.collider.CompareTag("SC"))
        {
            isAttacking = true;
            anim.SetTrigger("attack");
            FindObjectOfType<AudioManager>().Play("Attack");
            Instantiate(bloodEffectPrefab, hit.point, Quaternion.identity);
            agent.isStopped = true;
            Destroy(hit.collider.gameObject);
            DropKey();
            Invoke("ResetAttack", 1.0f);
        }
    }

    private void ResetAttack()
    {
        isAttacking = false;
        agent.isStopped = false;
    }

    private void DropKey()
    {
        Instantiate(key, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
    }
}