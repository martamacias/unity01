using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
    public GameObject deadScreen;
    public GameObject buttonPause;
    public GameObject scoreTxt;
    public GameObject winScreen;
    public static int score;
    public AudioSource backgroundSound;
    public AudioSource winSound;
    public AudioSource gameOverSound;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        score = 0;
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.D))
        {
            player.velocity = new Vector2(moveSpeed, player.velocity.y);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Run", true);
        } 
        else if (Input.GetKey(KeyCode.A))
        {
            player.velocity = new Vector2(-moveSpeed, player.velocity.y);
            transform.rotation = Quaternion.Euler(0, 180, 0);
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
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 aimDirection = worldPosition - (Vector2)transform.position;
            aimDirection.Normalize();
            
            var obj = Instantiate(kunai, throwPoint.position, throwPoint.rotation);

            obj.GetComponent<Rigidbody2D>().velocity = aimDirection * obj.GetComponent<ThrowKunai>().speedX;
            obj.GetComponent<ThrowKunai>().playerTransform = transform;
            
        }

        if (EnemyHit.enemyHit)
        {
            spriteRenderer.enabled = false;
            buttonPause.SetActive(false);
            deadScreen.SetActive(true);
            backgroundSound.Stop();
            gameOverSound.Play();
        }
        
        if (score == 2)
        {
            buttonPause.SetActive(false);
            scoreTxt.SetActive(false);
            winScreen.SetActive(true);
            backgroundSound.Stop();
            winSound.Play();
        }
        
    }
}
