using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool isAboveLimit;

    public float speed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

    public float health, maxHealth;

    [SerializeField]
    private HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
     //TESTS AUGMENTER/BAISSER LA SANTE
    void Update()
    {
        ProcessInputs();

        if(Input.GetKeyDown("y")) {
            setHealth(-20f);
            
        }
        if(Input.GetKeyDown("h")) {
            setHealth(20f);
            
        }
    }

    void FixedUpdate() 
    {
        Move();
    }

    void ProcessInputs() {
        float moveY = Input.GetAxisRaw("Vertical");
        float moveX = Input.GetAxisRaw("Horizontal");
        moveDirection = new Vector2(moveX, moveY);
    }

    void Move() {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    public void setHealth(float healthChange) {
        health += healthChange;
        health = Mathf.Clamp(health, 0, maxHealth);
        healthBar.setHealth(health);
    }
}
