using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    bool isAttacking = false;
    public float speed = 3f;
    public float jumpForce = 5f;
    public int currentJumps;
    public int maxJumps = 2;
    public float height = 4.1f;

    private Rigidbody2D rigidBody;
    private SpriteRenderer sprite;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        currentJumps = maxJumps;
        

        // Setting this game object as the player I am asking for
        GameManager.instance.player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // This allows my sprite to move 
        float xMovement = Input.GetAxis("Horizontal") * speed;
        animator.SetFloat("xMove", Mathf.Abs(xMovement));
        rigidBody.velocity = new Vector2(xMovement, rigidBody.velocity.y);

        // handling animations through code instead of the animation system
        
        
        if(Input.GetButtonDown("Fire1"))
        {
            animator.Play("PlayerAttack");
        }

        else if (rigidBody.velocity.x != 0)
        {
            animator.Play("PlayerWalk");
        }

        else if (!isAttacking)
        {
            animator.Play("PlayerIdle");
        }
        
        /*
        else 
        {
            animator.Play("PlayerIdle");
        }*/

        // This allows my sprite to stay facing in the direction they were moving
        if (rigidBody.velocity.x > 0)
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
            if (IsGrounded())
            {
                currentJumps = maxJumps;
            }
            if (currentJumps > 0)
            {
                Jump();
            }
        }
    }
    void Jump()
    {
        currentJumps --;
        //rigidBody.AddForce(Vector2.up * jumpForce);
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
    }

    bool IsGrounded()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.down, (height / 2f) + 0.1f);
        bool grounded = (hitinfo.collider != null);
        return grounded;
    }

    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        // when the player hits an object with the tag "enemy", it will activate the player death function
        if (otherObject.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.playerDeath();
             
        }
        // when the player hits an object with the tag "victory", it will take you to the victory scene. 
        if (otherObject.gameObject.CompareTag("Victory"))
        {
            SceneManager.LoadScene("Victory");
        }
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.CompareTag("campfire"))
        {
            GameManager.instance.campfire = transform.position;
            Debug.Log("BARt");
        }
    }

    void IsAttacking()
    {
        isAttacking = true;
    }

    void IsNotAttacking()
    {
        isAttacking = false;
    }
}
