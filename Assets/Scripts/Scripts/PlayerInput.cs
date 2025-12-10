using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInput : MonoBehaviour
{
    public Actions PlayerActions { get; private set; }  

    public Vector2 PlayerMoveInput {  get; private set; }

    private void Awake()
    {
        PlayerActions = new Actions();
        PlayerActions.Enable();
    }

    void Update()
    {
        PlayerMoveInput = PlayerActions.Locomotion.Move.ReadValue<Vector2>();
    }
}
