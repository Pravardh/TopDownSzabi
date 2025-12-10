using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerCombat : MonoBehaviour, Actions.ICombatActions
{
    [SerializeField]
    private LayerMask enemyLayer;

    private PlayerInput playerInput;
    private PlayerAnimation playerAnimation;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }
    private void Start()
    {
        playerInput.PlayerActions.Combat.SetCallbacks(this);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            HandleAttack();
        }
    }

    private void HandleAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 2, enemyLayer);
        Debug.Log("Attacking");
        playerAnimation.Attack();
        if (hit == null) return;
        if (hit.gameObject.TryGetComponent(out IInteraction interaction))
        {
            Debug.Log("Interacting");
            interaction.Interact();
        }

    }


}
