
using UnityEngine;


public class AIEnemyBehavior : MonoBehaviour
{
    // Patrol settings
    public Transform[] patrolPoints;
    public float patrolSpeed = 2f;
    private int currentPatrolIndex = 0;

    // Detection settings
    public Transform player;
    public float detectionRange = 5f;
    public float chaseSpeed = 4f;
    public float losePlayerDistance = 10f;

    // State tracking
    private bool isChasing = false;

    void Update()
    {
        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }

        DetectPlayer();
    }

    // Patrol between waypoints
    private void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        // Move towards the current patrol point
        Transform targetPoint = patrolPoints[currentPatrolIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, patrolSpeed * Time.deltaTime);

        // Check if close to the patrol point
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.5f)
        {
            // Move to the next patrol point
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }

    // Chase the player
    private void ChasePlayer()
    {
        if (player == null) return;

        // Move towards the player
        transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);

        // Stop chasing if the player is too far
        if (Vector3.Distance(transform.position, player.position) > losePlayerDistance)
        {
            isChasing = false;
        }
    }

    // Detect the player
    private void DetectPlayer()
    {
        if (player == null) return;

        // Check if the player is within detection range
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRange)
        {
            isChasing = true;
        }
    }

    // Optional: Draw detection range in the Scene view
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, losePlayerDistance);
    }
}

