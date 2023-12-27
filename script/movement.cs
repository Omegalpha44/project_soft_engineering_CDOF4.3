using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour {
 
    
    public float speed;
    public float jumpspeed;
    public float dashSpeed;
    private Rigidbody2D rb2d;
    private Animator animator;
    bool isGrounded;
    public bool canDash;
    void Start()
    {
        // get the rigidbody component and the animator component
        rb2d = GetComponent<Rigidbody2D> ();
        animator = GetComponent<Animator>();
    }
 
    void Update()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        float jump = Input.GetAxis("Jump");

        #region basic movement
        if (moveHorizontal > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);
        }
        else if (moveHorizontal < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);
        }
        #endregion
        #region animation
        if(moveHorizontal == 0 && moveVertical == 0)
        {
            animator.SetBool("isWalking", false);
        }
        
        else
        {
            animator.SetBool("isWalking", true);
        }
        #endregion
        #region special actions
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jump * jumpspeed);
        }

        if(Input.GetKeyDown(KeyCode.LeftControl) && canDash) // does not work
        {
            if(transform.localScale.x == 1)
            {
                rb2d.velocity = new Vector2(moveHorizontal + dashSpeed, rb2d.velocity.y);
            }
            else
            {
                rb2d.velocity = new Vector2(moveHorizontal-dashSpeed, rb2d.velocity.y);
            }
            canDash = false;
        }
        #endregion
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // check if the player is on the ground
        {
            isGrounded = true;
            canDash = true;
            print("collide with ground");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // check if the player is off the ground
        {
            isGrounded = false;
        }
    }
}
