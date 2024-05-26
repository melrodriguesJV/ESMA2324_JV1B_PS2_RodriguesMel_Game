using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoves : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpforce;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;
    private bool grounded;
    private bool onWall;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        
        //flip the player
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(0.4050891f, 0.4050891f, 0.4050891f);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-0.4050891f, 0.4050891f, 0.4050891f);

        //animations
        anim.SetBool("run", horizontalInput !=0);
        anim.SetBool("grounded", grounded);

        if (wallJumpCooldown < 0.2f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        }
        else
            wallJumpCooldown += Time.deltaTime;
    }

    private void Jump()
    {
        if (grounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpforce);
            anim.SetTrigger("jump");
        }

        if (onWall && !grounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpforce);
            anim.SetTrigger("jump");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }

        if (collision.gameObject.tag == "Wall")
        {
            onWall = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
             grounded = false;
        }

        if (collision.gameObject.tag == "Wall")
        {
            onWall = false;
        }
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && grounded && !onWall;
    }
}
