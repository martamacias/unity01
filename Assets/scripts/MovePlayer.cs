using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpSpeed = 15f;
    Rigidbody2D player;
    public bool betterJump = true;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Transform throwPoint;
    public GameObject kunai;
    

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.D))
        {
            player.velocity = new Vector2(moveSpeed, player.velocity.y);
            spriteRenderer.flipX = false;
            throwPoint.eulerAngles = new Vector3(0, 0, 0);
            animator.SetBool("Run", true);
        } 
        else if (Input.GetKey(KeyCode.A))
        {
            player.velocity = new Vector2(-moveSpeed, player.velocity.y);
            spriteRenderer.flipX = true;
            throwPoint.eulerAngles = new Vector3(0, 180, 0);
            animator.SetBool("Run", true);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
            animator.SetBool("Run", false);
        }
        
        if (Input.GetKey(KeyCode.W) && CheckGround.isGrounded)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }

        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);
        }

        if (betterJump)
        {
            if (player.velocity.y < 0)
            {
                player.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
            }
            if (player.velocity.y > 0 && !Input.GetKey(KeyCode.W))
            {
                player.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(kunai, throwPoint.position, throwPoint.rotation);
        }
    }
}
