using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Player Movement Settings")]
    [SerializeField]
    private float playerSpeed;

    private Rigidbody2D playerRigidbody;
    private BoxCollider2D playerCollider;
    private PlayerInput playerInput;

    private Vector2 playerMovementValue;

    private void Awake()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();  
    }

    private void FixedUpdate()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + (playerMovementValue * playerSpeed * Time.fixedDeltaTime));
    }

    private void Update()
    {
        playerMovementValue = playerInput.PlayerMoveInput;
    }
}