using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }

    public PlayerMoveState MoveState { get; private set; }

    [SerializeField]
    private PlayerData playerData;
    #endregion

    #region Components
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }
    #endregion

    #region Other Variables         
    private int speed;
    [SerializeField]
    private int jumpPower = 5;

    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;
    public bool isCrouch { get; private set; }

    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, "move");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion

    #region Other Functions
    public void Run(Vector2 rawMovementInput)
    {
        Flip(rawMovementInput.x);
        if (InputHandler.isRunning)
            speed = 10;
        else 
            speed = 5;

        Vector2 velocity = RB.velocity;
        velocity.x = rawMovementInput.x * speed;

        if (InputHandler.water)
            velocity.y = rawMovementInput.y * speed;

        RB.velocity = velocity;
    }

    public void Jump() {
        isGrounded = Physics2D.OverlapCapsule(new Vector2(groundCheck.position.x + 0.04f, groundCheck.position.y - 1.13f),new Vector2(1.83f,1f),CapsuleDirection2D.Horizontal,0, groundLayer);
        if (isGrounded && !isCrouch)       
            RB.velocity = new Vector2(RB.velocity.x, jumpPower);
    }
    public void Crouch()
    {
        isGrounded = Physics2D.OverlapCapsule(new Vector2(groundCheck.position.x + 0.04f, groundCheck.position.y - 1.13f), new Vector2(1.83f, 1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        if (isGrounded)
        {
            if (!isCrouch)
            {
                transform.localScale = new Vector3(1, 0.5f, 1);
                isCrouch = true;
            }
            else
            {
                transform.localScale = new Vector3(1, 1f, 1);
                isCrouch = false;
            }
        }
    }

    public void SetVelocity(float velocityX, float velocityY)
    {
        RB.velocity.Set(velocityX, velocityY);
    }
    
    public void Flip(float xInput)
    {
        if (xInput < 0)
            this.gameObject.transform.eulerAngles = new Vector3(0f, 180f, 0f);
        else if (xInput > 0)
            this.gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }
    #endregion
}