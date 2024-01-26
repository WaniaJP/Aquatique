using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Windows;

public class Player : MonoBehaviour, IDataPersistence

{
    #region State Variables
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }

    public PlayerMoveState MoveState { get; private set; }

    [SerializeField]
    private PlayerData playerData;

    public bool isAboveLimit;
    #endregion

    #region Components
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }
    #endregion

    #region Other Variables         
    private float speed;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;
    public bool isCrouch { get; private set; }

    [SerializeField]
    private GameObject _cameraFollowGo;
    ///private CameraFollowObject _cameraFollowObject;
    
    public float health, maxHealth;
    [SerializeField]
    private HealthBar healthBar;

    public static Player _instance;
    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        if (_instance != null)
            Destroy(gameObject);
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, "wIdle");
        MoveState = new PlayerMoveState(this, StateMachine, "wMove");
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        StateMachine.Initialize(IdleState);
        //_cameraFollowObject = _cameraFollowGo.GetComponent<CameraFollowObject>();
        healthBar.setMaxHealth(maxHealth);
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
        CapsuleCollider2D capsuleCollider2D = gameObject.GetComponent<CapsuleCollider2D>();
        if (rawMovementInput.x != 0)
        {
            capsuleCollider2D.direction = CapsuleDirection2D.Horizontal;
            capsuleCollider2D.offset = new Vector2(playerData.moveOffsetX, playerData.moveOffsetY);
            capsuleCollider2D.size = new Vector2(playerData.moveSizeX, playerData.moveSizeY);
        }
        else
        {
            capsuleCollider2D.direction = CapsuleDirection2D.Vertical;
            capsuleCollider2D.offset = new Vector2(playerData.idleOffsetX, playerData.idleOffsetY);
            capsuleCollider2D.size = new Vector2(playerData.idleSizeX, playerData.idleSizeY);
        }

        if (rawMovementInput.x != 0 && rawMovementInput.y == 0)
            Anim.SetBool("IsMovingHorizontal", true);
        else
            Anim.SetBool("IsMovingHorizontal", false);

        if (rawMovementInput.y != 0)
            Anim.SetBool("IsMovingVertical", true);
        else
            Anim.SetBool("IsMovingVertical", false);

        Flip(rawMovementInput.x, rawMovementInput.y);
        if (InputHandler.isRunning)
            speed = playerData.movementVelocity;
        else 
            speed = playerData.sprintSpeed;

        Vector2 velocity = RB.velocity;
        velocity.x = rawMovementInput.x * speed;

        if (InputHandler.water)
            velocity.y = rawMovementInput.y * speed;
        RB.velocity = velocity;
    }

    public void Jump() {
        isGrounded = Physics2D.OverlapCapsule(new Vector2(groundCheck.position.x + 0.04f, groundCheck.position.y - 1.13f),new Vector2(1.83f,1f),CapsuleDirection2D.Horizontal,0, groundLayer);
        if (isGrounded && !isCrouch)       
            RB.velocity = new Vector2(RB.velocity.x, playerData.jumpVelocity);
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

    public void Flip(float xInput,float yInput)
    {
        float y = 0f;
        if (xInput < 0)
            y = 180f;
        else if (xInput > 0)
            y = 0f;

        if (yInput < 0)
            this.gameObject.transform.eulerAngles = new Vector3(180f, y, 0f);
        else if (yInput >= 0)
            this.gameObject.transform.eulerAngles = new Vector3(0f, y, 0f);
    }

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }

    public void SaveData(GameData data)
    {
        data.playerPosition = this.gameObject.transform.position;
    }
    
    public void setHealth(float healthChange)
    {
        health += healthChange;
        health = Mathf.Clamp(health, 0, maxHealth);
        healthBar.setHealth(health);
    }
    #endregion
}