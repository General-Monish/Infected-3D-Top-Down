using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;


    public Transform[] spawnPoints;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetRandomDestination();  // Setting initial destination
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            SetRandomDestination();
        }
        rotate();
    }

    public void Stop()
    {
        agent.isStopped = true;
    }
    public void Moving()
    {
        agent.isStopped = false;
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

            // Adjust the angle to make the enemy face the correct direction
            angle -= 90f;

            // Use LookAt to set the rotation smoothly
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void SetRandomDestination()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Vector3 destination = spawnPoints[randomIndex].position;
        destination.z = 0f;  // Set z position to zero
        agent.SetDestination(destination);
    }

   
}
