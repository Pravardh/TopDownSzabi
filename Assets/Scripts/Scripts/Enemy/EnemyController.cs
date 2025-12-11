using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField]
    private Transform waypoint;

    [SerializeField]
    private float enemySpeed;

    [SerializeField]
    private float stoppingDistance = 1.0f;

    [SerializeField]
    private EnemyVision enemyVision;

    [SerializeField]
    private EnemyState currentEnemyState;

    [SerializeField]
    private Transform playerRef;

    private Rigidbody2D enemyRigidbody;


    private bool isMovingTowardsTarget = true;

    private Vector2 targetDirection;

    private Vector3 startingPosition;
    private Vector3 targetPosition;
    private void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();

        enemyVision.OnSeePlayer += OnPlayerSeen;
        enemyVision.OnStopSeePlayer += EnemyVision_OnStopSeePlayer;
    }

    private void EnemyVision_OnStopSeePlayer()
    {
        currentEnemyState = EnemyState.PATROL;
    }

    private void OnPlayerSeen()
    {
        currentEnemyState = EnemyState.CHASE;
        isMovingTowardsTarget = false;
    }

    private void Start()
    {
        startingPosition = transform.position;
        currentEnemyState = EnemyState.PATROL;

    }

    private void Update()
    {

        switch (currentEnemyState)
        {
            case EnemyState.PATROL:

                if (isMovingTowardsTarget)
                {
                    targetDirection = waypoint.position - transform.position;
                    targetPosition = waypoint.position;
                }
                else
                {
                    targetDirection = startingPosition - transform.position;
                    targetPosition = startingPosition;
                }


                if (Vector3.Distance(transform.position, targetPosition) < stoppingDistance)
                {
                    isMovingTowardsTarget = !isMovingTowardsTarget;
                }

                break;
            case EnemyState.CHASE:
                targetDirection = playerRef.position - transform.position;
                targetPosition = playerRef.position;

                break;
            default:
                break;
        }
      

        targetDirection.Normalize();
    }

    private void FixedUpdate()
    {
        enemyRigidbody.MovePosition(enemyRigidbody.position + enemySpeed * Time.fixedDeltaTime * targetDirection);
    }


}

public enum EnemyState
{
    PATROL,
    CHASE
}