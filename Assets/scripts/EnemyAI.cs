using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Animator animator;
    //public SpriteRenderer spriteRenderer;
    float speed = 1.5f;
    public float startWaitTime = 2f;
    public Transform[] moveSpots;
    public bool attack;
    bool alert;
    public GameObject target;
    public GameObject range;
    public GameObject hit;

    private float waitTime;
    private int i = 0;
    private Vector2 actualPos;
    public float visualRange;
    public float attackRange;

    void Start()
    {
        waitTime = startWaitTime;
    }

    void Update()
    {
        StartCoroutine(CheckEnemyMoving());

        if (!alert)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);
        }
        else if (alert)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.transform.position.x,
                transform.position.y), speed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
                {
                    i++;
                } 
                else
                {
                    i = 0;
                }
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

    }

    IEnumerator CheckEnemyMoving()
    {
        actualPos = transform.position;
        yield return new WaitForSeconds(0.5f);

        if (Mathf.Abs(actualPos.x - target.transform.position.x) > visualRange && !attack)
        {
            alert = false;
            speed = 1.5f;
            animator.SetBool("Attack", false);
            animator.SetBool("Run", false);
            if (transform.position.x < actualPos.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                animator.SetBool("Walk", true);
                animator.SetBool("Idle", false);
            }
            else if (transform.position.x > actualPos.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                animator.SetBool("Walk", true);
                animator.SetBool("Idle", false);
            }
            else if (transform.position.x == actualPos.x)
            {
                animator.SetBool("Idle", true);
                animator.SetBool("Walk", false);
            }
        }
        else
        {
            alert = true;
            if (Mathf.Abs(actualPos.x - target.transform.position.x) > attackRange && !attack)
            {
                speed = 3f;
                animator.SetBool("Attack", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Walk", false);
                if (actualPos.x < target.transform.position.x)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    animator.SetBool("Run", true);
                    
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    animator.SetBool("Run", true);
                }
            }
            else
            {
                if (!attack)
                {
                    if (actualPos.x < target.transform.position.x)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    animator.SetBool("Walk", false);
                    animator.SetBool("Run", false);
                    animator.SetBool("Idle", false);
                }
            }
        }
    }
    public void AttackFinal()
    {
        animator.SetBool("Attack", false);
        attack = false;
        range.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void ColliderHitTrue()
    {
        hit.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void ColliderHitFalse()
    {
        hit.GetComponent<BoxCollider2D>().enabled = false;
    }
}
