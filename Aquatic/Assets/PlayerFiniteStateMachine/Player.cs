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
    //public Core Core { get; private set; }
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }
    #endregion

    #region Other Variables         

    private Vector2 workspace;

    [SerializeField]
    private Material healingMaterial;

    [SerializeField]
    private Material basicMaterial;

    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        //Core = GetComponentInChildren<Core>();
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

    private void OnDestroy()
    {
    }
    #endregion

    #region Other Functions
    public void Run(Vector2 rawMovementInput)
    {
        Flip(rawMovementInput.x);
        Vector2 velocity = RB.velocity;
        velocity.x = rawMovementInput.x;

        if (InputHandler.water)
            velocity.y = rawMovementInput.y;

        RB.velocity = velocity;
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