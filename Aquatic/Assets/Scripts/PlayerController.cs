using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{    
    private PlayerControls playerControls;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D rb;
    private float moveSpeed = 5f;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.Water.Move.performed += OnMovePerformed;
        playerControls.Water.Move.canceled += OnMoveCancelled;
        playerControls.Water.Run.performed += OnRunPerformed;
        playerControls.Water.Run.canceled += OnRunCancelled;
    }

    private void OnDisable()
    {
        playerControls.Disable();
        playerControls.Water.Move.performed -= OnMovePerformed;
        playerControls.Water.Move.canceled -= OnMoveCancelled;
        playerControls.Water.Run.performed -= OnRunPerformed;
        playerControls.Water.Run.canceled -= OnRunCancelled;
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
    }

    private void OnMovePerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
    }

    private void OnMoveCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }
    private void OnRunPerformed(InputAction.CallbackContext value)
    {
        moveSpeed = 10f;
    }

    private void OnRunCancelled(InputAction.CallbackContext value)
    {
        moveSpeed = 5f;
    }
}
