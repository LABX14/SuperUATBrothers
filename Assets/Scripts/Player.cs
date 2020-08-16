using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 3f;
    public float jumpForce = 5f;
    public int maxJumps = 1;
    public float height = 1.1f;

    private Rigidbody2D rigidBody;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // This allows my sprite to move 
        float xMovement = Input.GetAxis("Horizontal") * speed;

        rigidBody.velocity = new Vector2(xMovement, rigidBody.velocity.y);

        // This allows my sprite to stay facing in the direction they were moving
        if(rigidBody.velocity.x > 0)
        {
            sprite.flipX = false;
        }
        if (rigidBody.velocity.x < 0)
        {
            sprite.flipX = true;
        }

        // This allows my sprite to jump
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
    }

    void Jump()
    {
        rigidBody.AddForce(Vector2.up * jumpForce);
    }

    bool IsGrounded()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.down, (height / 2f) + 0.1f);
        return (hitinfo.collider != null);
    }
}
