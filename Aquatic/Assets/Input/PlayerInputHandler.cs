using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    bool controlSwitched = false;
    public Rigidbody2D RB { get; private set; }


    public Vector2 RawMovementInput { get; private set; }

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        RB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (controlSwitched) {
                playerInput.actions.FindActionMap("Land").Enable();
                playerInput.actions.FindActionMap("Water").Disable();
                controlSwitched = false;
                RB.gravityScale = 1.0f;
            }
            else
            {
                playerInput.actions.FindActionMap("Water").Enable();
                playerInput.actions.FindActionMap("Land").Disable();
                controlSwitched = true;
                RB.gravityScale = 0f;
            }
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
    }
}
