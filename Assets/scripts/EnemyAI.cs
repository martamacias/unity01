using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Animator animator;
    float speed = 3f;
    public float startWaitTime = 2f;
    public Transform[] moveSpots;

    private float waitTime;
    private int i = 0;
    private Vector2 actualPos;

    void Start()
    {
        waitTime = startWaitTime;
    }

    void Update()
    {
        StartCoroutine(CheckEnemyMoving());

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);
        

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
}
