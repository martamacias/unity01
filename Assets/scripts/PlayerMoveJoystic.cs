using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMoveJoystic : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpSpeed = 15f;
    Rigidbody2D player;
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
    private float horizontalMove = 0f;
    public Joystick joystick;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        score = 0;
    }

    void Update()
    {
        horizontalMove = joystick.Horizontal * moveSpeed;
        player.velocity = new Vector2(horizontalMove, player.velocity.y);

        if (horizontalMove > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Run", true);
        }
        else if (horizontalMove < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
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
            //backgroundSound.Stop();
            //winSound.Play();
        }

    }

    public void Jump()
    {
        if (CheckGround.isGrounded)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }

    }

    public void Weapon()
    {
        var obj = Instantiate(kunai, throwPoint.position, throwPoint.rotation);
        obj.GetComponent<ThrowKunai>().playerTransform = transform;
    }
}
