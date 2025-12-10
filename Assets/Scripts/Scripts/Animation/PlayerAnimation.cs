using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnimator;

    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        playerAnimator.SetFloat("X", playerInput.PlayerMoveInput.x);
        playerAnimator.SetFloat("Y", playerInput.PlayerMoveInput.y);
    }

    public void Attack()
    {
        playerAnimator.Play("PlayerAttack");
    }


}
