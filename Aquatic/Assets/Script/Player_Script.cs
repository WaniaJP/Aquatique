using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{ 
    public bool estCache;
    public float speed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate() 
    {
        Move();
    }

    void ProcessInputs() 
    {
        float moveY = Input.GetAxisRaw("Vertical");
        float moveX = Input.GetAxisRaw("Horizontal");
        moveDirection = new Vector2(moveX, moveY);
    }

    void Move() 
    {
        if (!estCache) {
            rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
        }
        
    }

    public void seCacher(Transform newPosition) {
        rb.velocity = Vector2.zero;
        transform.position = newPosition.position;
        estCache = true;
    }

    public void quitterCachette() {
        transform.position = setZIndex(transform.position, -0.05f);
        estCache = false;
    }

    private Vector3 setZIndex(Vector3 vector, float z) {
        vector.z = z;
        return vector;
    }
}
