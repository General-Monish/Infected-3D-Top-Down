using UnityEngine;

public class AI_FOV : MonoBehaviour
{
    public float viewAngle = 90f; // Angle of the FOV
    public float viewLength = 5f; // Length of the FOV

    public LayerMask targetMask; // Layer mask for detecting targets (e.g., player)
    public string playerTag = "Player"; // Tag of the player object

    weapon Weaponss;

    private void Start()
    {
        Weaponss=GetComponent<weapon>();
    }

    private void Update()
    {
        CheckForPlayerInFOV();
    }

    private void CheckForPlayerInFOV()
    {
        Collider2D[] targetsInViewAngle = Physics2D.OverlapCircleAll(transform.position, viewLength, targetMask);

        foreach (Collider2D targetCollider in targetsInViewAngle)
        {
            if (targetCollider.CompareTag(playerTag))
            {
                Vector2 dirToTarget = targetCollider.transform.position - transform.position;
                float angle = Vector2.Angle(transform.up, dirToTarget);

                // Check if the player is within the FOV angle
                if (angle < viewAngle / 2)
                {
                    // Check if there are obstacles between the enemy and the player
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, dirToTarget, viewLength, targetMask);
                    if (hit.collider != null && hit.collider.CompareTag(playerTag))
                    {
                        // Player is within FOV and not obstructed, print message to console
                        Debug.Log("Player detected!");
                        Weaponss.Shoot();
                        return;
                    }
                }
            }
        }
    }


    private void OnDrawGizmos()
    {
        // Visualize the FOV
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.1f);

        Vector3 fovLine1 = Quaternion.AngleAxis(viewAngle / 2, transform.forward) * transform.up * viewLength;
        Vector3 fovLine2 = Quaternion.AngleAxis(-viewAngle / 2, transform.forward) * transform.up * viewLength;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);
    }
}